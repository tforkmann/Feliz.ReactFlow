namespace Feliz.ReactFlow

open Feliz
open Fable.Core.JsInterop
open Fable.Core

[<Erase>]
type edge =
    static member inline source(source: string) = Interop.mkAttr "source" source
    static member inline target(target: string) = Interop.mkAttr "target" target
    static member inline animated(animated: bool) = Interop.mkAttr "animated" animated

    static member inline arrowHeadType(arrowHeadType: ArrowHead) =
        Interop.mkAttr "arrowHeadType" arrowHeadType.Value

    static member inline label(label: obj) = Interop.mkAttr "label" label
    static member inline edgeType(edgeType: EdgeType) = Interop.mkAttr "type" edgeType.Value

    static member inline labelStyle props =
        Interop.mkAttr "labelStyle" (createObj !!props)

    static member inline id(id: string) = Interop.mkAttr "id" id

    static member inline style props =
        Interop.mkAttr "style" (createObj !!props)
