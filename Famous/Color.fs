namespace Famous
open Falco.Markup
open Falco
type Element_color=
    |Red 
    |Orange 
    |Yellow
    |Olive 
    |Green 
    |Teal 
    |Blue 
    |Violet 
    |Purple 
    |Pink 
    |Brown 
    |Grey 
    |Black 
    override t.ToString()=
        match t with
        |Red ->"red"
        |Orange ->"orange"
        |Yellow->"yellow"
        |Olive ->"olive"
        |Green ->"green"
        |Teal ->"teal"
        |Blue ->"blue"
        |Violet ->"violet"
        |Purple ->"purple"
        |Pink ->"pink"
        |Brown ->"brown"
        |Grey ->"grey"
        |Black->"black"
    static member GetAll()=
        [
            Red 
            Orange 
            Yellow
            Olive 
            Green 
            Teal 
            Blue 
            Violet 
            Purple 
            Pink 
            Brown 
            Grey 
            Black
        ]