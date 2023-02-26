namespace Feliz.ReactFlow

open Fable.Core

module Styles =

    [<Erase>]
    type classes =
        /// If you have controls (like a slider) or other elements inside your custom node
        /// that should not drag the node you can add the class name `nodrag`.
        /// This also prevents the selection of a node.
        static member inline nodrag = "nodrag"
        /// If you want to allow scrolling inside a node or inside an element of a node
        /// you can add the class name `nowheel` to the node or the element.
        static member inline nowheel = "nowheel"
