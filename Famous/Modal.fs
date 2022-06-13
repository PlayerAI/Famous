namespace Famous
open Falco.Markup
open Falco
[<RequireQualifiedAccess>]
type Modal_action=
    |Positive of string
    |Approve of string
    |Ok of string
    |Negative of string
    |Deny of string
    |Cancel of string
    |Neutral of string
    override t.ToString()=
        match t with
        |Positive s->"positive"
        |Approve s->"approve"
        |Ok s->"ok"
        |Negative s->"negative"
        |Deny s->"deny"
        |Cancel s->"cancel"
        |Neutral s -> "" 
    member t.Messge=
        match t with
        |Positive s->s
        |Approve s->s
        |Ok s->s
        |Negative s->s
        |Deny s->s
        |Cancel s->s
        |Neutral s -> s
    member t.ToXmlNode() = 
        Elem.div [Attr.class' $"ui %s{t.ToString()} button"] [Text.raw t.Messge]
type Modal_parameter=
    {
        Header:string 
        Content:XmlNode list 
        Actions:Modal_action list 
        Center_aligned:bool
        Id:string
    }
    static member empty(title_Header)=
        {
            Header=title_Header
            Content=[]
            Actions=[]
            Center_aligned=false
            Id=Kit.getRandomString(24)
        }
[<RequireQualifiedAccess>]
module Modal=
    let make_basic (par:Modal_parameter)  =
        let center_aligned= if par.Center_aligned then "center aligned " else ""        
        Elem.div [Attr.class' "ui modal";Attr.id par.Id] [
            yield Elem.div [Attr.class' ("header")] [Text.raw par.Header]
            yield Elem.div [Attr.class' ("content")] par.Content
            if par.Actions.Length>0
            then                 
                let acts=par.Actions|>List.map (fun i -> i.ToXmlNode())
                yield Elem.div [Attr.class' ("action")] acts
            yield Elem.script [] [
                Text.rawf """$('#%s').modal();""" par.Id
                ]
        ]
    let make_image_content (par:Modal_parameter)  =
        let center_aligned= if par.Center_aligned then "center aligned " else ""
        Elem.div [Attr.class' "ui modal"] [
            yield Elem.div [Attr.class' (center_aligned+"header")] [Text.raw par.Header]
            yield Elem.div [Attr.class' (center_aligned+"image content")] par.Content
            if par.Actions.Length>0
            then                 
                let acts=par.Actions|>List.map (fun i -> i.ToXmlNode())
                yield Elem.div [Attr.class' (center_aligned+"action")] acts
            yield Elem.script [] [
                Text.raw """$('.ui.modal').modal();"""
                ]
        ]
    let make_scrolling_content (par:Modal_parameter)  =
        Elem.div [Attr.class' "ui modal"] [
            yield Elem.div [Attr.class' "header"] [Text.raw par.Header]
            yield Elem.div [Attr.class' "scrolling content"] par.Content
            if par.Actions.Length>0
            then                 
                let acts=par.Actions|>List.map (fun i -> i.ToXmlNode())
                yield Elem.div [Attr.class' "action"] acts
            yield Elem.script [] [
                Text.raw """$('.ui.modal').modal();"""
                ]
        ] 
    let connect (modal_id) (trigger_by_id:string)= 
        Elem.script [] [    
            Text.rawf """
                $("#%s").click(function(){
                  $("#%s").modal('show');
                });
                """ trigger_by_id modal_id
            ]
    
        

