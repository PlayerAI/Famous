module Demo.Program

open Falco
open Falco.Routing
open Falco.HostBuilder
open Microsoft.AspNetCore.Builder
open Falco.Markup
// ------------
// Exception Handler
// ------------
let exceptionHandler : HttpHandler =
    Response.withStatusCode 500 
    >> Response.ofPlainText "Server error"

let create_demo title description content =
    Elem.div [Attr.class' "ui container"] [(Famous.Template.showcase title description content)]

let page button_showcases_list= 
    Templates.html5 "en"
        [ 
            Elem.title [] [ Text.raw "Sample App" ] 
            Elem.script [Attr.src "jquery-3.6.0.min.js" ] []
            Elem.script [Attr.src "semantic.min.js" ] []
            //Elem.link [ Attr.href "style.css"; Attr.rel "stylesheet" ]
            Elem.link  [ 
                Markup.Attr.rel "stylesheet"
                Markup.Attr.type' "text/css"
                Markup.Attr.href "semantic.min.css"                 
                ] 
            ] // <head></head>
        [   
            Elem.div [Attr.class' "pusher" ] [
                Elem.div [Attr.class' "article"] [
                    Elem.div [Attr.class' "ui masthead vertical segment"] [
                        Elem.div [Attr.class' "ui container"] [
                            Elem.div [Attr.class' "introduction"] [
                                Elem.h1 [Attr.class' "ui header"] [ Text.raw "Demo page" ] 
                                
                                ]
                            
                            ]
                    
                    ]
                    Elem.div [Attr.class' "main ui container"] button_showcases_list
                ]
            ] 
            
            
        ]    // <body></body>
let handlerWithHeader button_showcases_list : HttpHandler =
    Response.withHeader "Content-Language" "en-us"
    >> Response.ofHtml (page button_showcases_list)
let par:Famous.Button_Parameters= 
    {
        Button_text = "text"
        Button_type=None
        Button_color=None 
        Children=None
        Attributes=None
    }
let button_demo = 
    Famous.Element_color.GetAll()
    |>List.map (fun i ->
        let p_local={par with Button_color =Some i;Button_text=i.ToString().ToUpper()}
        Famous.Button.makes p_local
        )
let index_page =
    [
        Elem.div [Attr.class' "ui bulleted list"] [
            Elem.div [Attr.class' "item"] [Elem.a [Attr.href "/button"] [Text.raw "Button showcases"] ]
            Elem.div [Attr.class' "item"] [Elem.a [Attr.href "/button"] [Text.raw "Button showcases"] ]
        
        ]
    ] 
[<EntryPoint>]
let main args =   
    webHost args {
        use_if    FalcoExtensions.IsDevelopment DeveloperExceptionPageExtensions.UseDeveloperExceptionPage
        use_ifnot FalcoExtensions.IsDevelopment (FalcoExtensions.UseFalcoExceptionHandler exceptionHandler)
        use_static_files
        endpoints [            
            get "/" (handlerWithHeader index_page)
            get "/button" (handlerWithHeader button_demo)
        ]
    }
    0