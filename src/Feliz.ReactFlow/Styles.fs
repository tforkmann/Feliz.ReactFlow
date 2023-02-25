namespace Feliz.ReactFlow

open Fable.Core

module Styles =
    [<Erase>]
    type style =
        static member inline background(background: string): IStyleProp = Interop.mkStyleProp "background" background
        static member inline color(color: string): IStyleProp = Interop.mkStyleProp "color" color
        static member inline border(border: string): IStyleProp = Interop.mkStyleProp "border" border
        static member inline width(width: int): IStyleProp = Interop.mkStyleProp "width" width
        static member inline stroke(stroke: string): IStyleProp = Interop.mkStyleProp "stroke" stroke

    [<Erase>]
    type labelStyle =
        static member inline fill(fill: string): ILabelStyleProp = Interop.mkLabelStyleProp "fill" fill
        static member inline fontWeight(fontWeight: int): ILabelStyleProp = Interop.mkLabelStyleProp "fontWeight" fontWeight

    [<Erase>]
    type classes =
        /// If you have controls (like a slider) or other elements inside your custom node
        /// that should not drag the node you can add the class name `nodrag`.
        /// This also prevents the selection of a node.
        static member inline nodrag = "nodrag"
        /// If you want to allow scrolling inside a node or inside an element of a node
        /// you can add the class name `nowheel` to the node or the element.
        static member inline nowheel = "nowheel"
