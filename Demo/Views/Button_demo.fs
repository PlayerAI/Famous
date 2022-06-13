module Button_demo
let par:Famous.Button_Parameters= 
    Famous.Button_Parameters.empty("empty")
let button_demo = 
    Famous.Element_color.GetAll()
    |>List.map (fun i ->
        let p_local={par with Button_color =Some i;Button_text=i.ToString().ToUpper()}
        Famous.Button.make p_local
        )

