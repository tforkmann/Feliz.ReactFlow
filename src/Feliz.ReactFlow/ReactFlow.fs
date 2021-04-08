namespace Feliz.ReactFlow

open Fable.Core.JsInterop
open Fable.Core
open Feliz

[<Erase>]
type style =
    static member inline background(background: string) = Interop.mkAttr "background" background
    static member inline color(color: string) = Interop.mkAttr "color" color
    static member inline border(border: string) = Interop.mkAttr "border" border
    static member inline width(width: int) = Interop.mkAttr "width" width
    static member inline stroke(stroke: string) = Interop.mkAttr "stroke" stroke

[<Erase>]
type labelStyle =
    static member inline fill(fill: string) = Interop.mkAttr "fill" fill
    static member inline fontWeight(fontWeight: int) = Interop.mkAttr "fontWeight" fontWeight





// The !! below is used to "unsafely" expose a prop into an IReactFlowProp.
[<Erase>]
type ReactFlow =
    /// Creates a new ReactFlow component.
    static member inline flowChart(props: IReactFlowProp seq) =
        Interop.reactApi.createElement (Interop.reactFlow, createObj !!props)

    static member inline node props =
        Interop.objectAssign obj (createObj !!props)

    static member inline edge props =
        Interop.objectAssign obj (createObj !!props)
    /// Provides the child elements in a flow.
    static member inline elements(elements: obj array) : IReactFlowProp = !!("elements" ==> elements)

    static member inline onElementClick(handler: (obj * obj) -> unit) : IReactFlowProp =
        !!("onConnectStart" ==> Interop.funcToTuple handler)

    static member inline onConnect(handler: (obj * obj) -> unit) : IReactFlowProp =
        !!("onConnect" ==> Interop.funcToTuple handler)

    static member inline onConnectStart(handler: (obj * obj) -> unit) : IReactFlowProp =
        !!("onConnectStart" ==> Interop.funcToTuple handler)

    static member inline onNodeDragStop(handler: (obj * obj) -> unit) : IReactFlowProp =
        !!("onNodeDragStop" ==> Interop.funcToTuple handler)

    static member inline onNodeMouseEnter(handler: (obj * obj) -> unit) : IReactFlowProp =
        !!("onNodeMouseEnter" ==> Interop.funcToTuple handler)

    static member inline onElementsRemove(handler: (obj * obj) -> unit) : IReactFlowProp =
        !!("onElementsRemove" ==> Interop.funcToTuple handler)
