namespace Famous
open Falco.Markup
open Falco
type Button_Attribute_Keyword=
    |Inverted
    |Tertiary
    |Basic
    |Labeled
    |Left
    |Primary
    |Secondary
    //|Animated
    |Fade
    |Vertical 
    |B_Color of Element_color  
    |B_Size of Element_size 
    |Icon
    |Right_Pointing
    |Right_Floated    
    |Left_Floated
    |Left_attached
    |Right_attached
    |Toggle
    |Circular
    |Stackable 
    |Loading
    |Disable
    override t.ToString()=
        match t with
        |Inverted -> " inverted"
        |Tertiary-> " tertiary"
        |Basic-> " basic"
        |Labeled-> " labeled"
        |Secondary-> " secondary"
        |Primary-> " primary"
        |Left->"left"
        //|Animated-> " animated"
        |Fade-> " fade"
        |Vertical -> " vertical"
        |B_Color c -> " "+c.ToString()
        |B_Size s -> " "+s.ToString()
        |Icon -> " icon"
        |Right_Pointing->" right pointing"
        |Right_Floated->" right floated"
        |Left_Floated->" left floated"
        |Right_attached->" right attached"
        |Left_attached->" left attached"
        |Toggle -> " toggle"
        |Circular -> " circular"
        |Stackable -> " stackable"
        |Loading -> " loading"
        |Disable -> " dsable"


[<RequireQualifiedAccess>]
module Button= 
    let make (button_text:string) (class_:Button_Attribute_Keyword list) atts_list children_list=
        let cls= 
            class_|>List.map (fun i ->i.ToString()) |>List.fold (fun s t -> s+t) "ui" |>fun i -> i+" button"|> Attr.class'        
        let atts_list= [cls] @ atts_list          
        let children_list =children_list @ [ Text.raw button_text   ]            
        Elem.div atts_list children_list
    /// class: [Vertical;Fade]
    let make_animated (class_:Button_Attribute_Keyword list) atts_list (hidden:XmlNode) (visible :XmlNode)=
        let cls= 
            class_|>List.map (fun i ->i.ToString()) |>List.fold (fun s t -> s+t) "ui" |>fun i -> i+" animated button"|> Attr.class'
        let atts_list= [cls;Attr.create "tabindex" "0"] @ atts_list
        Elem.div atts_list [
            Elem.div [Attr.class' "hidden content"] [hidden]
            Elem.div [Attr.class' "visible content"] [visible]
            ]
    /// class: [Left;Right_Pointing;Icon]
    let make_labeled (class_:Button_Attribute_Keyword list) atts_list (label_text_node:XmlNode) (button_node_list :XmlNode list)=
        let is_left=class_|>List.contains Left
        let cls= 
            if is_left then "ui left labeled button" else "ui labeled button"
            |> Attr.class'            
        let atts_list= [cls;Attr.create "tabindex" "0"] @ atts_list
        //---
        let without_left= class_ |>List.filter( fun i -> i<> Left && i<> Right_Pointing && i<> Icon) 
        let cls_left= 
            without_left|>List.map (fun i ->i.ToString()+" ") |>List.fold (fun s t -> s+t) ""
        let a_cls = 
            if (class_|>List.contains Right_Pointing) 
            then $"ui basic right pointing %s{cls_left} label" 
            else $"ui basic %s{cls_left} label" 
        let a_= Elem.a [Attr.class' a_cls] [label_text_node]
        let div_cls = 
            if (class_|>List.contains Icon) 
            then $"ui icon %s{cls_left} button" 
            else $"ui %s{cls_left} button"
        let div_=Elem.div [Attr.class' div_cls] button_node_list
        let children=
            if is_left then [a_;div_] else [div_;a_;]
        Elem.div atts_list children
    /// class_: B_Color
    let make_icon (class_:Button_Attribute_Keyword list) (icon_:XmlNode) atts_list children_list=
        let cls= 
            class_|>List.map (fun i ->i.ToString()) |>List.fold (fun s t -> s+t) "ui" |>fun i -> i+" icon button"|> Attr.class'        
        let atts_list= [cls] @ atts_list          
        let children_list =  [ icon_  ] @ children_list       
        Elem.div atts_list children_list
    /// class_: B_Color
    let make_grouped (class_:Button_Attribute_Keyword list) atts_list children_list=
        let cls= 
            class_|>List.map (fun i ->i.ToString()) |>List.fold (fun s t -> s+t) "ui" |>fun i -> i+" buttons"|> Attr.class'        
        let atts_list= [cls] @ atts_list          
        let children_list =  children_list       
        Elem.div atts_list children_list
    /// class_: B_Color
    let make_grouped_icon (class_:Button_Attribute_Keyword list) atts_list children_list=
        let cls= 
            class_|>List.map (fun i ->i.ToString()) |>List.fold (fun s t -> s+t) "ui" |>fun i -> i+" icon buttons"|> Attr.class'        
        let atts_list= [cls] @ atts_list          
        let children_list =  children_list       
        Elem.div atts_list children_list
    ///todo:conditional
    let make_conditional (connect_text:string) (left_button:XmlNode) (right_button:XmlNode)=            
        Elem.div [Attr.class' "ui buttons"] [
            left_button
            Elem.div [Attr.class' "or"; Attr.create "data-text" connect_text] []
            right_button
        ]
    ///todo:States