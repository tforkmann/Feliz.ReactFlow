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

[<Erase>]
type Instance =
    abstract project: position -> position
    abstract fitView: {| padding: float ; includeHiddenNodes: bool |} -> unit
    abstract zoomIn: unit -> unit
    abstract zoomOut: unit -> unit
    abstract zoomTo: float -> unit
    abstract setTransform: {| x: int ;  y: int ; zoom: float |} -> unit
    abstract toObject: unit -> {| elements: Element list ; position: int * int ; zoom: float |}
    abstract getElements: unit -> Element list

[<Erase>]
type OnConnectParams =
    abstract source: ElementId
    abstract sourceHandle: Handle
    abstract target: ElementId
    abstract targetHandle: Handle

[<Erase>]
type OnConnectStartParams =
    abstract nodeId: string
    abstract handleType: HandleType

// The !! below is used to "unsafely" expose a prop into an IReactFlowProp.
[<Erase>]
type ReactFlow =
    /// Creates a new ReactFlow component.

    static member inline flowChart (props: IReactFlowProp seq) =
        Interop.reactApi.createElement (Interop.reactFlow, createObj !!props)

    static member inline node (props: INodeProp seq): INode =
        !!(createObj !!props)

    static member inline edge (props: IEdgeProp seq): IEdge =
        !!(createObj !!props)

    static member inline handle (props: IHandleProp seq) =
        Interop.reactApi.createElement (Interop.handle, createObj !!props)

    static member inline background (props: IBackgroundProp seq) =
        Interop.reactApi.createElement (Interop.background, createObj !!props)

    static member inline miniMap (props: IMiniMapProp seq) =
        Interop.reactApi.createElement (Interop.miniMap, createObj !!props)

    static member inline controls (props: IControlsProp seq) =
        Interop.reactApi.createElement (Interop.controls, createObj !!props)

    // Basic Props

    static member inline nodes(nodes: INode array) : IReactFlowProp = !!("nodes" ==> nodes)
    static member inline edges(edges: IEdge array) : IReactFlowProp = !!("edges" ==> edges)

    static member inline style(style: string) : IReactFlowProp =
        Interop.mkReactFlowProp "style" style

    static member inline className(className: string) : IReactFlowProp =
        Interop.mkReactFlowProp "className" className

    static member inline children (children: ReactElement list) =
        unbox<IReactFlowProp> (prop.children children)

    // Flow View

    static member inline minZoom(minZoom : float) : IReactFlowProp =
        Interop.mkReactFlowProp "minZoom" minZoom

    static member inline maxZoom(maxZoom : float) : IReactFlowProp =
        Interop.mkReactFlowProp "maxZoom" maxZoom

    static member inline defaultZoom(defaultZoom : float) : IReactFlowProp =
        Interop.mkReactFlowProp "defaultZoom" defaultZoom

    static member inline defaultPosition(x: int, y: int) : IReactFlowProp =
        Interop.mkReactFlowProp "defaultPosition" (x, y)

    static member inline snapToGrid(snapToGrid : bool) : IReactFlowProp =
        Interop.mkReactFlowProp "snapToGrid" snapToGrid

    static member inline snapGrid(x: int, y: int) : IReactFlowProp =
        Interop.mkReactFlowProp "snapGrid" (x, y)

    static member inline onlyRenderVisibleElements(onlyRenderVisibleElements : bool) : IReactFlowProp =
        Interop.mkReactFlowProp "onlyRenderVisibleElements" onlyRenderVisibleElements

    static member inline translateExtent(translateExtent : (string * string) * (string * string)) : IReactFlowProp =
        Interop.mkReactFlowProp "translateExtent" translateExtent

    static member inline nodeExtent(nodeExtent : (string * string) * (string * string)) : IReactFlowProp =
        Interop.mkReactFlowProp "nodeExtent" nodeExtent

    // Event Handlers

    // Because the event helpers are inlined, Fable uncurrying is not working
    // so we make the conversion to delegate (Func) explicitly
    static member inline onNodeClick(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeClick" ==> System.Func<_,_,_>handler)

    static member inline onEdgeClick(handler: Event -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeClick" ==> System.Func<_,_,_>handler)

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

    static member inline onNodesChange(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodesChange" ==> handler)

    static member inline onConnect(handler: OnConnectParams -> unit) : IReactFlowProp =
        !!("onConnect" ==> handler)

    static member inline onConnectStart(handler: Event -> OnConnectStartParams -> unit) : IReactFlowProp =
        !!("onConnectStart" ==> System.Func<_,_,_>handler)

    static member inline onConnectStop(handler: Event -> unit) : IReactFlowProp =
        !!("onConnectStop" ==> handler)

    static member inline onConnectEnd(handler: Event -> unit) : IReactFlowProp =
        !!("onConnectEnd" ==> handler)

    static member inline onEdgesChange(handler: Event -> Edge -> unit) : IReactFlowProp =
        !!("onEdgesChange" ==> handler)

    static member inline onEdgeMouseEnter(handler: Event -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeMouseEnter" ==> handler)

    static member inline onEdgeMouseMove(handler: Event -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeMouseMove" ==> handler)

    static member inline onEdgeMouseLeave(handler: Event -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeMouseLeave" ==> handler)

    static member inline onEdgeContextMenu(handler: Event -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeContextMenu" ==> handler)

    static member inline onEdgeUpdateStart(handler: Event -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeUpdateStart" ==> handler)

    static member inline onEdgeUpdateEnd(handler: Event -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeUpdateEnd" ==> handler)

    static member inline onInit(reactFlowInstance: Instance option -> unit) : IReactFlowProp =
        !!("onInit" ==> reactFlowInstance)

    static member inline onMove(flowTransform: unit) : IReactFlowProp =
        !!("onMove" ==> flowTransform)

    static member inline onMoveStart(flowTransform: unit) : IReactFlowProp =
        !!("onMoveStart" ==> flowTransform)

    static member inline onMoveEnd(flowTransform: unit) : IReactFlowProp =
        !!("onMoveEnd" ==> flowTransform)

    static member inline onSelectionChange(handler: Element [] -> unit) : IReactFlowProp =
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

    // Interaction

    static member inline nodesDraggable(nodesDraggable : bool) : IReactFlowProp =
        Interop.mkReactFlowProp "nodesDraggable" nodesDraggable

    static member inline nodesConnectable(nodesConnectable : bool) : IReactFlowProp =
        Interop.mkReactFlowProp "nodesConnectable" nodesConnectable

    static member inline elementsSelectable(elementsSelectable : bool) : IReactFlowProp =
        Interop.mkReactFlowProp "elementsSelectable" elementsSelectable

    static member inline zoomOnScroll(zoomOnScroll : bool) : IReactFlowProp =
        Interop.mkReactFlowProp "zoomOnScroll" zoomOnScroll

    static member inline zoomOnPinch(zoomOnPinch : bool) : IReactFlowProp =
        Interop.mkReactFlowProp "zoomOnPinch" zoomOnPinch

    static member inline panOnScroll(panOnScroll : bool) : IReactFlowProp =
        Interop.mkReactFlowProp "panOnScroll" panOnScroll

    static member inline panOnScrollSpeed(panOnScrollSpeed : float) : IReactFlowProp =
        Interop.mkReactFlowProp "panOnScrollSpeed" panOnScrollSpeed

    static member inline panOnScrollMode(panOnScrollMode : ScrollMode) : IReactFlowProp =
        Interop.mkReactFlowProp "panOnScrollMode" panOnScrollMode

    static member inline zoomOnDoubleClick(zoomOnDoubleClick : bool) : IReactFlowProp =
        Interop.mkReactFlowProp "zoomOnDoubleClick" zoomOnDoubleClick

    static member inline selectNodesOnDrag(selectNodesOnDrag : bool) : IReactFlowProp =
        Interop.mkReactFlowProp "selectNodesOnDrag" selectNodesOnDrag

    static member inline paneMoveable(paneMoveable : bool) : IReactFlowProp =
        Interop.mkReactFlowProp "paneMoveable" paneMoveable

    static member inline connectionMode(connectionMode : ConnectionMode) : IReactFlowProp =
        Interop.mkReactFlowProp "connectionMode" connectionMode

    // Element customization

    static member inline nodeTypes(nodeTypes: obj) : IReactFlowProp = !!("nodeTypes" ==> nodeTypes)

    static member inline edgeTypes(edgeTypes: obj) : IReactFlowProp = !!("edgeTypes" ==> edgeTypes)

    static member inline arrowHeadColor(arrowHeadColor : string) : IReactFlowProp =
        Interop.mkReactFlowProp "arrowHeadColor" arrowHeadColor

    static member inline markerEndId(markerEndId : string) : IReactFlowProp =
        Interop.mkReactFlowProp "markerEndId" markerEndId

    // Connection Line Options

    static member inline connectionLineType(connectionLineType: ConnectionLineType) : IReactFlowProp =
        Interop.mkReactFlowProp "connectionLineType" connectionLineType

    static member inline connectionLineStyle(connectionLineStyle: Fable.React.Props.SVGAttr []) : IReactFlowProp =
        Interop.mkReactFlowProp "connectionLineStyle" connectionLineStyle

    static member inline connectionLineComponent(connectionLineComponent: string) : IReactFlowProp =
        Interop.mkReactFlowProp "connectionLineComponent" connectionLineComponent

    // Keys

    static member inline deleteKeyCode(deleteKeyCode: string) : IReactFlowProp =
        Interop.mkReactFlowProp "deleteKeyCode" deleteKeyCode
    static member inline deleteKeyCode(deleteKeyCode: int) : IReactFlowProp =
        Interop.mkReactFlowProp "deleteKeyCode" deleteKeyCode

    static member inline selectionKeyCode(selectionKeyCode: string) : IReactFlowProp =
        Interop.mkReactFlowProp "selectionKeyCode" selectionKeyCode
    static member inline selectionKeyCode(selectionKeyCode: int) : IReactFlowProp =
        Interop.mkReactFlowProp "selectionKeyCode" selectionKeyCode

    static member inline multiSelectionKeyCode(multiSelectionKeyCode: string) : IReactFlowProp =
        Interop.mkReactFlowProp "multiSelectionKeyCode" multiSelectionKeyCode
    static member inline multiSelectionKeyCode(multiSelectionKeyCode: int) : IReactFlowProp =
        Interop.mkReactFlowProp "multiSelectionKeyCode" multiSelectionKeyCode
    static member inline zoomActivationKeyCode(zoomActivationKeyCode: string) : IReactFlowProp =
        Interop.mkReactFlowProp "zoomActivationKeyCode" zoomActivationKeyCode
    static member inline zoomActivationKeyCode(zoomActivationKeyCode: int) : IReactFlowProp =
        Interop.mkReactFlowProp "zoomActivationKeyCode" zoomActivationKeyCode
