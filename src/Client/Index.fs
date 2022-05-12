module Index

open Elmish
open Fable.React
open Feliz
open Feliz.ReactFlow
open Browser.Dom

type FlowElement = { Id: string; Descr: string }


type Model =
    { EdgeList: IEdge list
      NodeList: INode list }

type Msg = AddFlowElement of FlowElement





let initNodes: INode list =
    [ ReactFlow.node [
          node.id "1"
          node.nodetype Input
          node.data {| label = "Erdgas Einsatz" |}
          node.style [
              style.background "yellow"
              style.color "#332"
              style.border "1px solid #222138"
              style.width 180
          ]
          node.position (50, 30)
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
      ] ]

let initEdges: IEdge list =
    [ ReactFlow.edge [
          edge.id "e1-2"
          edge.source "1"
          edge.target "2"
          edge.animated false
          edge.label "100 MWh"
          edge.edgeType SmoothStep
          edge.arrowHeadType ArrowClosed
          edge.style [ style.stroke "blue" ]
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
          edge.edgeType SmoothStep
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
          edge.edgeType SmoothStep
          edge.arrowHeadType ArrowClosed
          edge.style [ style.stroke "red" ]
          edge.labelStyle [
              labelStyle.fill "red"
              labelStyle.fontWeight 700
          ]
      ]
      ReactFlow.edge [
          edge.id "e1-5"
          edge.source "1"
          edge.target "5"
          edge.edgeType SmoothStep
          edge.style [ style.stroke "black" ]
      ] ]


let init () =
    { EdgeList = initEdges
      NodeList = initNodes },
    Cmd.none




let createNode (flowElement: FlowElement) =
    ReactFlow.node [
        node.id flowElement.Id
        node.nodetype Default
        node.data {| label = flowElement.Descr |}
        node.style [
            style.background "red"
            style.color "white"
            style.border "1px solid #222138"
            style.width 180
        ]
        node.position (250, 0)
    ]

let update msg (model: Model) =
    match msg with
    | AddFlowElement flowElement ->
        let newNodes =
            List.concat [
                model.NodeList
                [ createNode flowElement ]
            ]

        { model with NodeList = newNodes }, Cmd.none

[<ReactComponent>]
let Counter () =
    let (count, setCount) = React.useState (0)

    Html.div [
        prop.style [ style.padding 10 ]
        prop.children [
            ReactFlow.handle [
                handle.``type`` Target
                handle.position Top
            ]
            Html.button [
                prop.style [ style.marginRight 5 ]
                prop.onClick (fun _ -> setCount (count + 1))
                prop.text "Increment"
            ]
            Html.text count
        ]
    ]


let view (model: Model) (dispatch: Msg -> unit) =
    let gridSize = 20

    div [ Props.Style [ Props.CSSProp.Height 800 ] ] [
        ReactFlow.flowChart [
            // ReactFlow.nodeTypes {| test = Counter |}
            ReactFlow.snapGrid (gridSize, gridSize)
            ReactFlow.snapToGrid true
            ReactFlow.edges [|
                yield! model.EdgeList
            |]
            ReactFlow.nodes [|
                yield! model.NodeList

                |]
            ReactFlow.onNodeClick
                (fun ev node ->
                    console.log ev
                    window.alert "You clicked me!")
            ReactFlow.onNodesChange
                (fun nodes ->
                    console.log nodes
                    // window.alert "You changed me!"
                    )
            ReactFlow.onEdgesChange
                (fun nodes ->
                    console.log nodes
                    // window.alert "You changed me!"
                    )
            ReactFlow.onNodeDragStop
                (fun ev node ->
                    console.log ev
                    window.alert "You dragged me!"
                    )
            ReactFlow.onNodesRemove
                (fun nodes ->
                    console.log nodes
                    window.alert "You removed me!")
            ReactFlow.onConnect
                (fun ev ->
                    console.log ev
                    window.alert "You connected me!")
            ReactFlow.onConnectStart
                (fun ev nodeId ->
                    console.log ev
                    window.alert "You started to connect me!")
            ReactFlow.children [
                ReactFlow.background [
                    background.gap gridSize
                    background.size 1.
                    background.variant Dots
                    background.color "lightgrey"
                ]
                ReactFlow.miniMap [
                    miniMap.nodeColor "lightgreen"
                    miniMap.maskColor "gray"
                ]
                ReactFlow.controls [
                    controls.onZoomIn (fun () -> console.log ("Zoomed in"))
                    controls.onZoomOut (fun () -> console.log ("Zoomed out"))
                    controls.onInteractiveChange (fun status -> console.log ($"Locked: {not status}"))
                ]
            ]
        ]
    ]