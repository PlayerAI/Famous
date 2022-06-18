namespace Famous
open Falco.Markup
open Falco

type Modal_cls=
    |Center_aligned
    //|Fullscreen
    |Overlay_fullscreen
    |Modal_size of Element_size
    |Inverted
    |Scrolling
    |Longer
    |Active
    override t.ToString()=
        match t with 
        |Center_aligned ->"center aligned"
        //|Fullscreen->"fullscreen"
        |Overlay_fullscreen->"overlay fullscreen"
        |Modal_size s->s.ToString()
        |Inverted->"inverted"
        |Scrolling->"scrolling"
        |Longer->"longer"
        |Active->"active"
type Modal_parameter=
    {
        Modal_cls:Modal_cls list
        Header:string 
        Header_cls:Modal_cls list
        Content:XmlNode list
        Content_cls:Modal_cls list
        Actions:XmlNode list
        Action_cls:Modal_cls list
        Id:string
    }
    static member empty(title_Header)=
        {
            Modal_cls=[]
            Header=title_Header
            Header_cls=[]
            Content=[]
            Content_cls=[]
            Actions=[]  
            Action_cls=[]
            Id=Kit.getRandomString(24)
        }
[<RequireQualifiedAccess>]
module Modal=
    let make(par:Modal_parameter)  =                
        let cls_modal= Kit.get_cls par.Modal_cls
        let cls_header= Kit.get_cls par.Header_cls
        let cls_content= Kit.get_cls par.Content_cls
        let cls_action= Kit.get_cls par.Action_cls
        Elem.div [Attr.class' $"ui {cls_modal} modal";Attr.id par.Id] [
            yield Elem.div [Attr.class' ($"{cls_header} header")] [Text.raw par.Header]
            yield Elem.div [Attr.class' ($"{cls_content} content")] par.Content
            if par.Actions.Length>0
            then
                yield Elem.div [Attr.class' ($"{cls_action} action")] par.Actions
            yield Elem.script [] [
                Text.rawf """$('#%s').modal();""" par.Id
                ]
        ]
    let make_image_content (par:Modal_parameter)  =        
        let cls_modal= Kit.get_cls par.Modal_cls
        let cls_header= Kit.get_cls par.Header_cls
        let cls_content= Kit.get_cls par.Content_cls
        let cls_action= Kit.get_cls par.Action_cls
        Elem.div [Attr.class' $"ui {cls_modal} modal"] [
            yield Elem.div [Attr.class' ($"{cls_header} header")] [Text.raw par.Header]
            yield Elem.div [Attr.class' ($"{cls_content} image content")] par.Content
            if par.Actions.Length>0
            then
                yield Elem.div [Attr.class' ($"{cls_action} action")] par.Actions
            yield Elem.script [] [
                Text.raw """$('.ui.modal').modal();"""
                ]
        ]
    
    let trigger_modal_by (modal_id) (trigger_by_id:string)= 
        Elem.script [] [    
            Text.rawf """
                $("#%s").click(function(){
                  $("#%s").modal('show');
                });
                """ trigger_by_id modal_id
            ]
    let close_modal_by (modal_id) (trigger_by_id:string)= 
        Elem.script [] [    
            Text.rawf """
                $("#%s").click(function(){
                  $("#%s").modal('hide');
                });
                """ trigger_by_id modal_id
            ]
        

