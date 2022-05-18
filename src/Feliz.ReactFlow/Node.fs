namespace Feliz.ReactFlow

open Fable.Core
open Fable.Core.JsInterop
open Feliz

[<Erase>]
type node =
    static member inline id(id: string): INodeProp =
        Interop.mkNodeProp "id" id

    static member inline position(x: int, y: int): INodeProp =
        Interop.mkNodeProp "position" {| x = x; y = y |}

    static member inline data(data: obj): INodeProp =
        Interop.mkNodeProp "data" data

    static member inline nodetype(nodeType: NodeType): INodeProp =
        Interop.mkNodeProp "type" (nodeType.toString())

    static member inline style props: INodeProp =
        Interop.mkNodeProp "style" (createObj !!props)

    static member inline className(className: string): INodeProp =
        Interop.mkNodeProp "className" (createObj !!className)

    static member inline targetPosition(targetPosition: HandlePosition): INodeProp =
        Interop.mkNodeProp "targetPosition" (createObj !!targetPosition)

    static member inline sourcePosition(sourcePosition: HandlePosition): INodeProp =
        Interop.mkNodeProp "sourcePosition" (createObj !!sourcePosition)

    static member inline hidden(hidden: bool): INodeProp =
        Interop.mkNodeProp "hidden" (createObj !!hidden)

    static member inline draggable(draggable: bool): INodeProp =
        Interop.mkNodeProp "draggable" (createObj !!draggable)

    static member inline connectable(connectable: bool): INodeProp =
        Interop.mkNodeProp "connectable" (createObj !!connectable)

    static member inline selectable(selectable: bool): INodeProp =
        Interop.mkNodeProp "selectable" (createObj !!selectable)
