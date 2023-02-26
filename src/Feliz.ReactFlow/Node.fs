namespace Feliz.ReactFlow

open Fable.Core
open Fable.Core.JsInterop
open Feliz

[<Erase>]
type node =
    static member inline id(id: string): INodeProp =
        Interop.mkNodeProp "id" id

    static member inline position(x: float, y: float): INodeProp =
        Interop.mkNodeProp "position" {| x = x; y = y |}

    static member inline data(data: obj): INodeProp =
        Interop.mkNodeProp "data" data

    static member inline nodetype(nodeType: NodeType): INodeProp =
        Interop.mkNodeProp "type" (nodeType.toString())

    static member inline style (props: #seq<IStyleAttribute>): INodeProp =
        Interop.mkNodeProp "style" (createObj !!props)

    static member inline className(className: string): INodeProp =
        Interop.mkNodeProp "className" className

    static member inline dragHandle(selector: string): INodeProp =
        Interop.mkNodeProp "dragHandle" selector

    static member inline zIndex(value: float): INodeProp =
        Interop.mkNodeProp "zIndex" value

    static member inline width(value: float): INodeProp =
        Interop.mkNodeProp "width" value

    static member inline height(value: float): INodeProp =
        Interop.mkNodeProp "height" value

    static member inline ariaLabel(value: string): INodeProp =
        Interop.mkNodeProp "ariaLabel" value

    static member inline positionAbsolute(x: float, y: float): INodeProp =
        Interop.mkNodeProp "positionAbsolute" {| x = x; y = y |}

    static member inline targetPosition(targetPosition: HandlePosition): INodeProp =
        Interop.mkNodeProp "targetPosition" targetPosition

    static member inline sourcePosition(sourcePosition: HandlePosition): INodeProp =
        Interop.mkNodeProp "sourcePosition" sourcePosition

    static member inline hidden(isHidden: bool): INodeProp =
        Interop.mkNodeProp "hidden" isHidden

    [<System.Obsolete "Alias for `hidden`: `isHidden` has been renamed to `hidden` since React Flow v10">]
    static member inline isHidden(isHidden: bool): INodeProp =
        node.hidden isHidden

    static member inline draggable(draggable: bool): INodeProp =
        Interop.mkNodeProp "draggable" draggable

    static member inline connectable(connectable: bool): INodeProp =
        Interop.mkNodeProp "connectable" connectable

    static member inline selectable(selectable: bool): INodeProp =
        Interop.mkNodeProp "selectable" selectable

    static member inline deletable(deletable: bool): INodeProp =
        Interop.mkNodeProp "deletable" deletable

    static member inline focusable(focusable: bool): INodeProp =
        Interop.mkNodeProp "focusable" focusable

    static member inline parentNode(parentNodeId: NodeId) : INodeProp =
        Interop.mkNodeProp "parentNode" parentNodeId

    static member inline expandParent(value: bool) : INodeProp =
        Interop.mkNodeProp "expandParent" value

    static member inline selected(value: bool) : INodeProp =
        Interop.mkNodeProp "selected" value

    static member inline extent(firstPoint: float * float, secondPoint: float * float) : INodeProp =
        Interop.mkNodeProp "extent" (firstPoint, secondPoint)


module node =

    [<Erase>]
    type extent =
        static member inline parent = Interop.mkNodeProp "extent" "parent"
