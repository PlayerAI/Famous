namespace Famous
open Falco.Markup
open Falco
type Ad_classes = 
    |Rectangle 
    |Leaderboard
    |Banner 
    |Test
    |Mobile 
    |Button 
    |Square 
    |Vertical 
    |Top 
    |Half 
    |Panorama 
    |Ad_size of Element_size
    override t.ToString()=
       match t with
       |Rectangle -> "rectangle"
       |Leaderboard->"leaderboard"
       |Banner ->"banner"
       |Test->"test "
       |Mobile ->"mobile"
       |Button ->"button"
       |Square ->"square"
       |Vertical ->"vertical"
       |Top ->"top"
       |Half ->"half"
       |Panorama ->"panorama"
       |Ad_size element_size->element_size.ToString()       
module Advertisement=
    let make 
        (ad_classes:Ad_classes list)
        (ad_content:string)
        =
        let cls= 
            ad_classes
            |>List.map (fun i ->i.ToString()) 
            |>List.fold (fun s t -> s+t) "ui " 
            |>fun i -> i+" ad"|> Attr.class'        
        Elem.div [cls] [Text.raw ad_content]
