namespace Famous
open Falco.Markup
open Falco
type Element_size=
    |Mini 
    |Tiny 
    |Small
    |Medium 
    |Large 
    |Big 
    |Huge 
    |Massive
    override t.ToString()=
        match t with
        |Mini->"mini" 
        |Tiny ->"tiny" 
        |Small->"small" 
        |Medium ->"medium" 
        |Large ->"large" 
        |Big ->"big" 
        |Huge ->"huge" 
        |Massive->"massive" 
    static member GetAll()=
        [
            Mini 
            Tiny 
            Small
            Medium 
            Large 
            Big 
            Huge 
            Massive
        ]