module Site_template
open Falco
open Falco.Routing
open Falco.HostBuilder
open Microsoft.AspNetCore.Builder
open Falco.Markup
open Famous
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
let handler content : HttpHandler =
    Response.withHeader "Content-Language"  "zh-cn"  // "en-us"
    >> Response.ofHtml (page content)
