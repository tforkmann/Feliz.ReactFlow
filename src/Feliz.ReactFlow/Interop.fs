namespace Feliz.ReactFlow

open Fable.Core
open Fable.Core.JsInterop

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

    let reactFlow : obj = importDefault "reactflow"
    let handle : obj = import "Handle" "reactflow"
    let background : obj = import "Background" "reactflow"
    let miniMap : obj = import "MiniMap" "reactflow"
    let controls : obj = import "Controls" "reactflow"

[<Erase; RequireQualifiedAccess>]
module Helpers =
    let isEdge : Element -> bool = import "isEdge" "reactflow"
    let isNode : Element -> bool = import "isNode" "reactflow"

    // TODO
    // let removeElements : obj = import "removeElements" "reactflow"
    // let addEdge : obj = import "addEdge" "reactflow"
    // let updateEdge : obj = import "updateEdge" "reactflow"
    // let getOutgoers : obj = import "getOutgoers" "reactflow"
    // let getIncomers : obj = import "getIncomers" "reactflow"
    // let getConnectedEdges : obj = import "getConnectedEdges" "reactflow"
