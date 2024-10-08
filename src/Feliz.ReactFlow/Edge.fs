namespace Feliz.ReactFlow

open Feliz
open Fable.Core.JsInterop
open Fable.Core


[<Erase>]
type edge =
    static member inline source(sourceNodeId: string) : IEdgeProp = Interop.mkEdgeProp "source" sourceNodeId

    static member inline target(targetNodeId: string) : IEdgeProp = Interop.mkEdgeProp "target" targetNodeId

    static member inline sourceHandle(sourceHandleId: string) : IEdgeProp =
        Interop.mkEdgeProp "sourceHandle" sourceHandleId

    static member inline targetHandle(targetHandleId: string) : IEdgeProp =
        Interop.mkEdgeProp "targetHandle" targetHandleId

    static member inline animated(animated: bool) : IEdgeProp = Interop.mkEdgeProp "animated" animated

    static member inline selected(selected: bool) : IEdgeProp = Interop.mkEdgeProp "selected" selected

    static member inline hidden(hidden: bool) : IEdgeProp = Interop.mkEdgeProp "hidden" hidden

    static member inline markerStart(markerType: EdgeMarker) : IEdgeProp =
        Interop.mkEdgeProp "markerStart" markerType

    static member inline markerStart(markerType: string) : IEdgeProp =
        Interop.mkEdgeProp "markerStart" markerType

    static member inline markerStart(
        ``type``: MarkerType, ?color: string, ?width: float, ?height: float,
        ?markerUnits: string, ?orient: string, ?strokeWidth: float
    ) =
        jsOptions<EdgeMarker>(fun m ->
            m.``type`` <- ``type``
            m.color <- color
            m.width <- width
            m.height <- height
            m.markerUnits <- markerUnits
            m.orient <- orient
            m.strokeWidth <- strokeWidth
        ) |> Interop.mkEdgeProp "markerStart"

    static member inline markerEnd(markerType: EdgeMarker) : IEdgeProp =
        Interop.mkEdgeProp "markerEnd" markerType

    static member inline markerEnd(markerType: string) : IEdgeProp =
        Interop.mkEdgeProp "markerEnd" markerType

    static member inline markerEnd(
        ``type``: MarkerType, ?color: string, ?width: float, ?height: float,
        ?markerUnits: string, ?orient: string, ?strokeWidth: float
    ) =
        jsOptions<EdgeMarker>(fun m ->
            m.``type`` <- ``type``
            m.color <- color
            m.width <- width
            m.height <- height
            m.markerUnits <- markerUnits
            m.orient <- orient
            m.strokeWidth <- strokeWidth
        ) |> Interop.mkEdgeProp "markerEnd"

    static member inline label(label: string) : IEdgeProp = Interop.mkEdgeProp "label" label

    static member inline data (data: obj) : IEdgeProp = Interop.mkEdgeProp "data" data

    static member inline data (data: 'T) : IEdgeProp = Interop.mkEdgeProp "data" data

    static member inline type' (edgeType: EdgeType) : IEdgeProp = Interop.mkEdgeProp "type" edgeType

    static member inline type' (customTypeName: string) : IEdgeProp = Interop.mkEdgeProp "type" customTypeName

    static member inline labelStyle (styleProps: #seq<IStyleAttribute>) : IEdgeProp =
        Interop.mkEdgeProp "labelStyle" (createObj !!styleProps)

    static member inline id(id: string) : IEdgeProp = Interop.mkEdgeProp "id" id

    static member inline style (styleProps: #seq<IStyleAttribute>) : IEdgeProp =
        Interop.mkEdgeProp "style" (createObj !!styleProps)
