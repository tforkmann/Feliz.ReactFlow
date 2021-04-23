namespace Feliz.ReactFlow

open Fable.Core.JsInterop
open Fable.Core
open Feliz

type Event = Browser.Types.Event

[<Erase>]
type style =
    static member inline background(background: string) = Interop.mkAttr "background" background
    static member inline color(color: string) = Interop.mkAttr "color" color
    static member inline border(border: string) = Interop.mkAttr "border" border
    static member inline width(width: int) = Interop.mkAttr "width" width
    static member inline height(heigth: int) = Interop.mkAttr "heigth" heigth
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

    static member inline node (props: INodeProp seq): IElement =
        !!(createObj !!props)

    static member inline edge (props: IEdgeProp seq): IElement =
        !!(createObj !!props)

    /// Provides the child elements in a flow.
    static member inline elements(elements: IElement array) : IReactFlowProp = !!("elements" ==> elements)

    // Because the event helpers are inlined, Fable uncurrying is not working
    // so we make the conversion to delegate (Func) explicitly

    static member inline onElementClick(handler: Event -> Element -> unit) : IReactFlowProp =
        !!("onElementClick" ==> System.Func<_,_,_>handler)

    static member inline onElementsRemove(handler: Element[] -> unit) : IReactFlowProp =
        !!("onElementsRemove" ==> handler)

    static member inline onNodeDragStart(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeDragStart" ==> System.Func<_,_,_>handler)

    static member inline onNodeDrag(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeDrag" ==> System.Func<_,_,_>handler)

    static member inline onNodeDragStop(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeDragStop" ==> System.Func<_,_,_>handler)

    static member inline onNodeMouseEnter(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeMouseEnter" ==> System.Func<_,_,_>handler)

    static member inline onNodeMouseMove(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeMouseMove" ==> System.Func<_,_,_>handler)

    static member inline onNodeMouseLeave(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeMouseLeave" ==> System.Func<_,_,_>handler)

    static member inline onNodeContextMenu(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeContextMenu" ==> System.Func<_,_,_>handler)

    static member inline onNodeDoubleClick(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeDoubleClick" ==> handler)

    static member inline onConnect(handler: {| source: Node; target: Node |} -> unit) : IReactFlowProp =
        !!("onConnect" ==> handler)

    static member inline onConnectStart(handler: Event -> {| nodeId: string; handleType: HandleType |} -> unit) : IReactFlowProp =
        !!("onConnectStart" ==> System.Func<_,_,_>handler)

    static member inline onConnectStop(handler: Event -> unit) : IReactFlowProp =
        !!("onConnectStop" ==> handler)

    static member inline onConnectEnd(handler: Event -> unit) : IReactFlowProp =
        !!("onConnectEnd" ==> handler)

    static member inline onEdgeUpdate(handler: Event -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeUpdate" ==> handler)

    static member inline onEdgeMouseEnter(handler: Event -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeMouseEnter" ==> handler)

    static member inline onEdgeMouseMove(handler: Event -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeMouseMove" ==> handler)

    static member inline onEdgeMouseLeave(handler: Event -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeMouseLeave" ==> handler)

    static member inline onEdgeContextMenu(handler: Event -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeContextMenu" ==> handler)

    //TODO: Test if that works
    static member inline onLoad(handler: unit) : IReactFlowProp =
        !!("onLoad" ==> handler)

    static member inline onMove(flowTransform: unit) : IReactFlowProp =
        !!("onMove" ==> flowTransform)

    static member inline onMoveStart(flowTransform: unit) : IReactFlowProp =
        !!("onMoveStart" ==> flowTransform)

    static member inline onMoveEnd(flowTransform: unit) : IReactFlowProp =
        !!("onMoveEnd" ==> flowTransform)

    static member inline onSelectionChange(handler: Element[] -> unit) : IReactFlowProp =
        !!("onSelectionChange" ==> handler)

    static member inline onSelectionDragStart(handler: Event -> Node [] -> unit) : IReactFlowProp =
        !!("onSelectionDragStart" ==> handler)

    static member inline onSelectionDrag(handler: Event -> Node [] -> unit) : IReactFlowProp =
        !!("onSelectionDrag" ==> handler)

    static member inline onSelectionDragStop(handler: Event -> Node [] -> unit) : IReactFlowProp =
        !!("onSelectionDragStop" ==> handler)

    static member inline onSelectionContextMenu(handler: Event -> Node [] -> unit) : IReactFlowProp =
        !!("onSelectionContextMenu" ==> handler)

    static member inline onPaneClick(handler: Event -> unit) : IReactFlowProp =
        !!("onPaneClick" ==> handler)

    static member inline onPaneContextMenu(handler: Event -> unit) : IReactFlowProp =
        !!("onPaneContextMenu" ==> handler)

    static member inline onPaneScroll(handler: Event -> unit) : IReactFlowProp =
        !!("onPaneScroll" ==> handler)

    // TODO: Rest of events: https://reactflow.dev/docs/api/component-props/
