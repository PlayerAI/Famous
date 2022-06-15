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
    let button_1_id = Kit.getId()       
    //------------------
    let model_par2 =Famous.Modal_parameter.empty("基本的Modal2")
    let model_2 = 
        {
            model_par2 
            with 
                Modal_parameter.Actions=[Modal_action.Approve "button 1";Modal_action.Deny "button 2"]
                Modal_parameter.Content=[Text.raw "Are you Ok? 你还好吗?"]
        }
    let button_2_id = Kit.getId()     
    [
        Elem.div [ ] [ 
            Famous.Button.make "基本Model" [B_Color Red] [Attr.id button_1_id] []
            Famous.Modal.make_basic(model_par)
            Famous.Modal.trigger_modal_by model_par.Id button_1_id
            ]
        Elem.div [ ] [ 
            Famous.Button.make "基本Model" [B_Color Green] [Attr.id button_2_id] []
            Famous.Modal.make_basic model_2
            Famous.Modal.trigger_modal_by model_par2.Id button_2_id
            ]
    ]
let handler: HttpHandler=
    Response.withHeader "Content-Language"  "zh-cn"  // "en-us"
    >> Response.ofHtml (Site_template.page modal_demo)