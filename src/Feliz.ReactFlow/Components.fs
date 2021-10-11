namespace Feliz.ReactFlow

open Fable.Core
open Fable.Core.JsInterop
open Feliz

[<StringEnum>]
type BackgroundVariant =
    | Dots
    | Lines

[<Erase>]
type background =
    // https://reactflow.dev/docs/api/components/background/

    static member inline variant(variant: BackgroundVariant): IBackgroundProp =
        Interop.mkBackgroundProp "variant" variant

    static member inline gap(gap: int): IBackgroundProp =
        Interop.mkBackgroundProp "gap" gap

    static member inline gap(gap: float): IBackgroundProp =
        Interop.mkBackgroundProp "gap" gap

    static member inline size(size: int): IBackgroundProp =
        Interop.mkBackgroundProp "size" size

    static member inline size(size: float): IBackgroundProp =
        Interop.mkBackgroundProp "size" size

    static member inline color(color: string): IBackgroundProp =
        Interop.mkBackgroundProp "color" color

    static member inline style props: IBackgroundProp =
        Interop.mkBackgroundProp "style" (createObj !!props)

    static member inline className(className: string): IBackgroundProp =
        Interop.mkBackgroundProp "className" className

[<Erase>]
type miniMap =
    // https://reactflow.dev/docs/api/components/minimap/

    static member inline nodeColor(nodeColor: string): IMiniMapProp =
        Interop.mkMiniMapProp "nodeColor" nodeColor

    static member inline nodeColor(nodeColor: Node -> string): IMiniMapProp =
        Interop.mkMiniMapProp "nodeColor" nodeColor

    static member inline nodeBorderRadius(nodeBorderRadius: int): IMiniMapProp =
        Interop.mkMiniMapProp "nodeBorderRadius" nodeBorderRadius

    static member inline nodeBorderRadius(nodeBorderRadius: float): IMiniMapProp =
        Interop.mkMiniMapProp "nodeBorderRadius" nodeBorderRadius

    static member inline nodeStrokeWidth(nodeStrokeWidth: int): IMiniMapProp =
        Interop.mkMiniMapProp "nodeStrokeWidth" nodeStrokeWidth

    static member inline nodeStrokeWidth(nodeStrokeWidth: float): IMiniMapProp =
        Interop.mkMiniMapProp "nodeStrokeWidth" nodeStrokeWidth

    static member inline nodeClassName(nodeClassName: string): IMiniMapProp =
        Interop.mkMiniMapProp "nodeClassName" nodeClassName

    static member inline nodeClassName(nodeClassName: Node -> string): IMiniMapProp =
        Interop.mkMiniMapProp "nodeClassName" nodeClassName

    static member inline maskColor(maskColor: string): IMiniMapProp =
        Interop.mkMiniMapProp "maskColor" maskColor

    static member inline style props: IMiniMapProp =
        Interop.mkMiniMapProp "style" (createObj !!props)

    static member inline className(className: string): IMiniMapProp =
        Interop.mkMiniMapProp "className" className


[<Erase>]
type controls =
    // https://reactflow.dev/docs/api/components/minimap/

    static member inline showZoom(showZoom: bool): IControlsProp =
        Interop.mkControlsProp "showZoom" showZoom

    static member inline showFitView(showFitView: bool): IControlsProp =
        Interop.mkControlsProp "showFitView" showFitView

    static member inline showInteractive(showInteractive: bool): IControlsProp =
        Interop.mkControlsProp "showInteractive" showInteractive

    static member inline style props: IControlsProp =
        Interop.mkControlsProp "style" (createObj !!props)

    static member inline className(className: string): IControlsProp =
        Interop.mkControlsProp "className" className

    static member inline onZoomIn(onZoomIn: unit -> unit): IControlsProp =
        Interop.mkControlsProp "onZoomIn" onZoomIn

    static member inline onZoomOut(onZoomOut: unit -> unit): IControlsProp =
        Interop.mkControlsProp "onZoomOut" onZoomOut

    static member inline onFitView(onFitView: unit -> unit): IControlsProp =
        Interop.mkControlsProp "onFitView" onFitView

    static member inline onInteractiveChange(onInteractiveChange: bool -> unit): IControlsProp =
        Interop.mkControlsProp "onInteractiveChange" onInteractiveChange
