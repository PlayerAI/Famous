module Modal_demo
open Falco
open Falco.Routing
open Falco.HostBuilder
open Microsoft.AspNetCore.Builder
open Falco.Markup
open Famous
let modal_demo = 
    let model_par =Famous.Modal_parameter.empty("基本的Modal")
    //let model_ = Famous.Modal.make_basic(model_par)
    let button_par_empty=Famous.Button_Parameters.empty("empty")
    let b_basic={
                    button_par_empty 
                        with 
                            Button_color =Some Famous.Element_color.Orange;
                            Button_text="基本的Modal";                            
                }    
    //------------------
    let model_par2 =Famous.Modal_parameter.empty("基本的Modal2")
    let model_2 = 
        {
            model_par2 
            with 
                Modal_parameter.Actions=[Modal_action.Approve "button 1";Modal_action.Deny "button 2"]
                Modal_parameter.Content=[Text.raw "Are you Ok? 你还好吗?"]
        }
    let button_par_empty2=Famous.Button_Parameters.empty("empty")
    let b_basic2={
                    button_par_empty2 
                        with 
                            Button_color =Some Famous.Element_color.Red;
                            Button_text="基本的Modal2";
                            
                }
    [
        Elem.div [ ] [ 
            Famous.Button.make b_basic
            Famous.Modal.make_basic(model_par)
            Famous.Modal.connect model_par.Id b_basic.Id
            ]
        Elem.div [ ] [ 
            Famous.Button.make b_basic2
            Famous.Modal.make_basic model_2
            Famous.Modal.connect model_par2.Id b_basic2.Id
            ]
    ]
