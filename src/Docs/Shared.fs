module Shared

open Fable.Core.JsInterop
open Feliz
open Feliz.Bulma

type Highlight =
    static member inline highlight (properties: IReactProperty list) =
        Interop.reactApi.createElement(importDefault "react-highlight", createObj !!properties)

let code (c:string) =
    Highlight.highlight [
        prop.className "fsharp"
        prop.text c
    ]


let fixDocsView fileName client =
    Html.div [
        Html.a [
            prop.href (sprintf "https://github.com/tforkmann/Feliz.ReactFlow/blob/main/src/Docs/views/Feliz.ReactFlow/%s.fs" fileName)
            prop.text ("Fix docs file " + fileName + " here")
        ]
    ]
let installationView packageName =
    Html.div [
        Bulma.title.h1 (sprintf "%s - Installation" packageName)
        Html.hr []
        Bulma.content [
            Bulma.title.h4 "Use Paket"
            code (sprintf "paket add %s" packageName)
        ]
        Bulma.content [
            Bulma.title.h4 "Add react flow npm package"
            code ("npm install --save react-flow-renderer")
        ]
    ]
