namespace Feliz.ReactFlow

open Fable.Core
open Fable.Core.JsInterop

[<Erase; RequireQualifiedAccess>]
module Interop =
    [<Emit("Object.keys($0)")>]
    let internal objectKeys (x: obj) = jsNative

    let objectHas (keys: string list) (x: obj) =
        objectKeys (x) |> Seq.toList |> (=) keys

    [<Emit("Object.assign({}, $0, $1)")>]
    let objectAssign (x: obj) (y: obj) = jsNative

    let inline mkNodeAttr (key: string) (value: obj) : INodeProp = unbox (key, value)
    let reactFlow : obj = importDefault "react-flow-renderer" // import the top-level ReactFlow element

    let removeElements : obj =
        import "removeElements" "react-flow-renderer" // a child of specific modules - not needed for this demo, but as an example

    let addEdge : obj = import "addEdge" "react-flow-renderer"

    let funcToTuple handler =
        System.Func<_, _, _>(fun a b -> handler (a, b))
