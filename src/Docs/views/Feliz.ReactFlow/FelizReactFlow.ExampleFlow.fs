module Views.ExampleFlow

open Feliz
open Feliz.Bulma
open Feliz.ReactFlow
open Browser.Dom
open Shared

type style with
    static member inline background(background: string): IStyleAttribute = Interop.mkStyleProp "background" background
    static member inline border(border: string): IStyleAttribute = Interop.mkStyleProp "border" border
    static member inline stroke(stroke: string): IStyleAttribute = Interop.mkStyleProp "stroke" stroke

[<ReactComponent>]
let Counter () =
    let (count, setCount) = React.useState (0)

    Html.div
        [ prop.style [ style.padding 10 ]
          prop.children
              [ ReactFlow.handle [ handle.type' Target; handle.position Position.Top ]
                Html.button
                    [ prop.style [ style.marginRight 5 ]
                      prop.onClick (fun _ -> setCount (count + 1))
                      prop.text "Increment" ]
                Html.text count ] ]

let flowChart =
    let nodes =
        [| ReactFlow.node
               [ node.id "1"
                 node.type' Input
                 node.data {| label = "Erdgas Einsatz" |}
                 node.style
                     [ style.background "yellow"
                       style.color "#332"
                       style.border "1px solid #222138"
                       style.width 180 ]
                 node.position (50, 30) ]

           ReactFlow.node
               [ node.id "2"
                 node.type' Default
                 node.data {| label = "CityCube" |}
                 node.style
                     [ style.background "#2e88c9"
                       style.color "white"
                       style.border "1px solid #222138"
                       style.width 180 ]
                 node.position (400, 30) ]

           ReactFlow.node
               [ node.id "3"
                 node.type' Output
                 node.data {| label = "Strom Absatz" |}
                 node.style
                     [ style.background "lightblue"
                       style.color "#333"
                       style.border "1px solid #222138"
                       style.width 180 ]
                 node.position (300, 200) ]

           ReactFlow.node
               [ node.id "4"
                 node.type' Output
                 node.data {| label = "Wärme Absatz" |}
                 node.style
                     [ style.background "red"
                       style.color "white"
                       style.border "1px solid #222138"
                       style.width 180 ]
                 node.position (500, 200) ]

           ReactFlow.node
               [ node.id "5"
                 node.type' "test"
                 node.data {| label = "Label from Node" |}
                 node.position (50, 120)
                 node.style
                     [ style.background "lightgreen"
                       style.border "1px solid black"
                       style.width 180 ] ]
           ReactFlow.node
               [ node.id "6"
                 node.type' Output
                 node.data {| label = "Unconnected" |}
                 node.style
                     [ style.background "green"
                       style.color "white"
                       style.border "1px solid #222138"
                       style.width 180 ]
                 node.position (700, 200) ] |]

    let edges =
        [| ReactFlow.edge
               [ edge.id "e1-2"
                 edge.source "1"
                 edge.target "2"
                 edge.animated false
                 edge.label "100 MWh"
                 edge.type' EdgeType.SmoothStep
                 edge.markerEnd (MarkerType.ArrowClosed)
                 edge.style [ style.stroke "blue" ]
                 edge.labelStyle [ style.fill "black"; style.fontWeight 700 ] ]
           ReactFlow.edge
               [ edge.id "e2-3"
                 edge.source "2"
                 edge.target "3"
                 edge.animated true
                 edge.label "50 MWh"
                 edge.type' EdgeType.SmoothStep
                 edge.markerEnd ArrowClosed
                 edge.style [ style.stroke "blue" ]
                 edge.labelStyle [ style.fill "blue"; style.fontWeight 700 ] ]
           ReactFlow.edge
               [ edge.id "e2-4"
                 edge.source "2"
                 edge.target "4"
                 edge.animated true
                 edge.label "55 MWh"
                 edge.type' EdgeType.SmoothStep
                 edge.markerEnd ArrowClosed
                 edge.style [ style.stroke "red" ]
                 edge.labelStyle [ style.fill "red"; style.fontWeight 700 ] ]
           ReactFlow.edge
               [ edge.id "e1-6"
                 edge.source "1"
                 edge.target "5"
                 edge.targetHandle "7"
                 edge.type' EdgeType.SmoothStep
                 edge.style [ style.stroke "black" ] ] |]

    Html.div
        [ prop.style [ style.height 150 ]
          prop.children
              [ ReactFlow.reactFlow
                    [ ReactFlow.nodeTypes {| test = Counter |}
                      ReactFlow.defaultNodes nodes
                      ReactFlow.defaultEdges edges
                      ReactFlow.onNodeClick (fun ev element ->
                          console.log ev
                          window.alert "You clicked me!")
                      ReactFlow.onNodeDragStop (fun ev node nodes ->
                          console.log ev
                          window.alert $"%A{node.id}: You dragged me!")
                      ReactFlow.onNodesChange (fun changes ->
                          let removedNodes =
                              [| for change in changes do
                                     match change with
                                     | NodeChange.NodeRemoveChange remove ->
                                         if remove.``type`` = "remove" then
                                             window.alert "You removed me!"
                                             remove.id
                                     | _ -> () |]

                          if removedNodes |> Array.isEmpty |> not then
                              console.log ("Nodes removed: ", removedNodes))

                      ReactFlow.onConnect (fun element ->
                          console.log element
                          window.alert "You connected me!")
                      ReactFlow.onConnectStart (fun ev element ->
                          console.log element
                          window.alert "You started to connect me!") ] ] ]

let overview =
    Html.div
        [ Bulma.title.h1 [ Html.text "Feliz.ReactFlow Example" ]
          Bulma.content
              [ Html.p "Here is an example how to use ReactFlow"
                flowChart
                code
                    """
                ReactFlow.flowChart [
                    ReactFlow.elements [|
                        ReactFlow.node [
                            node.id "1"
                            node.nodetype Input
                            node.data {| label = "Erdgas Einsatz" |}
                            node.style [
                                style.background "yellow"
                                style.color "#332"
                                style.border "1px solid #222138"
                                style.width 180
                            ]
                            node.position (20, 5)
                        ]
                        ReactFlow.node [
                            node.id "2"
                            node.nodetype Default
                            node.data {| label = "CityCube" |}
                            node.style [
                                style.background "#2e88c9"
                                style.color "white"
                                style.border "1px solid #222138"
                                style.width 180
                            ]
                            node.position (250, 5)
                        ]
                        ReactFlow.node [
                            node.id "3"
                            node.nodetype Output
                            node.data {| label = "Strom Absatz" |}
                            node.style [
                                style.background "lightblue"
                                style.color "#333"
                                style.border "1px solid #222138"
                                style.width 180
                            ]
                            node.position (100, 100)
                        ]
                        ReactFlow.node [
                            node.id "4"
                            node.nodetype Output
                            node.data {| label = "Wärme Absatz" |}
                            node.style [
                                style.background "red"
                                style.color "white"
                                style.border "1px solid #222138"
                                style.width 180
                            ]
                            node.position (100, 100)
                        ]
                        ReactFlow.edge [
                            edge.id "e1-2"
                            edge.source "1"
                            edge.target "2"
                            edge.animated false
                            edge.label "100 MWh"
                            edge.type' EdgeType.SmoothStep
                            edge.arrowHeadType ArrowClosed
                            edge.style [ style.stroke "yellow" ]
                            edge.labelStyle [
                                labelStyle.fill "black"
                                labelStyle.fontWeight 700
                            ]
                        ]
                        ReactFlow.edge [
                            edge.id "e2-3"
                            edge.source "2"
                            edge.target "3"
                            edge.animated true
                            edge.label "50 MWh"
                            edge.type' EdgeType.SmoothStep
                            edge.arrowHeadType ArrowClosed
                            edge.style [ style.stroke "blue" ]
                            edge.labelStyle [
                                labelStyle.fill "blue"
                                labelStyle.fontWeight 700
                            ]
                        ]
                        ReactFlow.edge [
                            edge.id "e2-4"
                            edge.source "2"
                            edge.target "4"
                            edge.animated true
                            edge.label "55 MWh"
                            edge.type' EdgeType.SmoothStep
                            edge.arrowHeadType ArrowClosed
                            edge.style [ style.stroke "red" ]
                            edge.labelStyle [
                                labelStyle.fill "red"
                                labelStyle.fontWeight 700
                            ]
                        ]
                    |]
                    ReactFlow.onElementClick
                        (fun (x, y) ->
                            console.log y
                            window.alert "You clicked me!")
                    ReactFlow.onNodeDragStop
                        (fun (x, y) ->
                            console.log y
                            window.alert "You dragged me!")
                    ReactFlow.onElementsRemove
                        (fun (x, y) ->
                            console.log y
                            window.alert "You removed me!")
                    ReactFlow.onConnect
                        (fun (x, y) ->
                            console.log y
                            window.alert "You connected me!")
                    ReactFlow.onConnectStart
                        (fun (x, y) ->
                            console.log y
                            window.alert "You started to connect me!")
                ]
                """ ]
          fixDocsView "FelizReactFlow.ExampleFlow" false ]


// https://github.com/tforkmann/Feliz.ReactFlow/blob/main/src/Docs/views/Feliz.ReactFlow/FelizReact.ExampleFlow.fs
// https://github.com/tforkmann/Feliz.ReactFlow/blob/main/src/Docs/views/Feliz.ReactFlow/FelizReactFlow.ExampleFlow.fs
