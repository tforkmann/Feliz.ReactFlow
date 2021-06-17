# Feliz Binding for [ReactFlow](https://reactflow.dev/)

[![Feliz.ReactFlow on Nuget](https://buildstats.info/nuget/Feliz.ReactFlow)](https://www.nuget.org/packages/Feliz.ReactFlow/)


## Installation
Install the nuget package
```
dotnet paket add Feliz.ReactFlow
```

and install the npm package

```
npm install --save react-flow-renderer
```

or use Femto:
```
femto install Feliz.ReactFlow
```

## Start test app

- Start your test app by cloning this repository and then execute:
```
dotnet run
```

## Example ReactFlow
Here is an example ReactFlow
```fs
div [ Props.Style [
              Props.CSSProp.Height 1000
          ] ] [
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
                    node.data {| label = "Test" |}
                    node.position (50, 120)
                    node.style [
                        style.background "lightgreen"
                        style.border "1px solid black"
                        style.width 180
                    ]
                ]
                ReactFlow.edge [
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
                ]
            |]
            ReactFlow.onElementClick
                (fun ev element ->
                    console.log ev
                    window.alert "You clicked me!")
            ReactFlow.onNodeDragStop
                (fun ev node ->
                    console.log ev
                    window.alert "You dragged me!")
            ReactFlow.onElementsRemove
                (fun elements ->
                    console.log elements
                    window.alert "You removed me!")
            ReactFlow.onConnect
                (fun ev ->
                    console.log ev
                    window.alert "You connected me!")
            ReactFlow.onConnectStart
                (fun ev nodeId ->
                    console.log ev
                    window.alert "You started to connect me!")
        ]
    ]
```
