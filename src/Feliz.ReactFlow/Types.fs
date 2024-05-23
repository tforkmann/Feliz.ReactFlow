namespace Feliz.ReactFlow

open Fable.React
open Fable.Core

/// This interface allows us to stop adding random props to the react flow.
type IReactFlowProp = interface end
type IElement = interface end
type IHandleProp = interface end
type INodeProp = interface end
type IEdgeProp = interface end
type IBackgroundProp = interface end
type IMiniMapProp = interface end
type IControlsProp = interface end
type INodeResizerProp = interface end
type INodeResizeControlProp = interface end
type IPanelProp = interface end
type INodeToolbarProp = interface end

type ElementId = string
type NodeId = string
type EdgeId = string
type HandleId = string


[<StringEnum; RequireQualifiedAccess>]
type EdgeType =
    | [<CompiledName("default")>] Bezier
    | Straight
    | Step
    | [<CompiledName("smoothstep")>] SmoothStep
    | [<CompiledName "simplebezier">] SimpleBezier

type [<StringEnum>] MarkerType =
    | Arrow
    | [<CompiledName("arrowclosed")>] ArrowClosed

type [<AllowNullLiteral>] EdgeMarker =
    abstract ``type``: MarkerType with get, set
    abstract color: string option with get, set
    abstract width: float option with get, set
    abstract height: float option with get, set
    abstract markerUnits: string option with get, set
    abstract orient: string option with get, set
    abstract strokeWidth: float option with get, set

type EdgeMarkerType =
    U2<string, EdgeMarker>

[<StringEnum>]
type NodeType =
    | Input
    | Output
    | Default
    | Group

[<StringEnum>]
type HandleType =
    | Source
    | Target

type [<StringEnum>] [<RequireQualifiedAccess>] Position =
    | Left
    | Top
    | Right
    | Bottom

type position = {| x: int; y: int |}

[<StringEnum>]
type ScrollMode =
    | Free
    | Vertical
    | Horizontal

[<StringEnum>]
type ConnectionMode =
    | Strict
    | Loose

type [<StringEnum>] [<RequireQualifiedAccess>] ConnectionLineType =
    | [<CompiledName("default")>] Bezier
    | Straight
    | Step
    | [<CompiledName("smoothstep")>] SmoothStep
    | [<CompiledName("simplebezier")>] SimpleBezier

type [<StringEnum>] [<RequireQualifiedAccess>] PanelPosition =
    | [<CompiledName("top-left")>] TopLeft
    | [<CompiledName("top-center")>] TopCenter
    | [<CompiledName("top-right")>] TopRight
    | [<CompiledName("bottom-left")>] BottomLeft
    | [<CompiledName("bottom-center")>] BottomCenter
    | [<CompiledName("bottom-right")>] BottomRight

[<StringEnum; RequireQualifiedAccess>]
type NodeToolbarAlign = | Start | Center | End

type [<AllowNullLiteral>] Viewport =
    abstract x: float with get, set
    abstract y: float with get, set
    abstract zoom: float with get, set

type [<AllowNullLiteral>] Dimensions =
    abstract width: float with get, set
    abstract height: float with get, set

type [<AllowNullLiteral>] XYPosition =
    abstract x: float with get, set
    abstract y: float with get, set

type [<AllowNullLiteral>] Rect =
    abstract x: float with get, set
    abstract y: float with get, set
    abstract width: float with get, set
    abstract height: float with get, set

type OnViewportChange = Viewport -> unit

/// (x, y, zoom)
type Transform = float * float * float

type CoordinateExtent =
    (float * float) * (float * float)

type ResizeDragEvent =
    inherit Browser.Types.Event

type [<AllowNullLiteral>] ResizeParams =
    abstract x: float with get, set
    abstract y: float with get, set
    abstract width: float with get, set
    abstract height: float with get, set

type [<AllowNullLiteral>] ResizeParamsWithDirection =
    inherit ResizeParams
    abstract direction: float[] with get, set

type Element =
    abstract id: ElementId with get, set

// TODO: Rest of properties https://reactflow.dev/docs/api/nodes/
type Node =
    inherit Element

    //abstract style: CSSProperties option with get, set
    abstract position: XYPosition with get, set
    abstract ``type``: NodeType with get, set
    abstract className: string option with get, set
    abstract targetPosition: Position option with get, set
    abstract sourcePosition: Position option with get, set
    abstract hidden: bool option with get, set
    abstract selected: bool option with get, set
    abstract dragging: bool option with get, set
    abstract draggable: bool option with get, set
    abstract selectable: bool option with get, set
    abstract connectable: bool option with get, set
    abstract deletable: bool option with get, set
    abstract focusable: bool option with get, set
    abstract dragHandle: string option with get, set
    abstract width: float option with get, set
    abstract height: float option with get, set
    [<System.Obsolete "`parentNode` prop is deprecated since React Flow v11.11.0">]
    abstract parentNode: NodeId option with get, set
    abstract parentId: NodeId option with get, set
    abstract zIndex: float option with get, set
    abstract extent: U2<CoordinateExtent, string> option with get, set
    abstract expandParent: bool option with get, set
    abstract positionAbsolute: XYPosition option with get, set
    abstract ariaLabel: string option with get, set

type UntypedDataNode =
    inherit Node
    abstract data: obj with get, set

type TypedDataNode<'Data> =
    inherit Node
    abstract data : 'Data with get, set

type [<AllowNullLiteral>] EdgeLabelOptions =
    //abstract labelStyle: CSSProperties option with get, set
    //abstract labelBgStyle: CSSProperties option with get, set
    abstract label: U2<string, ReactElement> option with get, set
    abstract labelShowBg: bool option with get, set
    abstract labelBgPadding: (float * float) option with get, set
    abstract labelBgBorderRadius: float option with get, set

// TODO: Rest of properties https://reactflow.dev/docs/api/edges/
type DefaultEdge =
    inherit Element
    inherit EdgeLabelOptions

    //abstract style: CSSProperties option with get, set
    abstract ``type``: string option with get, set
    abstract source: string with get, set
    abstract target: string with get, set
    abstract sourceHandle: string option with get, set
    abstract targetHandle: string option with get, set
    abstract animated: bool option with get, set
    abstract hidden: bool option with get, set
    abstract deletable: bool option with get, set
    abstract className: string option with get, set
    abstract sourceNode: Node option with get, set
    abstract targetNode: Node option with get, set
    abstract selected: bool option with get, set
    abstract markerStart: EdgeMarkerType option with get, set
    abstract markerEnd: EdgeMarkerType option with get, set
    abstract zIndex: float option with get, set
    abstract ariaLabel: string option with get, set
    abstract interactionWidth: float option with get, set
    abstract focusable: bool option with get, set

type [<AllowNullLiteral>] SmoothStepPathOptions =
    abstract offset: float option with get, set
    abstract borderRadius: float option with get, set

type SmoothStepEdgeType =
    inherit DefaultEdge
    abstract ``type``: string with get, set
    abstract pathOptions: SmoothStepPathOptions option with get, set

type [<AllowNullLiteral>] BezierPathOptions =
    abstract curvature: float option with get, set

type BezierEdgeType =
    inherit DefaultEdge
    abstract ``type``: string with get, set
    abstract pathOptions: BezierPathOptions option with get, set

type [<TypeScriptTaggedUnion("type")>] [<RequireQualifiedAccess>] BuiltInEdge =
    | [<CompiledName("default")>] BezierEdgeType of BezierEdgeType
    | [<CompiledName("smoothstep")>] SmoothStepEdgeType of SmoothStepEdgeType
    static member inline op_ErasedCast(x: BezierEdgeType) = BezierEdgeType x
    static member inline op_ErasedCast(x: SmoothStepEdgeType) = SmoothStepEdgeType x

type Edge = DefaultEdge //U2<DefaultEdge, BuiltInEdge>

type UntypedDataEdge =
    inherit DefaultEdge
    abstract data: obj option with get, set

type TypedDataEdge<'Data> =
    inherit DefaultEdge
    abstract data: 'Data option with get, set


type Handle =
    inherit Element
    abstract ``type``: HandleType with get, set
    abstract position: Position with get, set

type [<AllowNullLiteral>] Connection =
    abstract source: NodeId option with get, set
    abstract target: NodeId option with get, set
    abstract sourceHandle: HandleId option with get, set
    abstract targetHandle: HandleId option with get, set

type [<RequireQualifiedAccess; StringEnum>] CoordinateExtentKind = Parent

type [<AllowNullLiteral>] NodeDimensionChange =
    abstract id: string with get, set
    abstract ``type``: string with get, set
    abstract dimensions: Dimensions with get, set

type [<AllowNullLiteral>] NodePositionChange =
    abstract id: string with get, set
    abstract ``type``: string with get, set
    abstract position: XYPosition option with get, set
    abstract positionAbsolute: XYPosition option with get, set
    abstract dragging: bool option with get, set

type [<AllowNullLiteral>] NodeSelectionChange =
    abstract id: string with get, set
    abstract ``type``: string with get, set
    abstract selected: bool with get, set

type [<AllowNullLiteral>] NodeRemoveChange =
    abstract id: string with get, set
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] NodeAddChange =
    abstract item: Node with get, set
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] NodeResetChange =
    abstract item: Node with get, set
    abstract ``type``: string with get, set

type [<TypeScriptTaggedUnion("type")>] [<RequireQualifiedAccess>] NodeChange =
    | [<CompiledName("add")>] NodeAddChange of NodeAddChange
    | [<CompiledName("dimensions")>] NodeDimensionChange of NodeDimensionChange
    | [<CompiledName("position")>] NodePositionChange of NodePositionChange
    | [<CompiledName("remove")>] NodeRemoveChange of NodeRemoveChange
    | [<CompiledName("reset")>] NodeResetChange of NodeResetChange
    | [<CompiledName("select")>] NodeSelectionChange of NodeSelectionChange
    static member inline op_ErasedCast(x: NodeAddChange) = NodeAddChange x
    static member inline op_ErasedCast(x: NodeDimensionChange) = NodeDimensionChange x
    static member inline op_ErasedCast(x: NodePositionChange) = NodePositionChange x
    static member inline op_ErasedCast(x: NodeRemoveChange) = NodeRemoveChange x
    static member inline op_ErasedCast(x: NodeResetChange) = NodeResetChange x
    static member inline op_ErasedCast(x: NodeSelectionChange) = NodeSelectionChange x


type EdgeSelectionChange = NodeSelectionChange

type EdgeRemoveChange = NodeRemoveChange

type [<AllowNullLiteral>] EdgeAddChange =
    abstract item: Edge with get, set
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] EdgeResetChange =
    abstract item: Edge with get, set
    abstract ``type``: string with get, set

type [<TypeScriptTaggedUnion("type")>] [<RequireQualifiedAccess>] EdgeChange =
    | [<CompiledName("add")>] EdgeAddChange of EdgeAddChange
    | [<CompiledName("remove")>] EdgeRemoveChange of EdgeRemoveChange
    | [<CompiledName("reset")>] EdgeResetChange of EdgeResetChange
    | [<CompiledName("select")>] EdgeSelectionChange of EdgeSelectionChange
    static member inline op_ErasedCast(x: EdgeAddChange) = EdgeAddChange x
    static member inline op_ErasedCast(x: EdgeRemoveChange) = EdgeRemoveChange x
    static member inline op_ErasedCast(x: EdgeResetChange) = EdgeResetChange x
    static member inline op_ErasedCast(x: EdgeSelectionChange) = EdgeSelectionChange x


type [<AllowNullLiteral>] NodeDimensionUpdate =
    abstract id: string with get, set
    abstract nodeElement: Browser.Types.HTMLDivElement with get, set
    abstract forceUpdate: bool option with get, set

type NodeOrigin = float * float

type [<AllowNullLiteral>] NodeDragItem =
    abstract id: string with get, set
    abstract position: XYPosition with get, set
    abstract positionAbsolute: XYPosition with get, set
    abstract distance: XYPosition with get, set
    abstract width: float option with get, set
    abstract height: float option with get, set
    abstract extent: U2<CoordinateExtent, CoordinateExtentKind> option with get, set
    [<System.Obsolete "`parentNode` prop is deprecated since React Flow v11.11.0">]
    abstract parentNode: NodeId option with get, set
    abstract parentId: NodeId option with get, set
    abstract dragging: bool option with get, set
    abstract origin: NodeOrigin option with get, set
    abstract expandParent: bool option with get, set


type [<AllowNullLiteral>] UnselectNodesAndEdgesParams =
    abstract nodes: Node[] option with get, set
    abstract edges: Edge[] option with get, set

type [<AllowNullLiteral>] ReactFlowActions =
    abstract setNodes: nodes: Node[] -> unit
    abstract getNodes: unit -> Node[]
    abstract setEdges: edges: Edge[] -> unit
    abstract setDefaultNodesAndEdges: ?nodes: Node[] * ?edges: Edge[] -> unit
    abstract updateNodeDimensions: updates: NodeDimensionUpdate[] -> unit
    abstract updateNodePositions: nodeDragItems: U2<NodeDragItem[], Node[]> * positionChanged: bool * dragging: bool -> unit
    abstract resetSelectedElements: unit -> unit
    abstract unselectNodesAndEdges: ?``params``: UnselectNodesAndEdgesParams -> unit
    abstract addSelectedNodes: nodeIds: string[] -> unit
    abstract addSelectedEdges: edgeIds: string[] -> unit
    abstract setMinZoom: minZoom: float -> unit
    abstract setMaxZoom: maxZoom: float -> unit
    abstract setTranslateExtent: translateExtent: CoordinateExtent -> unit
    abstract setNodeExtent: nodeExtent: CoordinateExtent -> unit
    abstract cancelConnection: unit -> unit
    abstract reset: unit -> unit
    abstract triggerNodeChanges: changes: NodeChange[] -> unit
    abstract panBy: delta: XYPosition -> unit


type NodeInternals = JS.Map<NodeId, Node>

type ReactFlowStore =
    abstract nodeInternals : NodeInternals


type ReactFlowState =
    inherit ReactFlowStore
    inherit ReactFlowActions
