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
                Modal_parameter.Actions=[
                    let id_b1=Kit.getId()
                    let id_b2=Kit.getId()
                    Button.make "Yes" [Button_cls.Approve] [Attr.id id_b1] [Modal.close_modal_by model_par2.Id id_b1];
                    Button.make "No" [Button_cls.Deny] [Attr.id id_b2] [Modal.close_modal_by model_par2.Id id_b2];
                    ]
                Content_cls =[Modal_cls.Center_aligned]
                Modal_parameter.Content=[Text.raw "Are you Ok? 你还好吗?"]
                Action_cls =[Modal_cls.Center_aligned]
        }
    let button_2_id = Kit.getId()     
    [
        Elem.div [ ] [ 
            Famous.Button.make "基本Model 1" [B_Color Red] [Attr.id button_1_id] []
            Famous.Modal.make(model_par)
            Famous.Modal.trigger_modal_by model_par.Id button_1_id
            ]
        Elem.div [ ] [ 
            Famous.Button.make "基本Model 2" [B_Color Green] [Attr.id button_2_id] []
            Famous.Modal.make model_2
            Famous.Modal.trigger_modal_by model_par2.Id button_2_id
            ]
        let button_3_id = Kit.getId()  
        let model_par3 =Famous.Modal_parameter.empty("基本的Modal3")
        let model_3 = 
            {
                model_par3 
                with 
                    Modal_cls = [Overlay_fullscreen;Modal_size Massive]
                    Modal_parameter.Actions=[
                        let id_b1=Kit.getId()
                        let id_b2=Kit.getId()
                        Button.make "Yes" [Button_cls.Approve] [Attr.id id_b1] [Modal.close_modal_by model_par3.Id id_b1];
                        Button.make "No" [Button_cls.Deny] [Attr.id id_b2] [Modal.close_modal_by model_par3.Id id_b2];
                        ]
                    Content_cls =[Modal_cls.Center_aligned]
                    Modal_parameter.Content=[Text.raw "Are you Ok? 你还好吗?"]
                    Action_cls =[Modal_cls.Center_aligned]
            }
        Elem.div [ ] [ 
            Famous.Button.make "基本Model 3" [B_Color Blue] [Attr.id button_3_id] []
            Famous.Modal.make model_3
            Famous.Modal.trigger_modal_by model_par3.Id button_3_id
            ]
    ]
let handler: HttpHandler=
    Response.withHeader "Content-Language"  "zh-cn"  // "en-us"
    >> Response.ofHtml (Site_template.page modal_demo)