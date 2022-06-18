namespace Famous
open Falco.Markup
open Falco
type Ad_cls = 
    |Ad_Rectangle 
    |Ad_Leaderboard
    |Ad_Banner 
    |Ad_Test
    |Ad_Mobile 
    |Ad_Button 
    |Ad_Square 
    |Ad_Vertical 
    |Ad_Top 
    |Ad_Half 
    |Ad_Panorama 
    |Ad_size of Element_size
    override t.ToString()=
       match t with
       |Ad_Rectangle -> "rectangle"
       |Ad_Leaderboard->"leaderboard"
       |Ad_Banner ->"banner"
       |Ad_Test->"test "
       |Ad_Mobile ->"mobile"
       |Ad_Button ->"button"
       |Ad_Square ->"square"
       |Ad_Vertical ->"vertical"
       |Ad_Top ->"top"
       |Ad_Half ->"half"
       |Ad_Panorama ->"panorama"
       |Ad_size element_size->element_size.ToString()       
module Advertisement=
    let make 
        (ad_classes:Ad_cls list)
        (ad_content:string)
        =
        let cls= 
            ad_classes
            |>List.map (fun i ->i.ToString()) 
            |>List.fold (fun s t -> s+t) "ui " 
            |>fun i -> i+" ad"|> Attr.class'        
        Elem.div [cls] [Text.raw ad_content]
