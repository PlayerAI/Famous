namespace Famous
open Falco.Markup
open Falco
type Button_type=
    |Inverted
    |Tertiary
    |Basic
    |Labeled
    |Primary
    override t.ToString()=
        match t with
        |Inverted -> "inverted"
        |Tertiary-> "tertiary"
        |Basic-> "basic"
        |Labeled-> "labeled"
        |Primary-> "primary"
type Button_Parameters=
    {
        Button_text:string
        Button_type:Button_type option
        Button_color:Element_color option
        Attributes:XmlAttribute list
        Children:XmlNode list
        Id:string 
    }
    static member empty(button_text) =
        {
            Button_text=button_text
            Button_type=None
            Button_color=None
            Attributes=[]
            Children=[]
            Id=Kit.getRandomString(24)
        }
[<RequireQualifiedAccess>]
module Button=
    let make (pars:Button_Parameters) =
        let color_ = defaultArg (pars.Button_color|>Option.map (fun i -> i.ToString())) ""
        let type_ = defaultArg (pars.Button_type|>Option.map (fun i -> i.ToString())) ""
        let par= [Attr.class' $"ui %s{color_} %s{type_} button";Attr.id pars.Id]
        let atts_list= par @ pars.Attributes
        let children_list =pars.Children @ [ Text.raw pars.Button_text   ]            
        Elem.div atts_list children_list