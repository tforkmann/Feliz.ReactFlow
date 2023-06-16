namespace Feliz.ReactFlow

open Fable.Core
open Fable.Core.JsInterop

[<Erase; RequireQualifiedAccess>]
module PackageNames =
    let [<Literal>] ReactFlow = "reactflow"

[<Erase; RequireQualifiedAccess>]
module ImportNames =
    let [<Literal>] ReactFlowProvider = "ReactFlowProvider"
    let [<Literal>] Handle = "Handle"
    let [<Literal>] Background = "Background"
    let [<Literal>] MiniMap = "MiniMap"
    let [<Literal>] Controls = "Controls"
    let [<Literal>] NodeResizer = "NodeResizer"
    let [<Literal>] NodeResizeControl = "NodeResizeControl"


[<Erase; RequireQualifiedAccess>]
module Interop =
    let inline mkHandleProp (key: string) (value: obj) : IHandleProp = unbox (key, value)
    let inline mkEdgeProp (key: string) (value: obj) : IEdgeProp = unbox (key, value)
    let inline mkNodeProp (key: string) (value: obj) : INodeProp = unbox (key, value)
    let inline mkStyleProp (key: string) (value: obj) : Feliz.IStyleAttribute = unbox (key, value)
    let inline mkReactFlowProp (key: string) (value: obj) : IReactFlowProp = unbox (key, value)
    let inline mkBackgroundProp (key: string) (value: obj) : IBackgroundProp = unbox (key, value)
    let inline mkMiniMapProp (key: string) (value: obj) : IMiniMapProp = unbox (key, value)
    let inline mkControlsProp (key: string) (value: obj) : IControlsProp = unbox (key, value)
    let inline mkNodeResizerProp (key: string) (value: obj) : INodeResizerProp = unbox (key, value)
    let inline mkNodeResizeControlProp (key: string) (value: obj) : INodeResizeControlProp = unbox (key, value)

[<Erase>]
type GraphUtils =
    /// Returns true if the passed element is an edge
    static member inline isEdge (item: obj) : bool = import "isEdge" "reactflow"

    /// Returns true if the passed element is a node
    static member inline isNode (item: obj) : bool = import "isNode" "reactflow"
    
    /// Returns an array of nodes with the applied changes
    static member inline applyNodeChanges (changes: NodeChange [], nodes: Node []): Node [] = import "applyNodeChanges" "reactflow"
    
    /// Returns an array of edges with the applied changes
    static member inline applyEdgeChanges (changes: EdgeChange[], edges: Edge[]) : Edge[] = import "applyEdgeChanges" "reactflow"
    
    /// Returns an array of edges with the added edge
    static member inline addEdge (edgeParams: Edge, edges: Edge[]): Edge[] = import "addEdge" "reactflow"
    
    /// Can be used as a helper for onEdgeUpdate. Returns the edges with the updated edge
    static member inline updateEdge (oldEdge: Edge, newConnection: Connection, edges: Edge[]) : unit = import "updateEdge" "reactflow"
    
    /// Returns all direct child nodes of the passed node
    static member inline getOutgoers (node: Node, nodes: Node[], edges: Edge[]) : Node[] = import "getOutgoers" "reactflow"
    
    /// Returns all direct incoming nodes of the passed node
    static member inline getIncomers (node: Node, nodes: Node[], edges: Edge[]) : Node[] = import "getIncomers" "reactflow"
    
    /// Returns all edges that are connected to the passed nodes
    static member inline getConnectedEdges (nodes: Node[], edges: Edge[]) : Edge[] = import "getConnectedEdges" "reactflow"
    
    /// Returns the Transform ([x, y, zoom]) for the passed params
    static member inline getTransformForBounds (bounds: Rect, width: float, height: float, minZoom: float, maxZoom: float, ?padding: float) : Transform = import "getTransformForBounds" "reactflow"
    
    /// Returns the rect ({ x: number, y: number, width: number, height: number }) for the passed nodes array
    static member inline getRectOfNodes (nodes: Node[]) : Rect = import "getRectOfNodes" "reactflow"
