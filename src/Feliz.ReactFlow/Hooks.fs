module Feliz.ReactFlow.Hooks

open Fable.Core
open Fable.Core.JsInterop

type ReactFlow with
    [<Import("useStore", "reactflow")>]
    static member useStore(selector: ReactFlowState -> 'StateSlice, ?equalityFn: 'StateSlice -> 'StateSlice -> bool) : 'StateSlice =
        jsNative

    [<Import("useReactFlow", "reactflow")>]
    static member useReactFlow () : Instance = jsNative

    /// When you are programatically changing the number or the position of handles inside a custom node
    /// you need to notify React Flow about it with the `useUpdateNodeInternals` hook.
    /// It also updates the internal dimensions of a node.
    /// The hook returns a function that expects a string (node id) as a parameter.
    [<Import("useUpdateNodeInternals", "reactflow")>]
    static member useUpdateNodeInternals () : NodeId -> unit = jsNative

    [<Import("useNodes", "reactflow")>]
    static member useNodes () : #Node [] = jsNative

    [<Import("useEdges", "reactflow")>]
    static member useEdges () : #Edge [] = jsNative

    [<Import("useViewport", "reactflow")>]
    static member useViewport () : Viewport = jsNative

    /// This hook returns the node id of the custom node in which it is used. ⚠️ This hook can only be used within a custom node.
    [<Import("useNodeId", "reactflow")>]
    static member useNodeId () : NodeId = jsNative

    /// This hook returns `true` when all nodes are initialized (measured by react flow and given a width and height).
    /// When you add a new node, it will return `false` and then `true` when the new node is initialized.
    /// It will always return `false` when the nodes array is empty.
    [<Import("useNodesInitialized", "reactflow")>]
    static member useNodesInitialized () : bool = jsNative

    /// This hook lets you listen to selection changes.
    static member inline useOnSelectionChange (onChange: OnSelectionChangeParams -> unit) : unit =
        (import "useOnSelectionChange" "reactflow") {| onChange = onChange |}

    /// This hook lets you listen to viewport changes. You can pass an object with an `onStart`, `onChange` and `onEnd` handlers.
    static member inline useOnViewportChange (?onStart: OnViewportChange, ?onChange: OnViewportChange, ?onEnd: OnViewportChange) : unit =
        (import "useOnViewportChange" "reactflow") {|
            onStart = onStart
            onChange = onChange
            onEnd = onEnd
        |}

    /// This hook returns if the passed key is pressed.
    /// The component that uses this hook re-renders whenever a the returned boolean changes.
    /// The hook expects one paramter "keyCode" which can be:
    /// * a string like "Space" (event.code or event.key) for a single key
    /// * a string like "Meta+s" (event.code or event.key combined with a + sign) for a key combination
    static member inline useKeyPress (keyCode: string) : unit =
        (import "useKeyPress" "reactflow") keyCode

    /// This hook returns if the passed key is pressed.
    /// The component that uses this hook re-renders whenever a the returned boolean changes.
    /// The hook expects one paramter "keyCode" which can be:
    /// * an array with a single or key combination for multiple possibilities like: ['Backspace', 'Meta+d']
    static member inline useKeyPress (keyCodes: string []) : unit =
        (import "useKeyPress" "reactflow") keyCodes
