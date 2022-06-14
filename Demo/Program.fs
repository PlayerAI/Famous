module Demo.Program

open Falco
open Falco.Routing
open Falco.HostBuilder
open Microsoft.AspNetCore.Builder
open Falco.Markup
open Famous
// ------------
// Exception Handler
// ------------
let exceptionHandler : HttpHandler =
    Response.withStatusCode 500 
    >> Response.ofPlainText "Server error"






let index_page =
    [
        Elem.div [Attr.class' "ui bulleted list"] [
            Elem.div [Attr.class' "item"] [Elem.a [Attr.href "/button"] [Text.raw "Button showcases"] ]
            Elem.div [Attr.class' "item"] [Elem.a [Attr.href "/modal"] [Text.raw "modal showcases"] ]
            Elem.div [Attr.class' "item"] [Elem.a [Attr.href "/input_demo"] [Text.raw "input demo"] ]
            Elem.div [Attr.class' "item"] [Elem.a [Attr.href "/communicate_demo"] [Text.raw "communicate demo"] ]
        
        ]
    ] 
[<EntryPoint>]
let main args =   
    webHost args {
        use_if    FalcoExtensions.IsDevelopment DeveloperExceptionPageExtensions.UseDeveloperExceptionPage
        use_ifnot FalcoExtensions.IsDevelopment (FalcoExtensions.UseFalcoExceptionHandler exceptionHandler)
        use_static_files
        endpoints [            
            get "/" (Site_template.handler index_page)
            get "/button" Button_demo.handler
            get "/modal" Modal_demo.handler
            get "/input_demo" Input_demo.handler
            get "/communicate_demo" Communicate_demo.handler
        ]
    }
    0