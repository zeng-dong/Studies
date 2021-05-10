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




open Infrastructure
open Domain

[<EntryPoint>]
let main _ =

    let eventStore : EventStore<Event> = EventStore.initialize()

    eventStore.Append [Flavour_restocked (Vanilla,3)]

