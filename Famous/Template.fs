namespace Famous
open Falco.Markup
open Falco
[<RequireQualifiedAccess>]
module Template =
    let showcase title description content=
        Elem.div [Attr.class' "spaced example" ] [
            Elem.h4 [Attr.class' "ui header"] [Text.raw title]
            Elem.p [] [Text.raw description]
            Elem.div [Attr.class' "html" ] content
            ]

