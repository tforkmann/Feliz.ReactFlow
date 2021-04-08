module Feliz.ReactFlow

open Fable.Core.JsInterop
open Fable.Core
open Feliz

let reactFlow : obj = importDefault "react-flow-renderer" // import the top-level ReactFlow element

let removeElements : obj =
    import "removeElements" "react-flow-renderer" // a child of specific modules - not needed for this demo, but as an example

let addEdge : obj = import "addEdge" "react-flow-renderer"

[<Erase>]
/// This interface allows us to stop adding random props to the react flow.
type IReactFlowProp =
    interface
    end

[<Erase>]
type INodeProp =
    interface
    end

[<Erase; RequireQualifiedAccess>]
module Interop =
    [<Emit("Object.keys($0)")>]
    let internal objectKeys (x: obj) = jsNative

    let objectHas (keys: string list) (x: obj) =
        objectKeys (x) |> Seq.toList |> (=) keys

    let inline mkNodeAttr (key: string) (value: obj) : INodeProp = unbox (key, value)

type position = { x: int; y: int }

// Some sample types you can use for setting properties on elements.
type EdgeType =
    | Bezier
    | Straight
    | Step
    | SmoothStep
    member this.Value = this.ToString().ToLower()

type ArrowHead =
    | Arrow
    | ArrowClosed
    member this.Value = this.ToString().ToLower()

type NodeType =
    | Input
    | Output
    | Default
    member this.Value = this.ToString().ToLower()



[<Erase>]
type style =
    static member inline background (background:string)=
        Interop.mkAttr "background" background
    static member inline color (color:string)=
        Interop.mkAttr "color" color
    static member inline border (border:string)=
        Interop.mkAttr "border" border
    static member inline width(width: int) =
        Interop.mkAttr "width" width
    static member inline stroke(stroke: string) =
        Interop.mkAttr "stroke" stroke

[<Erase>]
type labelStyle =
    static member inline fill (fill:string)=
        Interop.mkAttr "fill" fill
    static member inline fontWeight (fontWeight:int)=
        Interop.mkAttr "fontWeight" fontWeight

[<Erase>]
type node =
    static member inline position(x: int,y: int) =
        Interop.mkAttr "position" [| x; y |]
    static member inline nodetype(nodeType: NodeType) =
        Interop.mkAttr "type" nodeType.Value
    static member inline data(data: obj) =
        Interop.mkAttr "data" data
    static member inline style props =
        Interop.mkAttr "style" (createObj !!props)
    static member inline id(id: string) =
        Interop.mkAttr "id" id

[<Erase>]
type edge =
    static member inline source(source:string) =
        Interop.mkAttr "source" source
    static member inline target(target: string) =
        Interop.mkAttr "target" target
    static member inline animated(animated:bool) =
        Interop.mkAttr "animated" animated
    static member inline arrowHeadType(arrowHeadType:ArrowHead) =
        Interop.mkAttr "arrowHeadType" arrowHeadType.Value
    static member inline label(label: obj) =
        Interop.mkAttr "label" label
    static member inline edgeType(edgeType: EdgeType) =
        Interop.mkAttr "type" edgeType.Value
    static member inline labelStyle props =
        Interop.mkAttr "labelStyle" (createObj !!props)
    static member inline id(id: string) =
        Interop.mkAttr "id" id
    static member inline style props =
        Interop.mkAttr "style" (createObj !!props)

let funcToTuple handler =
    System.Func<_, _, _>(fun a b -> handler (a, b))

// The !! below is used to "unsafely" expose a prop into an IReactFlowProp.
[<Erase>]
type ReactFlow =
    /// Creates a new ReactFlow component.
    static member inline flowChart(props: IReactFlowProp seq) =
        Interop.reactApi.createElement (reactFlow, createObj !!props)
    static member inline node props =
        Interop.mkAttr "node" (createObj !!props)
    static member inline edge props =
        Interop.mkAttr "edge" (createObj !!props)

        // ("node" ==> props)
        // "node" ==> (unbox props)
        // prop.custom("node",props)
        // printfn "props %A" props
        // printfn "obj %A" (createObj !!props)
        // Interop.reactApi.createElement (reactFlow, createObj !!props)
    /// Provides the child elements in a flow.
    static member inline elements(elements: _ array) : IReactFlowProp =
        !!("elements" ==> elements)

    static member inline onElementClick(handler: (obj * obj) -> unit) : IReactFlowProp =
        !!("onConnectStart" ==> funcToTuple handler)

    static member inline onConnect(handler: (obj * obj) -> unit) : IReactFlowProp =
        !!("onConnect" ==> funcToTuple handler)

    static member inline onConnectStart(handler: (obj * obj) -> unit) : IReactFlowProp =
        !!("onConnectStart" ==> funcToTuple handler)

    static member inline onNodeDragStop(handler: (obj * obj) -> unit) : IReactFlowProp =
        !!("onNodeDragStop" ==> funcToTuple handler)

    static member inline onNodeMouseEnter(handler: (obj * obj) -> unit) : IReactFlowProp =
        !!("onNodeMouseEnter" ==> funcToTuple handler)

    static member inline onElementsRemove(handler: (obj * obj) -> unit) : IReactFlowProp =
        !!("onElementsRemove" ==> funcToTuple handler)
