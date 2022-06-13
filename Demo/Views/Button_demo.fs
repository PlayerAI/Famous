module Button_demo
open Famous

let get_script (target_id) (button_name)=
    let s =
        sprintf
            """
            $('body')
                .toast({
                  class: 'success',
                  message: `You have clicked '%s' Button !`
                });
            """ button_name
    Kit.run_script_when_click target_id s
let button_demo = 
    Famous.Element_color.GetAll()
    |>List.map (fun i ->
        let par=Famous.Button_Parameters.empty("empty")
        let p_local=
            {par 
                with 
                    Button_color =Some i;
                    Button_text=i.ToString().ToUpper()
                    Children=[
                        get_script par.Id (i.ToString().ToUpper()) 
                        ]
                    }
        Famous.Button.make p_local
        )

