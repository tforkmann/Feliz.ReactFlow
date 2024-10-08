namespace Feliz.ReactFlow

open Fable.Core
open Fable.Core.JsInterop

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
    [<System.Obsolete("This function is deprecated and will be removed in v12. Use `getViewportForBounds` instead.")>]
    static member inline getTransformForBounds (bounds: Rect, width: float, height: float, minZoom: float, maxZoom: float, ?padding: float) : Transform = import "getTransformForBounds" "reactflow"

    /// This util returns the viewport for the given bounds. You might use this to pre-calculate the viewport for a given set of nodes on the server or calculate the viewport for the given bounds without changing the viewport directly.
    static member inline getViewportForBounds (bounds: Rect, width: float, height: float, minZoom: float, maxZoom: float, ?padding: float) : Viewport =
        import "getViewportForBounds" "reactflow"
    
    /// Returns the rect ({ x: number, y: number, width: number, height: number }) for the passed nodes array
    [<System.Obsolete "This function is deprecated and will be removed in v12. Use `getNodesBounds` instead.">]
    static member inline getRectOfNodes (nodes: Node[]) : Rect = import "getRectOfNodes" "reactflow"

    /// Returns the bounding box that contains all the given nodes in an array.
    /// This can be useful when combined with `getViewportForBounds` to calculate the correct transform to fit the given nodes in a viewport.
    static member inline getNodesBounds (nodes: Node[]) : Rect = import "getNodesBounds" "reactflow"
