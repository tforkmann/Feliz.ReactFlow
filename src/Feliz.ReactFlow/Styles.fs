namespace Feliz.ReactFlow

open Fable.Core
open Feliz

module Styles =
    [<Erase>]
    type style =
        static member inline background(background: string) = Interop.mkAttr "background" background
        static member inline color(color: string) = Interop.mkAttr "color" color
        static member inline border(border: string) = Interop.mkAttr "border" border
        static member inline width(width: int) = Interop.mkAttr "width" width
        static member inline stroke(stroke: string) = Interop.mkAttr "stroke" stroke

    [<Erase>]
    type labelStyle =
        static member inline fill(fill: string) = Interop.mkAttr "fill" fill
        static member inline fontWeight(fontWeight: int) = Interop.mkAttr "fontWeight" fontWeight


