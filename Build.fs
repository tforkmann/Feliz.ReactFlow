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
open Helpers
let execContext = Context.FakeExecutionContext.Create false "build.fsx" [ ]
Context.setExecutionContext (Context.RuntimeContext.Fake execContext)
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
let tags = "fsharp;fable;ReactFlow;feliz;react;FlowElements"


Target.create "Clean" (fun _ ->
    !!"src/**/bin"
    |> Shell.cleanDirs
    !! "src/**/obj/*.nuspec"
    |> Shell.cleanDirs

    Shell.cleanDirs [buildDir; "temp"; "docs/output"; deployDir;]
)

Target.create
    "UpdateTools"
    (fun _ ->
        run dotnet "tool update fable" __SOURCE_DIRECTORY__
        run dotnet "tool update fantomas-tool" __SOURCE_DIRECTORY__
        run dotnet "tool update fake-cli" __SOURCE_DIRECTORY__
        run dotnet "tool update paket" __SOURCE_DIRECTORY__

        )

Target.create "InstallClient" (fun _ -> run npm "install" ".")

Target.create "Run" (fun _ ->
    [  "client", npm "start" "."  ]
      |> runParallel

)

Target.create "RunTests" (fun _ ->
    run dotnet "build" sharedTestsPath
    [ "server", dotnet "watch run" serverTestsPath
      "client", npm "run test:live" "." ]
    |> runParallel
)


Target.create
    "ExecuteTests"
    (fun _ ->
        Environment.setEnvironVar "status" "Development"

        run dotnet "build" sharedTestsPath

        [ "server", dotnet "run" serverTestsPath
          "client", npm "run test:build" "." ]
        |> runParallel)

Target.create "Format" (fun _ ->
   run dotnet "fantomas . -r" "src"
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
        run dotnet cmd buildDir)
Target.create "Push" (fun _ -> pushPackage [] )

let docsSrcPath = Path.getFullName "./src/Docs"
let docsDeployPath = "docs"

Target.create "InstallDocs" (fun _ ->

    run npm "install --frozen-lockfile" docsSrcPath
    run dotnet "restore" docsSrcPath )

Target.create "PublishDocs" (fun _ ->
    [ docsDeployPath] |> Shell.cleanDirs
    run dotnet "fable --run webpack-cli -p" docsSrcPath
)


Target.create "RunDocs" (fun _ ->
    run dotnet "fable watch --run webpack-dev-server --outDir src/Docs/output" docsSrcPath)

let dependencies = [

    "Clean"
        ==> "InstallClient"
        // ==> "UpdateTools"
        ==> "Run"

    "Clean"
        ==> "InstallClient"
        // ==> "UpdateTools"
        ==> "RunTests"

    "Clean"
        ==> "InstallClient"
        // ==> "UpdateTools"
        ==> "Build"
        ==> "ExecuteTests"

    "Clean"
        ==> "InstallClient"
        ==> "UpdateTools"
        ==> "Build"
        ==> "ExecuteTests"
        ==> "PrepareRelease"
        ==> "Pack"
        ==> "Push"

    "InstallDocs"
        ==> "RunDocs"

    "InstallDocs"
        ==> "ExecuteTests"
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
