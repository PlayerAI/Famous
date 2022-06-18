namespace Famous
open Falco.Markup
open Falco
type JS_event =
    |Click
    |Keyup
    |OnApprove
    |OnDeny
    override t.ToString()=
        match t with
        |Click-> "click"
        |Keyup-> "keyup"
        |OnApprove-> "onApprove"
        |OnDeny-> "onDeny"
[<RequireQualifiedAccess>]
module JS=
    let make (js:string) =
        Elem.script [] [    
            Text.rawf "%s" js
            ]
    let run_JS_at 
        (event:JS_event) 
        (target_elment_id:string) 
        (script:string)
        =
        Elem.script [] [    
            Text.rawf """
                $("#%s").%s(function(){
                  %s
                });
                """ target_elment_id (event.ToString())  script
            ]
    let run_script_when_click (target_id) (script:string)= 
        script
        |>run_JS_at JS_event.Click target_id 
    let run_script_when_input (target_id) (script:string)= 
        script
        |>run_JS_at JS_event.Keyup target_id 
        

