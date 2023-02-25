module Index

open System
open Elmish
open Fable.Core.JsInterop
open Fable.React
open Feliz
open Feliz.ReactFlow
open Browser.Dom

type FlowElement = { Id: string; Descr: string }


type Model =
    { NodeList: Node list
      EdgeList: Edge list }

type Msg =
    | AddFlowElement of FlowElement
    | AddEdge of Connection


let initNodes: Node list =
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
          node.position (400, 30)
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
          node.position (300, 200)
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
          node.position (500, 200)
      ]

      ReactFlow.node [
          node.id "5"
          node.nodetype (Custom "test")
          node.data {| label = "Label from Node" |}
          node.position (50, 120)
          node.style [
              style.background "lightgreen"
              style.border "1px solid black"
              style.width 180
          ]
      ]
      ReactFlow.node [
          node.id "6"
          node.nodetype Output
          node.data {| label = "Unconnected" |}
          node.style [
              style.background "green"
              style.color "white"
              style.border "1px solid #222138"
              style.width 180
          ]
          node.position (700, 200)
      ] ]

let initEdges =
    [ ReactFlow.edge [
          edge.id "e1-2"
          edge.source "1"
          edge.target "2"
          edge.animated false
          edge.label "100 MWh"
          edge.edgeType SmoothStep
          edge.markerEnd(MarkerType.ArrowClosed)
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
          edge.markerEnd ArrowClosed
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
          edge.markerEnd ArrowClosed
          edge.style [ style.stroke "red" ]
          edge.labelStyle [
              labelStyle.fill "red"
              labelStyle.fontWeight 700
          ]
      ]
      ReactFlow.edge [
          edge.id "e1-6"
          edge.source "1"
          edge.target "5"
          edge.targetHandle "7"
          edge.edgeType SmoothStep
          edge.style [ style.stroke "black" ]
      ] ]

let init () =
    { NodeList = initNodes
      EdgeList = initEdges },
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
        node.position (700, 50)
    ]

let createEdge (connection: Connection) =
    let id = new Guid()

    (connection.source, connection.target) ||> Option.map2 (fun source target ->
        ReactFlow.edge [
            edge.id (id.ToString())
            edge.source source
            edge.target target
            edge.animated true
            edge.label "50 MWh"
            edge.edgeType SmoothStep
            edge.markerEnd ArrowClosed
            edge.style [ style.stroke "blue" ]
            edge.labelStyle [
                labelStyle.fill "blue"
                labelStyle.fontWeight 700
            ]
        ]
    )

let update msg (model: Model) =
    match msg with
    | AddFlowElement flowElement ->
        let newNodes =
            List.concat [
                model.NodeList
                [ createNode flowElement ]
            ]

        { model with NodeList = newNodes }, Cmd.none
    | AddEdge param ->
        let newEdges =
            match createEdge param with
            | None -> model.EdgeList
            | Some newEdge -> [ yield! model.EdgeList; newEdge ]

        { model with EdgeList = newEdges }, Cmd.none

[<ReactComponent>]
let Counter
    (props: {| data: {| label: string |}
               isConnectable: bool |})
    ()
    =
    let (count, setCount) = React.useState (0)

    Html.div [
        prop.style [ style.padding 10 ]
        prop.children [
            ReactFlow.handle [
                handle.``type`` Target
                handle.id "6"
                handle.position Top
            ]
            ReactFlow.handle [
                handle.``type`` Target
                handle.id "7"
                handle.position Left
            ]
            Html.button [
                prop.classes [Styles.classes.nodrag]
                prop.style [ style.marginRight 5 ]
                prop.onClick (fun ev ->
                    ev.preventDefault()
                    ev.stopPropagation()
                    setCount (count + 1))
                prop.text "Increment"
            ]
            Html.text props.data.label
            Html.text count
            ]
    ]


let view (model: Model) (dispatch: Msg -> unit) =
    do importSideEffects "reactflow/dist/style.css"
    let gridSize = 20

    div [ Props.Style [ Props.CSSProp.Height 800 ] ] [
        ReactFlow.flowChart [
            ReactFlow.nodeTypes {| test = Counter |}
            ReactFlow.snapGrid (gridSize, gridSize)
            ReactFlow.snapToGrid true
            ReactFlow.defaultNodes (Array.ofList model.NodeList)
            ReactFlow.defaultEdges (Array.ofList model.EdgeList)

            ReactFlow.onNodeClick (fun ev element ->
                console.log ev
                window.alert "You clicked me!")
            ReactFlow.onNodeDragStop (fun ev node nodes ->
                console.log ev
                window.alert $"%A{node.id}: You dragged me!")
            ReactFlow.onNodesChange (fun changes ->
                let removedNodes = [|
                    for change in changes do
                        match change with
                        | NodeChange.NodeRemoveChange remove ->
                            if remove.``type`` = "remove" then
                                window.alert "You removed me!"
                                remove.id
                        | _ -> ()
                |]
                if removedNodes |> Array.isEmpty |> not then
                    console.log("Nodes removed: ", removedNodes)
            )
                    
            ReactFlow.onConnect (fun connection ->
                window.alert "Adding new edge"
                connection |> AddEdge |> dispatch)
            // ReactFlow.onConnectStart
            //     (fun ev nodeId ->
            //         console.log ev
            //         window.alert "You started to connect me!")
            // ReactFlow.onConnectEnd
            //     (fun ev ->
            //         console.log ev
            //         window.alert "You stopped to connect me!")
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