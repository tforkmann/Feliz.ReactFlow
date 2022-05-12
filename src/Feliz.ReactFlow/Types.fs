namespace Feliz.ReactFlow

open Fable.Core

/// This interface allows us to stop adding random props to the react flow.
type IReactFlowProp = interface end
type INode = interface end
type IEdge = interface end
type IHandleProp = interface end
type INodeProp = interface end
type IEdgeProp = interface end
type IStyleProp = interface end
type ILabelStyleProp = interface end
type IBackgroundProp = interface end
type IMiniMapProp = interface end
type IControlsProp = interface end

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

type ElementId = string

type Element =
    abstract id: ElementId

// Properties of https://reactflow.dev/docs/api/nodes/
type Node =
    inherit Element
    abstract id: string
    abstract ``type``: NodeType
    abstract data: obj
    abstract position: position

// TODO: Rest of properties https://reactflow.dev/docs/api/edges/
type Edge =
    inherit Element
    abstract id: string
    abstract ``type``: EdgeType
    abstract source: string
    abstract target: string
    abstract animated: bool
    abstract data: obj
    abstract label: string

type Handle =
    inherit Element
    abstract ``type``: HandleType
    abstract position: HandlePosition
