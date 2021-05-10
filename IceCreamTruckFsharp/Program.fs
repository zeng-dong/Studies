module Infrastructure =
    
    type EventStore<'Event> = 
        {
            Get : unit -> 'Event List
            Append : 'Event list -> unit
        }


module Domain =

    type Flavour =
        | Strawberry
        | Vanilla

    type Event = 
        | Flavour_sold of Flavour
        | Flavour_restocked of Flavour * int
        | Flavour_went_out_of_stock of Flavour
        | Flavour_was_not_in_stock of Flavour

module Helper =
    let printUl list =
        list 
        |> List.iteri(fun i item -> printfn " %i: %A" (i+1) item)

    let printEvents events =
        events
        |> List.length
        |> printfn "History (Length: %i)"


open Infrastructure
open Domain
open Helper

[<EntryPoint>]
let main _ =

    let eventStore : EventStore<Event> = EventStore.initialize()

    eventStore.Append [Flavour_restocked (Vanilla,3)]
    eventStore.Append [Flavour_sold Vanilla]
    eventStore.Append [Flavour_sold Vanilla]
    eventStore.Append [Flavour_sold Vanilla; Flavour_went_out_of_stock Vanilla]

    eventStore.Get()
    |> printEvents


