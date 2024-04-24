module Plugin

open System.Runtime.InteropServices
open System.Text.Json
open Extism

[<UnmanagedCallersOnly(EntryPoint = "greet")>]
let Greet () : int32 =
    let name = Pdk.GetInputString()
    let greeting = $"Hello, {name}!"
    Pdk.SetOutput(greeting)
    0

[<UnmanagedCallersOnly>]
let add () =
    let inputJson = Pdk.GetInputString()
    let jsonData = JsonDocument.Parse(inputJson).RootElement
    let a = jsonData.GetProperty("a").GetInt32()
    let b = jsonData.GetProperty("b").GetInt32()
    let result = a + b
    let outputJson = $"{{ \"Result\": {result} }}"
    
    Pdk.SetOutput(outputJson)
    0

[<EntryPoint>]
let Main args  =
    // Note: an `EntryPoint` function is required for the app to compile
    0