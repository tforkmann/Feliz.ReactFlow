module FelizReactFlow

open Feliz
open Feliz.Bulma

let overview =
    Html.div [
        Bulma.title.h1 [
            Html.text "Feliz.ReactFlow - Documentation"
            Html.a [
                prop.href "https://www.nuget.org/packages/Fable.ReactAgGrid/"
                prop.children [
                    Html.img [
                        prop.src "https://img.shields.io/nuget/v/Fable.ReactAgGrid.svg?style=flat"
                    ]
                ]
            ]
        ]
        Bulma.subtitle.h2 [
            Html.text "Fable bindings for AgGrid."
        ]
        Html.hr []
        Bulma.content [
            Html.p "ag-Grid is a powerfulll data grid."
            Html.p "ag-Grid contains multiple filters and grouping features"
        ]
        Bulma.content [
            Bulma.title.h4 "Features"
            Html.ul [
                Html.li "column interactions (resize, reorder and pin columns="
                Html.li "Pagination"
                Html.li "Sorting"
                Html.li "Row selection"
                Html.li "Data export"
            ]
        ]
        Shared.fixDocsView "Feliz.ReactFlow" false
    ]

let installation = Shared.installationView "Feliz.ReactFlow"
