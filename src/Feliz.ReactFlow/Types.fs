namespace Feliz.ReactFlow

open Fable.Core

/// This interface allows us to stop adding random props to the react flow.
type IReactFlowProp = interface end
type IElement = interface end
type INodeProp = interface end
type IEdgeProp = interface end
type IStyleProp = interface end
type ILabelStyleProp = interface end

// Some sample types you can use for setting properties on elements.
[<StringEnum>]
type EdgeType =
    | [<CompiledName("default")>] Bezier
    | Straight
    | Step
    | [<CompiledName("smoothstep")>] SmoothStep

[<StringEnum>]
type ArrowHead =
    | Arrow
    | [<CompiledName("arrowclosed")>] ArrowClosed

[<StringEnum>]
type NodeType =
    | Input
    | Output
    | Default

[<StringEnum>]
type HandleType =
    | Source
    | Target

type position = {| x: int; y: int |}

type Element =
    abstract id: string

// TODO: Rest of properties https://reactflow.dev/docs/api/nodes/
type Node =
    inherit Element
    abstract position: position
    abstract data: obj
    abstract ``type``: NodeType

// TODO: Rest of properties https://reactflow.dev/docs/api/edges/
type Edge =
    inherit Element
