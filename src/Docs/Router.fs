module Router

open Feliz.Router

type Page =
    | FelizReactFlow
    | FelizReactFlowInstallation
    | FelizReactFlowExampleFlow

let defaultPage = FelizReactFlow

let parseUrl = function
    | [ "" ] -> FelizReactFlow
    | [ "installation" ] -> FelizReactFlowInstallation
    | [ "exampleflow" ] -> FelizReactFlowExampleFlow
    | _ -> defaultPage

let getHref = function
    | FelizReactFlow -> Router.format("")
    | FelizReactFlowInstallation -> Router.format("installation")
    | FelizReactFlowExampleFlow -> Router.format("exampleflow")
