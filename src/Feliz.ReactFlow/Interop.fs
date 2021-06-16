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

    let reactFlow : obj = importDefault "react-flow-renderer" // import the top-level ReactFlow element
    let handle : obj = import "Handle" "react-flow-renderer"  // import the Handle component used for building custom nodes
    let removeElements : obj = import "removeElements" "react-flow-renderer" // a child of specific modules - not needed for this demo, but as an example
    let addEdge : obj = import "addEdge" "react-flow-renderer"
