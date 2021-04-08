namespace Feliz.ReactFlow

open Fable.Core

[<Erase>]
/// This interface allows us to stop adding random props to the react flow.
type IReactFlowProp =
    interface
    end

[<Erase>]
type INodeProp =
    interface
    end

// Some sample types you can use for setting properties on elements.
type EdgeType =
    | Bezier
    | Straight
    | Step
    | SmoothStep
    member this.Value = this.ToString().ToLower()

type ArrowHead =
    | Arrow
    | ArrowClosed
    member this.Value = this.ToString().ToLower()

type NodeType =
    | Input
    | Output
    | Default
    member this.Value = this.ToString().ToLower()

type position = { x: int; y: int }
