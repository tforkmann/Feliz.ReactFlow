namespace Feliz.ReactFlow

open Fable.Core
open Fable.Core.JsInterop
open Feliz

[<Erase>]
type node =
    static member inline position(x: int, y: int) =
        Interop.mkNodeAttr "position" {| x = x; y = y |}

    static member inline nodetype(nodeType: NodeType) =
        Interop.mkNodeAttr "type" nodeType.Value

    static member inline data(data: obj) = Interop.mkNodeAttr "data" data

    static member inline style props =
        Interop.mkNodeAttr "style" (createObj !!props)

    static member inline id(id: string) = Interop.mkNodeAttr "id" id
