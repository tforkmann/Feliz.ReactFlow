namespace Feliz.ReactFlow

open System
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

    static member inline style (props: #seq<IStyleAttribute>) : IBackgroundProp =
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

    static member inline style (props: #seq<IStyleAttribute>): IControlsProp =
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

    /// The content of the component.
    static member inline children (element: ReactElement) = Interop.mkControlsProp "children" element
    /// The content of the component.
    static member inline children (elements: seq<ReactElement>) =
        Interop.mkControlsProp "children" (Interop.reactApi.Children.toArray (Array.ofSeq elements))
    /// The content of the component.
    static member inline children (value: string) = Interop.mkControlsProp "children" value


[<Erase>]
type nodeResizer =
    /// The id of the node that will be resizable, you only need to set this if you are using the resizer outside of a custom node
    /// Default: the id of the custom node where the <NodeResizer> is rendered.
    static member inline nodeId (value: string) = Interop.mkNodeResizerProp "nodeId" value

    /// The color of the resize controls.
    /// Default: undefined
    static member inline color (value: bool) = Interop.mkNodeResizerProp "color" value

    /// This flag can be used to toggle the visibility of the resizer, useful if you want to display the controls only if a node is selected.
    /// Default: true
    static member inline isVisible (value: bool) = Interop.mkNodeResizerProp "isVisible" value

    /// This flag can be used to keep the dimensions of the node while resizing.
    /// Default: false
    static member inline keepAspectRatio (value: bool) = Interop.mkNodeResizerProp "keepAspectRatio" value

    /// The minimal width of the node to which it can be resized.
    /// Default: 10
    static member inline minWidth (value: float) = Interop.mkNodeResizerProp "minWidth" value

    /// The maximum width of the node to which it can be resized.
    /// Default: Number.MAX_INT
    static member inline maxWidth (value: float) = Interop.mkNodeResizerProp "maxWidth" value

    /// The minimal height of the node to which it can be resized.
    /// Default: 10
    static member inline minHeight (value: float) = Interop.mkNodeResizerProp "minHeight" value

    /// The maximum height of the node to which it can be resized.
    /// Default: Number.MAX_INT
    static member inline maxHeight (value: float) = Interop.mkNodeResizerProp "maxHeight" value

    /// Styles that will be attached to the resize handle component.
    /// Default: undefined
    static member inline handleStyle (styleProps: #seq<IStyleAttribute>) = Interop.mkNodeResizerProp "handleStyle" (createObj !!styleProps)

    /// Styles that will be attached to the resize handle component.
    /// Default: undefined
    static member inline handleStyle (stylePropsObj: obj) = Interop.mkNodeResizerProp "handleStyle" stylePropsObj

    /// Additional class name for the resize handle.
    /// Default: undefined
    static member inline handleClassName (value: string) = Interop.mkNodeResizerProp "handleClassName" value

    /// Styles that will be attached to the resize lines.
    /// Default: undefined
    static member inline lineStyle (styleProps: #seq<IStyleAttribute>) = Interop.mkNodeResizerProp "lineStyle" (createObj !!styleProps)

    /// Styles that will be attached to the resize lines.
    /// Default: undefined
    static member inline lineStyle (stylePropsObj: obj) = Interop.mkNodeResizerProp "lineStyle" stylePropsObj

    /// Additional class name for the resize lines.
    /// Default: undefined
    static member inline lineClassName (value: string) = Interop.mkNodeResizerProp "lineClassName" value

    /// This function is called before resizing and prevents the resize event if the function returns false.
    /// Default: undefined
    static member inline shouldResize (handler: ResizeDragEvent -> ResizeParamsWithDirection -> bool) =
        Interop.mkNodeResizerProp "shouldResize" (Func<_, _, _> handler)

    /// Called on resize start.
    /// Default: undefined
    static member inline onResizeStart (handler: ResizeDragEvent -> ResizeParams -> unit) =
        Interop.mkNodeResizerProp "onResizeStart" (Action<_, _> handler)

    /// Called on resize.
    /// Default: undefined
    static member inline onResize (handler: ResizeDragEvent -> ResizeParamsWithDirection -> unit) =
        Interop.mkNodeResizerProp "onResize" (Action<_, _> handler)

    /// Called on resize end.
    /// Default: undefined
    static member inline onResizeEnd (handler: ResizeDragEvent -> ResizeParams -> unit) =
        Interop.mkNodeResizerProp "onResizeEnd" (Action<_, _> handler)


[<Erase>]
module panel =

    [<Erase>]
    type position =
        static member inline topLeft = Interop.mkPanelProp "position" "top-left"
        static member inline topCenter = Interop.mkPanelProp "position" "top-center"
        static member inline topRight = Interop.mkPanelProp "position" "top-right"
        static member inline bottomLeft = Interop.mkPanelProp "position" "bottom-left"
        static member inline bottomCenter = Interop.mkPanelProp "position" "bottom-center"
        static member inline bottomRight = Interop.mkPanelProp "position" "bottom-right"


[<Erase>]
type panel =

    /// Position of the panel in the viewport
    /// Default: 'top-left'
    static member inline position (value: PanelPosition) = Interop.mkPanelProp "position" value

    /// Additional styles.
    static member inline style (styleProps: #seq<IStyleAttribute>) = Interop.mkPanelProp "style" (createObj !!styleProps)

    /// Additional styles.
    static member inline style (stylePropsObj: obj) = Interop.mkPanelProp "style" (createObj !!stylePropsObj)

    /// Additional class name.
    static member inline className (value: string) = Interop.mkPanelProp "className" value

    /// The content of the component.
    static member inline children (element: ReactElement) = Interop.mkPanelProp "children" element
    /// The content of the component.
    static member inline children (elements: seq<ReactElement>) =
        Interop.mkPanelProp "children" (Interop.reactApi.Children.toArray (Array.ofSeq elements))
    /// The content of the component.
    static member inline children (value: string) = Interop.mkPanelProp "children" value


[<Erase>]
type nodeToolbar =
    static member inline nodeId (nodeId: NodeId) = Interop.mkNodeToolbarProp "nodeId" nodeId
    /// By passing in an array of node id's you can render a single tooltip for a group or collection of nodes.
    static member inline nodeId (groupedNodeIds: NodeId []) = Interop.mkNodeToolbarProp "nodeId" groupedNodeIds

    static member inline isVisible (value: bool) = Interop.mkNodeToolbarProp "isVisible" value

    static member inline position (value: Position) = Interop.mkNodeToolbarProp "position" value

    /// The space between the node and the toolbar, measured in pixels. Default: 10.
    static member inline offset (value: float) = Interop.mkNodeToolbarProp "offset" value

    static member inline align (value: NodeToolbarAlign) = Interop.mkNodeToolbarProp "align" value

    /// The content of the component.
    static member inline children (element: ReactElement) = Interop.mkNodeToolbarProp "children" element
    /// The content of the component.
    static member inline children (elements: seq<ReactElement>) =
        Interop.mkNodeToolbarProp "children" (Interop.reactApi.Children.toArray (Array.ofSeq elements))
    /// The content of the component.
    static member inline children (value: string) = Interop.mkNodeToolbarProp "children" value
