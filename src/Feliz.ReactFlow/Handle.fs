namespace Feliz.ReactFlow

open Fable.Core
open Fable.Core.JsInterop
open Feliz

[<Erase>]
type handle =
    // Handle Component: https://reactflow.dev/docs/api/handle/

    static member inline type' (value: HandleType): IHandleProp =
        Interop.mkHandleProp "type" value

    static member inline id(handleId: string): IHandleProp =
        Interop.mkHandleProp "id" handleId

    static member inline position(position: Position): IHandleProp =
        Interop.mkHandleProp "position" position

    static member inline onConnect(handler: Connection -> unit) : IHandleProp =
        Interop.mkHandleProp "onConnect" handler

    static member inline isValidConnection(handler: Connection -> bool) : IHandleProp =
        Interop.mkHandleProp "isValidConnection" handler

    static member inline isConnectable (value: bool) = Interop.mkHandleProp "isConnectable" value

    static member inline style (props: #seq<IStyleAttribute>): IHandleProp =
        Interop.mkHandleProp "style" (createObj !!props)

    static member inline className(className: string): IHandleProp =
        Interop.mkHandleProp "className" className
