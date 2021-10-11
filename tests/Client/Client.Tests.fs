module Client.Tests

open Fable.Mocha

open Index

let client = testList "Client" [
    testCase "Added flowElement" <| fun _ ->
        let model, _ = init ()
        let flowElement =
            { Id = "6"
              Descr = "AdditionalFlowElement" }

        let model, _ = update (AddFlowElement flowElement) model

        Expect.equal 6 model.NodeList.Length "There should be 7 FlowElements"
        Expect.equal (createNode flowElement) (model.NodeList |> List.last) "NodeList should equal new nodeElement"
]

let all =
    testList "All"
        [
#if FABLE_COMPILER // This preprocessor directive makes editor happy
            Shared.Tests.shared
#endif
            client
        ]

[<EntryPoint>]
let main _ = Mocha.runTests all