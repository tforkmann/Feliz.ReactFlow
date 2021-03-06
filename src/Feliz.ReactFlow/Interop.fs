namespace Feliz.ReactFlow

open Fable.Core
open Fable.Core.JsInterop

[<Erase; RequireQualifiedAccess>]
module Interop =
    let inline mkHandleProp (key: string) (value: obj) : IHandleProp = unbox (key, value)
    let inline mkEdgeProp (key: string) (value: obj) : IEdgeProp = unbox (key, value)
    let inline mkNodeProp (key: string) (value: obj) : INodeProp = unbox (key, value)
    let inline mkStyleProp (key: string) (value: obj) : IStyleProp = unbox (key, value)
    let inline mkLabelStyleProp (key: string) (value: obj) : ILabelStyleProp = unbox (key, value)
    let inline mkReactFlowProp (key: string) (value: obj) : IReactFlowProp = unbox (key, value)
    let inline mkBackgroundProp (key: string) (value: obj) : IBackgroundProp = unbox (key, value)
    let inline mkMiniMapProp (key: string) (value: obj) : IMiniMapProp = unbox (key, value)
    let inline mkControlsProp (key: string) (value: obj) : IControlsProp = unbox (key, value)

    let reactFlow : obj = importDefault "react-flow-renderer"
    let handle : obj = import "Handle" "react-flow-renderer"
    let background : obj = import "Background" "react-flow-renderer"
    let miniMap : obj = import "MiniMap" "react-flow-renderer"
    let controls : obj = import "Controls" "react-flow-renderer"

[<Erase; RequireQualifiedAccess>]
module Helpers =
    let isEdge : Element -> bool = import "isEdge" "react-flow-renderer"
    let isNode : Element -> bool = import "isNode" "react-flow-renderer"

    // TODO
    // let removeElements : obj = import "removeElements" "react-flow-renderer"
    // let addEdge : obj = import "addEdge" "react-flow-renderer"
    // let updateEdge : obj = import "updateEdge" "react-flow-renderer"
    // let getOutgoers : obj = import "getOutgoers" "react-flow-renderer"
    // let getIncomers : obj = import "getIncomers" "react-flow-renderer"
    // let getConnectedEdges : obj = import "getConnectedEdges" "react-flow-renderer"
