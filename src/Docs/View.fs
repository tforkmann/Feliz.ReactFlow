module View

open Domain
open Feliz
open Feliz.Bulma
open Router

let menuPart model dispatch =
    let item (t: string) p =
        let isActive =
            if model.CurrentPage = p then [ helpers.isActive ] else []

        Bulma.menuItem.a
            [ yield! isActive
              prop.onClick (fun _ -> (SentToast t) |> dispatch)
              prop.text t
              prop.href (getHref p) ]

    Bulma.menu
        [ Bulma.menuLabel "Feliz.ReactFlow"
          Bulma.menuList [ item "Overview" FelizReactFlow ]
          Bulma.menuList
              [ item "Installation" FelizReactFlowInstallation
                item "Example Flow" FelizReactFlowExampleFlow ] ]

let contentPart model dispatch =
    match model.CurrentPage with
    | FelizReactFlow -> Views.FelizReactFlow.overview
    | FelizReactFlowInstallation -> Views.FelizReactFlow.installation
    | FelizReactFlowExampleFlow -> Views.ExampleFlow.overview

let view (model: Model) (dispatch: Msg -> unit) =

    let render =
        Html.div
            [ prop.children
                  [ Bulma.section
                      [ Bulma.tile
                          [ tile.isAncestor
                            prop.children
                                [ Bulma.tile
                                    [ tile.is2
                                      prop.children (menuPart model dispatch) ]
                                  Bulma.tile (contentPart model dispatch) ] ] ] ] ]

    React.router
        [ router.onUrlChanged (parseUrl >> UrlChanged >> dispatch)
          router.children [render] ]
