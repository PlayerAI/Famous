module Input_demo
open Falco
open Falco.Routing
open Falco.HostBuilder
open Microsoft.AspNetCore.Builder
open Falco.Markup
open Famous
let input_demo = 
    let input_id=Kit.getRandomString(24)
    let target_id=Kit.getRandomString(24)
    let when_changed =
        sprintf 
            """
            var v=$("#%s").val();            
            $("#%s").html(v);
            """ input_id target_id
    Elem.div [ ] [ 
        //input here
        Elem.div [Attr.class' "ui input"] [
            Elem.input [
                Attr.type' "text"
                Attr.placeholder "在这里输入试试..."
                Attr.id input_id
                ] 
        ]
        //echo here
        Elem.h1 [Attr.class' "ui header";Attr.id target_id] [Text.raw ""]
        JS.run_script_when_input input_id when_changed
    ]
    |>fun i -> [i]
let handler: HttpHandler=
    Response.withHeader "Content-Language"  "zh-cn"  // "en-us"
    >> Response.ofHtml (Site_template.page input_demo)
