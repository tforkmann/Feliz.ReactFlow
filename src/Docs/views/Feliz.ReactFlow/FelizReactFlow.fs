module FelizReactFlow

open Feliz
open Feliz.Bulma

let overview =
    Html.div [
        Bulma.title.h1 [
            Html.text "Feliz.ReactFlow - Documentation"
            Html.a [
                prop.href "https://www.nuget.org/packages/Feliz.ReactFlow/"
                prop.children [
                    Html.img [
                        prop.src "https://img.shields.io/nuget/v/Feliz.ReactFlow.svg?style=flat"
                    ]
                ]
            ]
        ]
        Bulma.subtitle.h2 [
            Html.text "Fable bindings for ReactFlow."
        ]
        Html.hr []
        Bulma.content [
            Html.p "ReactFlow is a powerfulll data grid."
            Html.p "ReactFlow contains multiple filters and grouping features"
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
        Shared.fixDocsView "FelizReactFlow" false
    ]

let installation = Shared.installationView "Feliz.ReactFlow"
