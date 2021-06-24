namespace Feliz.ReactFlow

open Fable.Core
open Fable.Core.JsInterop
open Feliz

[<Erase>]
type node =
    static member inline position(x: int, y: int): INodeProp =
        Interop.mkNodeProp "position" {| x = x; y = y |}

    static member inline nodetype(nodeType: NodeType): INodeProp =
        Interop.mkNodeProp "type" (nodeType.toString())

    static member inline data(data: obj): INodeProp =
        Interop.mkNodeProp "data" data

    static member inline style props: INodeProp =
        Interop.mkNodeProp "style" (createObj !!props)

    static member inline id(id: string): INodeProp =
        Interop.mkNodeProp "id" id
