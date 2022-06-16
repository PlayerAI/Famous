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
let Labeled_button =
    [
        Elem.div [Attr.class' "ui divider"] [] 
        Button.make_labeled [] []  (Text.raw "2,048") [Elem.i [Attr.class' "heart icon"] [];Text.raw "Like"]
        Button.make_labeled [Left;Right_Pointing] []  (Text.raw "2,048") [Elem.i [Attr.class' "heart icon"] [];Text.raw "Like"]
        Button.make_labeled [Left;Icon] []  (Text.raw "2,048") [Elem.i [Attr.class' "fork icon"] [];Text.raw "Like"]
        Elem.div [Attr.class' "ui divider"] [] 
        Button.make_labeled [B_Color Red;] []  (Text.raw "2,048") [Elem.i [Attr.class' "heart icon"] [];Text.raw "Like"]
        Button.make_labeled [B_Color Yellow;Left;Right_Pointing] []  (Text.raw "2,048") [Elem.i [Attr.class' "heart icon"] [];Text.raw "Like"]
        Button.make_labeled [B_Color Blue;Left;Icon] []  (Text.raw "2,048") [Elem.i [Attr.class' "fork icon"] [];Text.raw "Like"]
    ]
let icon_button =
    [
        Elem.div [Attr.class' "ui divider"] [] 
        Button.make_icon [] (Elem.i [Attr.class' "heart icon"] []) [] []
        Button.make_icon [B_Color Red] (Elem.i [Attr.class' "heart icon"] []) [] []
        Button.make_icon [B_Color Black] (Elem.i [Attr.class' "heart icon"] []) [] []
        
    ]

let different_type_button =
    [
        Elem.div [Attr.class' "ui divider"] [] 
        let name = "Basic"
        let id_=Kit.getId()
        let js=get_script (name)|>JS.run_script_when_click id_
        Famous.Button.make name [Basic] [Attr.id id_] [js]
        //
        let name = "Tertiary"
        let id_=Kit.getId()
        let js=get_script (name)|>JS.run_script_when_click id_
        Famous.Button.make name [Tertiary] [Attr.id id_] [js]
        //
        Elem.div [Attr.class' "ui inverted segment"] [            
            let name = "Inverted"
            let id_=Kit.getId()
            let js=get_script (name)|>JS.run_script_when_click id_
            Famous.Button.make name [Inverted] [Attr.id id_] [js]
        ]
        
        
    ]
let grouped_button=[
        Elem.div [Attr.class' "ui divider"] [ ] 
        let name = "Grouped"
        let id_=Kit.getId()
        let js=get_script (name)|>JS.run_script_when_click id_
        Famous.Button.make_grouped [Basic] [Attr.id id_] [
            js
            Famous.Button.make "One" [] [] []
            Famous.Button.make "Two" [] [] []
            Famous.Button.make "Three" [] [] []
            ]
        //-------
        Elem.div [Attr.class' "ui divider"] [ ] 
        let name = "Icon"
        let id_=Kit.getId()
        let js=get_script (name)|>JS.run_script_when_click id_
        Famous.Button.make_grouped_icon [Basic] [Attr.id id_] [
            js
            Famous.Button.make "" [] [] [Elem.i [Attr.class' "bold icon"] [] ]
            Famous.Button.make "" [] [] [Elem.i [Attr.class' "underline icon"] [] ]
            Famous.Button.make "" [] [] [Elem.i [Attr.class' "text width icon"] [] ]
            ]
    ]
let button_sized  =
    Famous.Element_size.GetAll()
    |>List.map (fun i ->
        let name =i.ToString().ToUpper()
        let id_=Kit.getId()
        let js=get_script (name)|>JS.run_script_when_click id_ 
        Famous.Button.make (name) [B_Size i] [Attr.id id_;]  [js]
    )
    |>List.append [Elem.div [Attr.class' "ui divider"] [ ]]
let final=
    button_demo @ 
        animated_button @ 
        Labeled_button @ 
        icon_button @ 
        different_type_button @ 
        grouped_button @
        button_sized
let handler: HttpHandler=
    Response.withHeader "Content-Language"  "zh-cn"  // "en-us"
    >> Response.ofHtml (Site_template.page final)
