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
    let [<Literal>] ControlButton = "ControlButton"
    let [<Literal>] Controls = "Controls"
    let [<Literal>] NodeResizer = "NodeResizer"
    let [<Literal>] NodeResizeControl = "NodeResizeControl"
    let [<Literal>] Panel = "Panel"
    let [<Literal>] NodeToolbar = "NodeToolbar"


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
    let inline mkPanelProp (key: string) (value: obj) : IPanelProp = unbox (key, value)
    let inline mkNodeToolbarProp (key: string) (value: 'T): INodeToolbarProp = unbox (key, value)


