namespace Feliz.ReactFlow

open Fable.Core

/// This interface allows us to stop adding random props to the react flow.
type IReactFlowProp = interface end
type IElement = interface end
type IHandleProp = interface end
type INodeProp = interface end
type IEdgeProp = interface end
type IStyleProp = interface end
type ILabelStyleProp = interface end
type IBackgroundProp = interface end
type IMiniMapProp = interface end
type IControlsProp = interface end

type ElementId = string
type NodeId = string
type EdgeId = string
type HandleId = string

// Some sample types you can use for setting properties on elements.
[<StringEnum>]
type EdgeType =
    | [<CompiledName("default")>] Bezier
    | Straight
    | Step
    | [<CompiledName("smoothstep")>] SmoothStep

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

type NodeType =
    | Input
    | Output
    | Default
    | Custom of string

    member this.toString() =
        match this with
        | Input -> "input"
        | Output -> "output"
        | Default -> "default"
        | Custom name -> name

[<StringEnum>]
type HandleType =
    | Source
    | Target

[<StringEnum>]
type HandlePosition =
    | Top
    | Bottom
    | Left
    | Right

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

[<StringEnum>]
type ConnectionLineType =
    | Bezier
    | Straight
    | Step
    | Smoothstep

type Element =
    abstract id: ElementId

// TODO: Rest of properties https://reactflow.dev/docs/api/nodes/
type Node =
    inherit Element
    abstract position: position
    abstract data: obj
    abstract ``type``: NodeType

// TODO: Rest of properties https://reactflow.dev/docs/api/edges/
type Edge =
    inherit Element

type Handle =
    inherit Element
    abstract ``type``: HandleType
    abstract position: HandlePosition

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

type [<AllowNullLiteral>] Connection =
    abstract source: NodeId option with get, set
    abstract target: NodeId option with get, set
    abstract sourceHandle: HandleId option with get, set
    abstract targetHandle: HandleId option with get, set

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
