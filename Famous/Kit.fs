namespace Famous
open Falco.Markup
open Falco
module Kit= 
    let private random = new System.Random()
    let getRandomString(length:int)=
        let chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray()
        let stringChars=Array.init length (fun i -> chars.[random.Next(chars.Length)] ) 
        new string(stringChars)
    let inline getId_Attr()=getRandomString(24)|>Attr.id
    let inline getId()=getRandomString(24)
    let inline get_cls (classes_:_ list) =   
        classes_
        |>List.map (fun i ->i.ToString()) 
        |>List.fold (fun s t -> s + " " + t) " "
        |>fun r -> r + " "