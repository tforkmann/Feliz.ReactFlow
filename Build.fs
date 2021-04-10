open System
open System.IO
open Fake.Core
open Fake.DotNet
open Fake.Core.TargetOperators
open Fake.IO
open Farmer
open Farmer.Builders
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Tools
let execContext = Context.FakeExecutionContext.Create false "build.fsx" [ ]
Context.setExecutionContext (Context.RuntimeContext.Fake execContext)

let sharedPath = Path.getFullName "src/Shared"
let serverPath = Path.getFullName "src/Server"
let clientPath = Path.getFullName "src/Client"
let deployDir = Path.getFullName "deploy"
let sharedTestsPath = Path.getFullName "tests/Shared"
let serverTestsPath = Path.getFullName "tests/Server"
let buildDir  = "./build/"

// --------------------------------------------------------------------------------------
// Information about the project to be used at NuGet and in AssemblyInfo files
// --------------------------------------------------------------------------------------

let release = ReleaseNotes.load "RELEASE_NOTES.md"


// Git configuration (used for publishing documentation in gh-pages branch)
// The profile where the project is posted
let gitHome = "https://github.com/tforkmann"
// The name of the project on GitHub
let gitName = "Feliz.ReactFlow"

// The name of the project
// (used by attributes in AssemblyInfo, name of a NuGet package and directory in 'src')
let project = "Feliz.ReactFlow"

let projectUrl = sprintf "%s/%s" gitHome gitName

// Short summary of the project
// (used as description in AssemblyInfo and as a short summary for NuGet package)
let summary = "Feliz React Binding for ReactFlow"

let copyright = "Copyright \169 2021"
let iconUrl = "https://raw.githubusercontent.com/tforkmann/Feliz.ReactFlow/master/Feliz.ReactFlow_logo.png"
let licenceUrl = "https://github.com/tforkmann/Feliz.ReactFlow/blob/master/LICENSE.md"
let configuration = DotNet.BuildConfiguration.Release

// Longer description of the project
// (used as a description for NuGet package; line breaks are automatically cleaned up)
let description = """Feliz binding for ReactFlow."""
// List of author names (for NuGet package)
let authors = [ "Tim Forkmann; Isaac Abraham"]
let owner = "Tim Forkmann"
// Tags for your project (for NuGet package)
let tags = "Feliz binding for ReactFlow"

// --------------------------------------------------------------------------------------
// Classic SAFE STACK
// --------------------------------------------------------------------------------------


let npm args workingDir =
    let npmPath =
        match ProcessUtils.tryFindFileOnPath "npm" with
        | Some path -> path
        | None ->
            "npm was not found in path. Please install it and make sure it's available from your path. " +
            "See https://safe-stack.github.io/docs/quickstart/#install-pre-requisites for more info"
            |> failwith

    let arguments = args |> String.split ' ' |> Arguments.OfArgs

    Command.RawCommand (npmPath, arguments)
    |> CreateProcess.fromCommand
    |> CreateProcess.withWorkingDirectory workingDir
    |> CreateProcess.ensureExitCode
    |> Proc.run
    |> ignore

let dotnet cmd workingDir =
    let result = DotNet.exec (DotNet.Options.withWorkingDirectory workingDir) cmd ""
    if not result.OK then
        Trace.traceErrorfn "Errors while executing 'dotnet %s': %A" cmd result.Messages
        failwithf "'dotnet %s' failed in %s" cmd workingDir

Target.create "Clean" (fun _ ->
    !!"src/**/bin"
    |> Shell.cleanDirs
    !! "src/**/obj/*.nuspec"
    |> Shell.cleanDirs

    Shell.cleanDirs [buildDir; "temp"; "docs/output"; deployDir;]
)

Target.create "InstallClient" (fun _ -> npm "install" ".")

Target.create "Bundle" (fun _ ->
    dotnet (sprintf "publish -c Release -o \"%s\"" deployDir) serverPath
    dotnet "fable --run webpack -p" clientPath
)

Target.create "Azure" (fun _ ->
    let web = webApp {
        name "reactflowfull"
        zip_deploy "deploy"
    }
    let deployment = arm {
        location Location.WestEurope
        add_resource web
    }

    deployment
    |> Deploy.execute "reactflowfull" Deploy.NoParameters
    |> ignore
)

Target.create "Run" (fun _ ->
    dotnet "build" sharedPath
    [ async { dotnet "watch run" serverPath }
      async { dotnet "fable watch --run webpack-dev-server" clientPath } ]
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore
)

Target.create "RunTests" (fun _ ->
    dotnet "build" sharedTestsPath
    [ async { dotnet "watch run" serverTestsPath }
      async { dotnet "fable watch --run webpack-dev-server --config ../../webpack.tests.config.js" "tests/Client" } ]
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore
)

Target.create "Format" (fun _ ->
    dotnet "fantomas . -r" "src"
)

// --------------------------------------------------------------------------------------
// Build a NuGet package

Target.create "Build" (fun _ ->
    !! "src/*.fsproj"
    |> Seq.iter (fun s ->
        let dir = Path.GetDirectoryName s
        DotNet.build id dir)
)


Target.create "PrepareRelease" (fun _ ->
    Git.Branches.checkout "" false "main"
    Git.CommandHelper.directRunGitCommand "" "fetch origin" |> ignore
    Git.CommandHelper.directRunGitCommand "" "fetch origin --tags" |> ignore

    Git.Staging.stageAll ""
    Git.Commit.exec "" (sprintf "Bumping version to %O" release.NugetVersion)
    Git.Branches.pushBranch "" "origin" "main"

    let tagName = string release.NugetVersion
    Git.Branches.tag "" tagName
    Git.Branches.pushTag "" "origin" tagName
)


Target.create "Pack" (fun _ ->
    let nugetVersion = release.NugetVersion

    let pack project =
        let projectPath = sprintf "src/%s/%s.fsproj" project project
        let args =
            let defaultArgs = MSBuild.CliArguments.Create()
            { defaultArgs with
                      Properties = [
                          "Title", project
                          "PackageVersion", nugetVersion
                          "Authors", (String.Join(" ", authors))
                          "Owners", owner
                          "PackageRequireLicenseAcceptance", "false"
                          "Description", description
                          "Summary", summary
                          "PackageReleaseNotes", ((String.toLines release.Notes).Replace(",",""))
                          "Copyright", copyright
                          "PackageTags", tags
                          "PackageProjectUrl", projectUrl
                          "PackageIconUrl", iconUrl
                          "PackageLicenseUrl", licenceUrl
                      ] }

        DotNet.pack (fun p ->
            { p with
                  NoBuild = false
                  Configuration = configuration
                  OutputPath = Some "build"
                  MSBuildParams = args
              }) projectPath

    pack "Feliz.ReactFlow"
)

let getBuildParam = Environment.environVar
let isNullOrWhiteSpace = String.IsNullOrWhiteSpace

// Workaround for https://github.com/fsharp/FAKE/issues/2242
let pushPackage _ =
    let nugetCmd fileName key = sprintf "nuget push %s -k %s -s nuget.org" fileName key
    let key =
        //Environment.environVarOrFail "nugetKey"
        match getBuildParam "nugetkey" with
        | s when not (isNullOrWhiteSpace s) -> s
        | _ -> UserInput.getUserPassword "NuGet Key: "
    IO.Directory.GetFiles(buildDir, "*.nupkg", SearchOption.TopDirectoryOnly)
    |> Seq.map Path.GetFileName
    |> Seq.iter (fun fileName ->
        Trace.tracef "fileName %s" fileName
        let cmd = nugetCmd fileName key
        dotnet cmd buildDir)
Target.create "Push" (fun _ -> pushPackage [] )

let docsSrcPath = Path.getFullName "./src/Docs"
let docsDeployPath = "docs"

Target.create "InstallDocs" (fun _ ->

    npm "install --frozen-lockfile" docsSrcPath
    dotnet "restore" docsSrcPath )

Target.create "PublishDocs" (fun _ ->
    [ docsDeployPath] |> Shell.cleanDirs
    dotnet "fable --run webpack-cli -p" docsSrcPath
)


Target.create "RunDocs" (fun _ ->
    dotnet "fable watch --run webpack-dev-server --outDir src/Docs/output" docsSrcPath)

let dependencies = [
    "Clean"
        ==> "InstallClient"
        ==> "Bundle"
        ==> "Azure"

    "Clean"
        ==> "InstallClient"
        ==> "Run"

    "Clean"
        ==> "InstallClient"
        ==> "RunTests"

    "Clean"
        ==> "Build"
        ==> "PrepareRelease"
        ==> "Pack"
        ==> "Push"

    "InstallDocs"
        ==> "RunDocs"

    "InstallDocs"
        ==> "PublishDocs"
]

[<EntryPoint>]
let main args =
    try
        match args with
        | [| target |] -> Target.runOrDefault target
        | _ -> Target.runOrDefault "Run"
        0
    with e ->
        printfn "%A" e
        1
