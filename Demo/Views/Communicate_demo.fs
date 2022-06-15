module Communicate_demo
open Falco
open Falco.Routing
open Falco.HostBuilder
open Microsoft.AspNetCore.Builder
open Falco.Markup
open Famous
open System.Text.Json
open System.Text.Json.Serialization
let mutable summary=0
let mutable plus=1
let communicate_demo() = 
    let button1_id=Kit.getId()
    let button2_id=Kit.getId() 
    let input_id=Kit.getId()
    let header_id=Kit.getId()      
    let click_event action input_id button_id= 
        let script=
            sprintf 
                """
                var v=$("#%s").val();
                var event = {"Method":"%s","Value":v};
                var l="/communicate_demo?par="+JSON.stringify(event)
                console.log(l);
                window.location.href = l;
                """ input_id action
        //"""window.location.href = "b.html?id=1";"""
        JS.run_script_when_click button_id script
    Elem.div [ ] [ 
        //echo here
        Elem.h1 [Attr.class' "ui header";Attr.id header_id] [Text.raw (string summary)]        
        //input here
        Elem.div [Attr.class' "ui input"] [
            Elem.input [
                Attr.type' "text"
                Attr.placeholder "在这里输入试试..."
                Attr.id input_id
                Attr.value (string plus)
                ] 
        ]
        Button.make "-" [] [Attr.id button1_id] [click_event "Subtracting" input_id button1_id] 
        Button.make "+" [] [Attr.id button2_id] [click_event "Adding" input_id button2_id] 
        
    ]
    |>fun i -> [i]
[<CLIMutable>]
type QueryParameters =
    {
        Method:string
        Value:string
    }
let queryBind (q : QueryCollectionReader) =
    match q.TryGetString "par" with
    | Some par -> 
        let result = JsonSerializer.Deserialize<QueryParameters> par
        let v=int(result.Value)
        match result.Method with
        |"Adding"->
            summary <- summary + v
            plus <-v
        |_->
            summary <- summary - v
            plus <-v
    |_->()    
    communicate_demo()

let handler: HttpHandler=
    Request.mapQuery queryBind (fun communicate_demo->
        Response.withHeader "Content-Language"  "zh-cn"  // "en-us"
        >> Response.ofHtml (Site_template.page communicate_demo)
        )