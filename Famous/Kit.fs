namespace Famous
open Falco.Markup
open Falco
module Kit= 
    let getRandomString(length:int)=         
        let random = new System.Random()
        let chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray()
        let stringChars=Array.init length (fun i -> chars.[random.Next(chars.Length)] ) 
        new string(stringChars)
    let run_script_when_click (target_id) (script:string)= 
        Elem.script [] [    
            Text.rawf """
                $("#%s").click(function(){
                  %s
                });
                """ target_id script
            ]
    let run_script_when_input (target_id) (script:string)= 
        Elem.script [] [    
            Text.rawf """
                $("#%s").keyup(function(){
                  %s
                });
                """ target_id script
            ]