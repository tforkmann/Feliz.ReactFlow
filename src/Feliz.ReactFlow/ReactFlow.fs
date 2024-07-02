namespace Feliz.ReactFlow

open Fable.Core.JsInterop
open Fable.Core
open Feliz

type Event = Browser.Types.Event
type MouseEvent = Browser.Types.MouseEvent

type [<AllowNullLiteral>] ReactFlowJsonObject =
    abstract nodes: Node[] with get, set
    abstract edges: Edge[] with get, set
    abstract viewport: Viewport with get, set


type [<AllowNullLiteral>] ReactFlowJsonObject<'NodeData, 'EdgeData> =
    abstract nodes: TypedDataNode<'NodeData>[] with get, set
    abstract edges: TypedDataEdge<'EdgeData>[] with get, set
    abstract viewport: Viewport with get, set


type [<AllowNullLiteral>] ViewportHelperFunctionOptions =
    abstract duration: float option with get, set

type [<AllowNullLiteral>] SetCenterOptions =
    abstract duration: float option with get, set
    abstract zoom: float option with get, set


type [<AllowNullLiteral>] FitViewOptions =
    abstract padding: float option with get, set
    abstract includeHiddenNodes: bool option with get, set
    abstract minZoom: float option with get, set
    abstract maxZoom: float option with get, set
    abstract duration: float option with get, set
    abstract nodes: obj[] option with get, set


type [<AllowNullLiteral>] FitBoundsOptions =
    abstract duration: float option with get, set
    abstract padding: float option with get, set


[<Erase>]
type Instance =
    /// Transforms pixel coordinates to the internal ReactFlow coordinate system.
    /// This can be used when you drag nodes (from a side bar for example) and need the internal position on the pane.
    [<System.Obsolete "This function is deprecated and will be removed in v12. Please use `screenToFlowPosition` instead. When using `screenToFlowPosition`, you do not need to subtract the react flow bounds anymore.">]
    abstract project: XYPosition -> XYPosition
    abstract screenToFlowPosition: XYPosition -> XYPosition
    abstract flowToScreenPosition: XYPosition -> XYPosition
    /// Fit the view to the nodes on the pane. `padding` is `0.1` and `includeHiddenNodes` is `false` by default.
    abstract fitView: ?options: FitViewOptions -> unit
    /// Fits the view to the passed bounds (object with width x, y, width and height: `{ x: 0, y: 0, width: 100, height: 100 }`).
    abstract fitBounds: bounds: Rect * ?options: FitBoundsOptions -> unit

    abstract zoomIn: ?options: ViewportHelperFunctionOptions -> unit
    abstract zoomOut: ?options: ViewportHelperFunctionOptions -> unit
    /// Zoom to passed zoom level.
    abstract zoomTo: zoomLevel: float * ?options: ViewportHelperFunctionOptions -> unit
    /// Return the current zoom level.
    abstract getZoom: unit -> float

    /// Set the center to the passed params. If no zoom is passed, `maxZoom` is used.
    abstract setCenter: x: float * y: float * ?options: SetCenterOptions -> unit
    abstract setViewport: Viewport -> unit
    abstract getViewport : unit -> Viewport
    /// Boolean property to determine if React Flow has been initialized with all its event listeners.
    abstract viewportInitialized: bool

    /// Return nodes, edges and viewport.
    abstract toObject: unit -> ReactFlowJsonObject

    /// Returns all nodes that intersect with the passed node. Optionally you can pass a set of nodes if you don't want to check all nodes.
    abstract getIntersectingNodes: node: Node * ?partially: bool * ?nodes: Node[] -> Node[]
    /// Returns all nodes that intersect with the passed node. Optionally you can pass a set of nodes if you don't want to check all nodes.
    abstract getIntersectingNodes: rect: Rect * ?partially: bool * ?nodes: Node[] -> Node[]
    /// Returns `true` if the passed node intersects with the passed area.
    abstract isNodeIntersecting: node: Node * area: Rect * ?partially: bool -> bool
    /// Returns `true` if the passed node intersects with the passed area.
    abstract isNodeIntersecting: rect: Rect * area: Rect * ?partially: bool -> bool

    abstract getNode: id: string -> Node option
    abstract getEdge: id: string -> Edge option

    abstract getNodes: unit -> Node []
    abstract getEdges: unit -> Edge []

    abstract setNodes: nodes: Node[] -> unit
    abstract setNodes: nodes: (Node[] -> Node[]) -> unit

    abstract setEdges: edges: Edge[] -> unit
    abstract setEdges: edges: (Edge[] -> Edge[]) -> unit

    abstract addNodes: node: Node -> unit
    abstract addNodes: nodes: Node[] -> unit

    abstract addEdges: edge: Edge -> unit
    abstract addEdges: edges: Edge[] -> unit

    /// (⚠ Is available from version 11.2 onwards ⚠).
    /// Deletes the passed nodes and edges. All connected edges of the passed nodes get deleted automatically.
    abstract deleteElements: nodesAndEdges: {| nodes: Node[] option; edges: Edge[] option |} -> unit


[<Erase>]
type OnConnectStartParams =
    abstract nodeId: string option
    abstract handleId : string option
    abstract handleType: HandleType option

type [<AllowNullLiteral>] OnSelectionChangeParams =
    abstract nodes: Node[]
    abstract edges: Edge[]

// The !! below is used to "unsafely" expose a prop into an IReactFlowProp.
[<Erase>]
type ReactFlow =
    /// Creates a new ReactFlow component.
    static member inline reactFlow (props: #seq<IReactFlowProp>) =
        Interop.reactApi.createElement (importDefault PackageNames.ReactFlow, createObj !!props)

    static member inline reactFlowProvider (children: ReactElement) =
        Interop.reactApi.createElement (import ImportNames.ReactFlowProvider PackageNames.ReactFlow, {| children = children |})

    static member inline node (props: INodeProp seq): Node =
        !!(createObj !!props)

    static member inline edge (props: IEdgeProp seq): Edge =
        !!(createObj !!props)

    static member inline handle (props: IHandleProp seq) =
        Interop.reactApi.createElement (import ImportNames.Handle PackageNames.ReactFlow, createObj !!props)

    static member inline background (props: IBackgroundProp seq) =
        Interop.reactApi.createElement (import ImportNames.Background PackageNames.ReactFlow, createObj !!props)

    static member inline miniMap (props: IMiniMapProp seq) =
        Interop.reactApi.createElement (import ImportNames.MiniMap PackageNames.ReactFlow, createObj !!props)

    static member inline controlButton (props: seq<#IReactProperty>) =
        Interop.reactApi.createElement (import ImportNames.ControlButton PackageNames.ReactFlow, createObj !!props)

    static member inline controls (props: seq<#IReactProperty>) =
        Interop.reactApi.createElement (import ImportNames.Controls PackageNames.ReactFlow, createObj !!props)

    static member inline nodeResizer (props: seq<INodeResizerProp>) =
        Interop.reactApi.createElement (import ImportNames.NodeResizer PackageNames.ReactFlow, createObj !!props)

    static member inline panel (props: seq<#IReactProperty>) =
        Interop.reactApi.createElement (import ImportNames.Panel PackageNames.ReactFlow, createObj !!props)

    static member inline nodeToolbar (props: seq<INodeToolbarProp>) =
        Interop.reactApi.createElement (import ImportNames.NodeToolbar PackageNames.ReactFlow, createObj !!props)

    // Basic Props

    static member inline nodes(nodes: Node array) : IReactFlowProp = !!("nodes" ==> nodes)
    static member inline edges(edges: Edge array) : IReactFlowProp = !!("edges" ==> edges)

    static member inline defaultNodes(nodes: Node array) : IReactFlowProp = !!("defaultNodes" ==> nodes)
    static member inline defaultEdges(edges: Edge array) : IReactFlowProp = !!("defaultEdges" ==> edges)

    static member inline nodeOrigin (xyValues: (float * float)) : IReactFlowProp =
        Interop.mkReactFlowProp "nodeOrigin" xyValues

    /// With a threshold greater than zero you can delay node drag events.
    /// If threshold equals 1, you need to drag the node 1 pixel before a drag event is fired.
    /// Default: 0.
    static member inline nodeDragThreshold (value: float) =
        Interop.mkReactFlowProp "nodeDragThreshold" value

    static member inline style(styleProps: #seq<IStyleAttribute>) : IReactFlowProp =
        Interop.mkReactFlowProp "style" (createObj !!styleProps)

    static member inline className(className: string) : IReactFlowProp =
        Interop.mkReactFlowProp "className" className

    /// The content of the component. Suitable for adding React Flow components such as Controls, MiniMap, Panel.
    static member inline children (element: ReactElement) = Interop.mkReactFlowProp "children" element
    /// The content of the component. Suitable for adding React Flow components such as Controls, MiniMap, Panel.
    static member inline children (elements: seq<ReactElement>) = Interop.mkReactFlowProp "children" elements

    // Flow View

    static member inline minZoom(minZoom : float) : IReactFlowProp =
        Interop.mkReactFlowProp "minZoom" minZoom

    static member inline maxZoom(maxZoom : float) : IReactFlowProp =
        Interop.mkReactFlowProp "maxZoom" maxZoom

    static member inline defaultViewport(x: float, y: float, zoom: float) : IReactFlowProp =
        jsOptions<Viewport>(fun v -> v.x <- x; v.y <- y; v.zoom <- zoom)
        |> Interop.mkReactFlowProp "defaultPosition"

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

    static member inline onNodesChange (handler: NodeChange [] -> unit) =
        Interop.mkReactFlowProp "onNodesChange" handler

    static member inline onEdgesChange (handler: EdgeChange [] -> unit) =
        Interop.mkReactFlowProp "onEdgesChange" handler

    static member inline onNodeClick(handler: MouseEvent -> Node -> unit) : IReactFlowProp =
        !!("onNodeClick" ==> System.Func<_,_,_>handler)

    static member inline onEdgeClick(handler: MouseEvent -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeClick" ==> System.Func<_,_,_>handler)

    static member inline onEdgeDoubleClick(handler: MouseEvent -> Edge -> unit) : IReactFlowProp =
        Interop.mkReactFlowProp "onEdgeDoubleClick" (System.Func<_,_,_>handler)

    static member inline onNodeDragStart(handler: MouseEvent -> Node -> Node [] -> unit) : IReactFlowProp =
        !!("onNodeDragStart" ==> System.Func<_,_,_,_>handler)

    static member inline onNodeDrag(handler: MouseEvent -> Node -> Node [] -> unit) : IReactFlowProp =
        !!("onNodeDrag" ==> System.Func<_,_,_,_>handler)

    static member inline onNodeDragStop(handler: MouseEvent -> Node -> Node [] -> unit) : IReactFlowProp =
        !!("onNodeDragStop" ==> System.Func<_,_,_,_>handler)

    static member inline onNodeMouseEnter(handler: MouseEvent -> Node -> unit) : IReactFlowProp =
        !!("onNodeMouseEnter" ==> System.Func<_,_,_>handler)

    static member inline onNodeMouseMove(handler: MouseEvent -> Node -> unit) : IReactFlowProp =
        !!("onNodeMouseMove" ==> System.Func<_,_,_>handler)

    static member inline onNodeMouseLeave(handler: MouseEvent -> Node -> unit) : IReactFlowProp =
        !!("onNodeMouseLeave" ==> System.Func<_,_,_>handler)

    static member inline onNodeContextMenu(handler: MouseEvent -> Node -> unit) : IReactFlowProp =
        !!("onNodeContextMenu" ==> System.Func<_,_,_>handler)

    static member inline onNodeDoubleClick(handler: MouseEvent -> Node -> unit) : IReactFlowProp =
        !!("onNodeDoubleClick" ==> System.Action<_,_> handler)

    /// When a connection line is completed and two nodes are connected by the user, this event fires with the new connection.
    /// You can use the addEdge utility to convert the connection to a complete edge.
    static member inline onConnect(handler: Connection -> unit) : IReactFlowProp =
        !!("onConnect" ==> handler)

    static member inline onConnectStart(handler: MouseEvent -> OnConnectStartParams -> unit) : IReactFlowProp =
        !!("onConnectStart" ==> System.Func<_,_,_>handler)

    static member inline onClickConnectStart(handler: MouseEvent -> OnConnectStartParams -> unit) : IReactFlowProp =
        !!("onClickConnectStart" ==> System.Func<_,_,_>handler)

    static member inline onConnectEnd(handler: MouseEvent -> unit) : IReactFlowProp =
        !!("onConnectEnd" ==> handler)

    static member inline onClickConnectEnd(handler: MouseEvent -> unit) : IReactFlowProp =
        !!("onClickConnectEnd" ==> handler)

    static member inline onEdgeUpdate(handler: Edge -> Connection -> unit) : IReactFlowProp =
        !!("onEdgeUpdate" ==> System.Action<_,_> handler)

    static member inline onEdgeMouseEnter(handler: MouseEvent -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeMouseEnter" ==> System.Action<_,_> handler)

    static member inline onEdgeMouseMove(handler: MouseEvent -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeMouseMove" ==> System.Action<_,_> handler)

    static member inline onEdgeMouseLeave(handler: MouseEvent -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeMouseLeave" ==> System.Action<_,_> handler)

    static member inline onEdgeContextMenu(handler: MouseEvent -> Edge -> unit) : IReactFlowProp =
        !!("onEdgeContextMenu" ==> System.Action<_,_> handler)

    /// This callback can be used to validate a new connection.
    /// If you return false, the edge will not be added to your flow.
    /// If you have custom connection logic its preferred to use this callback over the isValidConnection prop on the handle component for performance reasons.
    static member inline isValidConnection (validate: Edge -> bool) =
        Interop.mkReactFlowProp "isValidConnection" validate

    //TODO: Test if that works

    static member inline onEdgeUpdateStart(handler: MouseEvent -> Edge -> HandleType -> unit) : IReactFlowProp =
        !!("onEdgeUpdateStart" ==> System.Action<_,_,_> handler)

    static member inline onEdgeUpdateEnd(handler: MouseEvent -> Edge -> HandleType -> unit) : IReactFlowProp =
        !!("onEdgeUpdateEnd" ==> System.Action<_,_,_> handler)

    static member inline onEdgesDelete(handler: Edge [] -> unit) : IReactFlowProp =
        !! ("onEdgesDelete" ==> handler)

    static member inline onInit(reactFlowInstance: Instance option -> unit) : IReactFlowProp =
        !!("onInit" ==> reactFlowInstance)

    [<System.Obsolete "Alias for `onInit`: `onLoad` has been renamed to `onInit` since React Flow v10">]
    static member inline onLoad(reactFlowInstance: Instance option -> unit) : IReactFlowProp =
        ReactFlow.onInit reactFlowInstance

    static member inline onMove(handler: MouseEvent -> Viewport -> unit) : IReactFlowProp =
        !!("onMove" ==> System.Action<_,_> handler)

    static member inline onMoveStart(handler: MouseEvent -> Viewport -> unit) : IReactFlowProp =
        !!("onMoveStart" ==> System.Action<_,_> handler)

    static member inline onMoveEnd(handler: MouseEvent -> Viewport -> unit) : IReactFlowProp =
        !!("onMoveEnd" ==> System.Action<_,_> handler)

    static member inline onSelectionChange(handler: OnSelectionChangeParams -> unit) : IReactFlowProp =
        !!("onSelectionChange" ==> handler)

    static member inline onSelectionDragStart(handler: MouseEvent -> Node [] -> unit) : IReactFlowProp =
        !!("onSelectionDragStart" ==> System.Action<_,_> handler)

    static member inline onSelectionDrag(handler: MouseEvent -> Node [] -> unit) : IReactFlowProp =
        !!("onSelectionDrag" ==> System.Action<_,_> handler)

    static member inline onSelectionDragStop(handler: MouseEvent -> Node [] -> unit) : IReactFlowProp =
        !!("onSelectionDragStop" ==> System.Action<_,_> handler)

    static member inline onSelectionContextMenu(handler: MouseEvent -> Node [] -> unit) : IReactFlowProp =
        !!("onSelectionContextMenu" ==> System.Action<_,_> handler)

    static member inline onPaneClick(handler: MouseEvent -> unit) : IReactFlowProp =
        !!("onPaneClick" ==> handler)

    static member inline onPaneContextMenu(handler: MouseEvent -> unit) : IReactFlowProp =
        !!("onPaneContextMenu" ==> handler)

    static member inline onPaneScroll(handler: MouseEvent -> unit) : IReactFlowProp =
        Interop.mkReactFlowProp "onPaneScroll" handler

    static member inline onPaneMouseMove(handler: MouseEvent -> unit) : IReactFlowProp =
        Interop.mkReactFlowProp "onPaneMouseMove" handler

    static member inline onPaneMouseEnter(handler: MouseEvent -> unit) : IReactFlowProp =
        Interop.mkReactFlowProp "onPaneMouseEnter" handler

    static member inline onPaneMouseLeave(handler: MouseEvent -> unit) : IReactFlowProp =
        Interop.mkReactFlowProp "onPaneMouseLeave" handler

    static member inline onError(handler: string -> string -> unit) : IReactFlowProp =
        !!("onError" ==> System.Action<_, _> handler)

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

    static member inline panOnDrag(panOnDrag : bool) : IReactFlowProp =
        Interop.mkReactFlowProp "panOnDrag" panOnDrag

    [<System.Obsolete "Alias for `panOnDrag`: `paneMoveable` has been renamed to `panOnDrag` since React Flow v10">]
    static member inline paneMoveable(paneMoveable : bool) : IReactFlowProp =
        ReactFlow.panOnDrag paneMoveable

    static member inline connectionMode(connectionMode : ConnectionMode) : IReactFlowProp =
        Interop.mkReactFlowProp "connectionMode" connectionMode

    /// Default: true
    static member inline autoPanOnConnect (value: bool) =
        Interop.mkReactFlowProp "autoPanOnConnect" value

    /// Default: true
    static member inline autoPanOnNodeDrag (value: bool) =
        Interop.mkReactFlowProp "autoPanOnNodeDrag" value

    /// Default: true
    static member inline edgesFocusable (value: bool) =
        Interop.mkReactFlowProp "edgesFocusable" value

    /// Default: true
    static member inline nodesFocusable (value: bool) =
        Interop.mkReactFlowProp "nodesFocusable" value

    /// Default: false
    static member inline selectionOnDrag (value: bool) =
        Interop.mkReactFlowProp "selectionOnDrag" value

    /// Enabling this option will raise the z-index of nodes when they are selected.
    /// Default: true
    static member inline elevateNodesOnSelect (value: bool) =
        Interop.mkReactFlowProp "elevateNodesOnSelect" value

    /// The `connectOnClick` option lets you click or tap on a source handle to start a connection and then click on a target handle to complete the connection.
    /// If you set this option to `false`, users will need to drag the connection line to the target handle to create a connection.
    /// Default: true
    static member inline connectOnClick (value: bool) =
        Interop.mkReactFlowProp "connectOnClick" value


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

    static member inline connectionLineStyle (svgAttrs: #seq<ISvgAttribute>) : IReactFlowProp =
        Interop.mkReactFlowProp "connectionLineStyle" (createObj !!svgAttrs)

    static member inline connectionLineComponent(connectionLineComponent: string) : IReactFlowProp =
        Interop.mkReactFlowProp "connectionLineComponent" connectionLineComponent

    static member inline connectionLineComponent(connectionLineComponent: Fable.React.ReactElementType) : IReactFlowProp =
        Interop.mkReactFlowProp "connectionLineComponent" connectionLineComponent

    /// The radius around a handle where you drop a connection line to create a new edge.
    /// Default: 20
    static member inline connectionRadius (value: float) : IReactFlowProp =
        Interop.mkReactFlowProp "connectionRadius" value

    // Keys

    static member inline deleteKeyCode (keyCode: string) : IReactFlowProp =
        Interop.mkReactFlowProp "deleteKeyCode" keyCode
    static member inline deleteKeyCode ([<System.ParamArray>] keyCodes: string []) : IReactFlowProp =
        Interop.mkReactFlowProp "deleteKeyCode" keyCodes

    static member inline selectionKeyCode (keyCode: string) : IReactFlowProp =
        Interop.mkReactFlowProp "selectionKeyCode" keyCode
    static member inline selectionKeyCode ([<System.ParamArray>] keyCodes: string []) : IReactFlowProp =
        Interop.mkReactFlowProp "selectionKeyCode" keyCodes

    static member inline multiSelectionKeyCode (keyCode: string) : IReactFlowProp =
        Interop.mkReactFlowProp "multiSelectionKeyCode" keyCode
    static member inline multiSelectionKeyCode ([<System.ParamArray>] keyCodes: string []) : IReactFlowProp =
        Interop.mkReactFlowProp "multiSelectionKeyCode" keyCodes

    static member inline zoomActivationKeyCode (keyCode: string) : IReactFlowProp =
        Interop.mkReactFlowProp "zoomActivationKeyCode" keyCode
    static member inline zoomActivationKeyCode ([<System.ParamArray>] keyCodes: string []) : IReactFlowProp =
        Interop.mkReactFlowProp "zoomActivationKeyCode" keyCodes

    static member inline panActivationKeyCode (keyCode: string) : IReactFlowProp =
        Interop.mkReactFlowProp "panActivationKeyCode" keyCode
    static member inline panActivationKeyCode ([<System.ParamArray>] keyCodes: string []) : IReactFlowProp =
        Interop.mkReactFlowProp "panActivationKeyCode" keyCodes
