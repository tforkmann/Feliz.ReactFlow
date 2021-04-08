module Index

open Elmish
open Fable.React
open Feliz.ReactFlow
open Browser.Dom

type Model = obj
type Msg = obj

let init () = obj (), Cmd.none

let update msg model = model, Cmd.none

// Create data using anonymous record syntax here, but you can also use standard records
// let elements =
//     [|
//        box
//         {  id = "1"
//            ``type`` = Input.Value
//            data = {| label = "An Input Element with Custom Style" |}
//            position = { x = 250; y = 5 }
//            style =
//                Some
//                    {  background = "#D6D5E6"
//                       color = "#333"
//                       border = "1px solid #222138"
//                       width = 180 } }
//        box
//            {  id = "2"
//               ``type`` = Output.Value
//               data = {| label = "An Output Element" |}
//               style =
//                None
//               position = { x = 100; y = 100 } }
//        box
//            {  id = "e1-2"
//               source = "1"
//               target = "2"
//               animated = true
//               label = "ConnectionLabel with Custom LableStyle"
//               ``type`` = Bezier.Value
//               arrowHeadType = Some ArrowClosed.Value
//               style = Some (box {| stroke = "#f6ab6c" |})
//               labelStyle = Some { fill = "#f6ab6c"; fontWeight = 700 } }
//               |]

let view (model: Model) (dispatch: Msg -> unit) =
    div [ Props.Style [
              Props.CSSProp.Height 1000
          ] ] [
        ReactFlow.flowChart [
            ReactFlow.elements [|
                ReactFlow.node [
                    node.id "1"
                    node.nodetype Input
                    node.data {| label = "An Input Element with Custom Style" |}
                    node.style [
                      style.background "#D6D5E6"
                      style.color  "#333"
                      style.border "1px solid #222138"
                      style.width 180
                      ]
                    node.position (250,5)
                ]
                ReactFlow.node [
                    node.id "2"
                    node.nodetype Output
                    node.data {| label = "An Output Element" |}
                    node.position (100,100)
                ]
                ReactFlow.edge [
                    edge.id "e1-2"
                    edge.source "1"
                    edge.target "2"
                    edge.animated true
                    edge.label "ConnectionLabel with Custom LableStyle"
                    edge.edgeType Bezier
                    edge.arrowHeadType ArrowClosed
                    edge.style [
                        style.stroke "#f6ab6c"
                    ]
                    edge.labelStyle [
                        labelStyle.fill "#f6ab6c"
                        labelStyle.fontWeight 700
                    ]
                ]
                |]
                // elements
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
    ]
