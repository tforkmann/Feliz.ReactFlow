namespace Feliz.ReactFlow

open Feliz
open Fable.Core.JsInterop
open Fable.Core

[<Erase>]
type edge =
    static member inline source(source: string) : IEdgeProp = Interop.mkEdgeProp "source" source

    static member inline target(target: string) : IEdgeProp = Interop.mkEdgeProp "target" target

    static member inline sourceHandle(sourceHandle: string) : IEdgeProp =
        Interop.mkEdgeProp "sourceHandle" sourceHandle

    static member inline targetHandle(targetHandle: string) : IEdgeProp =
        Interop.mkEdgeProp "targetHandle" targetHandle

    static member inline animated(animated: bool) : IEdgeProp = Interop.mkEdgeProp "animated" animated

    static member inline selected(selected: bool) : IEdgeProp = Interop.mkEdgeProp "selected" selected

    static member inline hidden(hidden: bool) : IEdgeProp = Interop.mkEdgeProp "hidden" hidden

    static member inline arrowHeadType(arrowHeadType: ArrowHead) : IEdgeProp =
        Interop.mkEdgeProp "arrowHeadType" arrowHeadType

    static member inline label(label: string) : IEdgeProp = Interop.mkEdgeProp "label" label

    static member inline data(data: obj) : IEdgeProp = Interop.mkEdgeProp "data" data

    static member inline edgeType(edgeType: EdgeType) : IEdgeProp = Interop.mkEdgeProp "type" edgeType

    static member inline labelStyle props : IEdgeProp =
        Interop.mkEdgeProp "labelStyle" (createObj !!props)

    static member inline id(id: string) : IEdgeProp = Interop.mkEdgeProp "id" id

    static member inline style props : IEdgeProp =
        Interop.mkEdgeProp "style" (createObj !!props)