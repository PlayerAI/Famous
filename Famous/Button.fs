namespace Famous
open Falco.Markup
open Falco
type Button_Attribute_Keyword=
    |Inverted
    |Tertiary
    |Basic
    |Labeled
    |Primary
    |Secondary
    //|Animated
    |Fade
    |Vertical 
    |B_Color of Element_color    
    override t.ToString()=
        match t with
        |Inverted -> " inverted"
        |Tertiary-> " tertiary"
        |Basic-> " basic"
        |Labeled-> " labeled"
        |Secondary-> " secondary"
        |Primary-> " primary"
        //|Animated-> " animated"
        |Fade-> " fade"
        |Vertical -> " vertical"
        |B_Color c -> " "+c.ToString()
        

[<RequireQualifiedAccess>]
module Button= 
    let make (button_text:string) (class_:Button_Attribute_Keyword list) atts_list children_list=
        let cls= 
            class_|>List.map (fun i ->i.ToString()) |>List.fold (fun s t -> s+t) "ui" |>fun i -> i+" button"|> Attr.class'        
        let atts_list= [cls] @ atts_list          
        let children_list =children_list @ [ Text.raw button_text   ]            
        Elem.div atts_list children_list
    let make_animated (class_:Button_Attribute_Keyword list) atts_list (hidden:XmlNode) (visible :XmlNode)=
        let cls= 
            class_|>List.map (fun i ->i.ToString()) |>List.fold (fun s t -> s+t) "ui" |>fun i -> i+" animated button"|> Attr.class'
        let atts_list= [cls;Attr.create "tabindex" "0"] @ atts_list
        Elem.div atts_list [
            Elem.div [Attr.class' "hidden content"] [hidden]
            Elem.div [Attr.class' "visible content"] [visible]
            ]