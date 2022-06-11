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
        Attributes:option<XmlAttribute list>
        Children:option<XmlNode list>
    }
[<RequireQualifiedAccess>]
module Button=
    let make (button_text:string)=
        Elem.button 
            [
            Attr.class' "ui button"    
            ] 
            [
            Text.raw button_text
            ]

    let makes (pars:Button_Parameters) =
        let color_ = defaultArg (pars.Button_color|>Option.map (fun i -> i.ToString())) ""
        let type_ = defaultArg (pars.Button_type|>Option.map (fun i -> i.ToString())) ""
        let par= [Attr.class' $"ui %s{color_} %s{type_} button"]
        let atts_list= 
            match pars.Attributes with
            |Some p -> par@p
            |None -> par
        let children_list =
            match pars.Children with
            |Some c -> c@[ Text.raw pars.Button_text   ]
            |None -> [ Text.raw pars.Button_text   ]
        Elem.button atts_list  children_list