module Button_demo

open Falco
open Falco.Routing
open Falco.HostBuilder
open Microsoft.AspNetCore.Builder
open Falco.Markup
open Famous
let get_script (button_name)=
    let s =
        sprintf
            """
            $('body')
                .toast({
                  class: 'success',
                  message: `You have clicked '%s' Button !`
                });
            """ button_name
    s
    //JS.run_script_when_click target_id s
let button_demo = 
    Famous.Element_color.GetAll()
    |>List.map (fun i ->
        let name =i.ToString().ToUpper()
        let id_=Kit.getId()
        let js=get_script (name)|>JS.run_script_when_click id_    
        Famous.Button.make name [B_Color i] [Attr.id id_] [js]
        )
let animated_button =
    [
        Elem.div [Attr.class' "ui divider"] [] 
        Button.make_animated [] [] (Elem.i [Attr.class' "right arrow icon"] []) (Text.raw "Next")
        Button.make_animated [Vertical] []  (Text.raw "Shop") (Elem.i [Attr.class' "shop icon"] [])
        Button.make_animated [Fade] [] (Text.raw "$12.99 a month") (Text.raw "Sign-up for a Pro account")
    ]

let final=button_demo @ animated_button
let handler: HttpHandler=
    Response.withHeader "Content-Language"  "zh-cn"  // "en-us"
    >> Response.ofHtml (Site_template.page final)
