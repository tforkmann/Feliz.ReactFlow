namespace Feliz.ReactFlow

open Fable.Core
open Fable.Core.JsInterop
open Feliz

[<Erase>]
type handle =
    // Handle Component: https://reactflow.dev/docs/api/handle/

    static member inline ``type``(``type``: HandleType): IHandleProp =
        Interop.mkHandleProp "type" ``type``

    static member inline id(id: string): IHandleProp =
        Interop.mkHandleProp "id" id

    static member inline position(position: HandlePosition): IHandleProp =
        Interop.mkHandleProp "position" position

    static member inline onConnect(handler: {| source: Node ; sourceHandle: Handle ; target: string ; targetHandle: Handle |} -> unit) : IHandleProp =
        !!("onConnect" ==> handler)

    static member inline isValidConnection(handler: {| source: Node ; sourceHandle: Handle ; target: string ; targetHandle: Handle |} -> bool) : IHandleProp =
        !!("isValidConnection" ==> handler)

    static member inline style props: IHandleProp =
        Interop.mkHandleProp "style" (createObj !!props)

    static member inline className(className: string): IHandleProp =
        Interop.mkHandleProp "className" className
