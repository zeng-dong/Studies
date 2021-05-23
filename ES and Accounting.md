# Event Sourcing and the History of Accounting

## Event sourcing is a software architecture concept that's based around the idea that instead of focusing on persisting the state of your application, 
you should persist the stream of events which got it into it's current state. 

## The classic example is a bank ledger
* Instead of storing the value of each account at the current moment and updating those values, 
* instead you store each transaction (event), 
* and the value in the account is just a projection of those events.

## Auditability is the most obvious benefit of event sourcing
but it also gives you a lot of flexibility. 
You can go back and "query" the event stream to build up new projections of the original data you never would have thought to. 
Imagine a banking system where the values of an account were just stored as mutable entries in a database. 
Even ignoring the lack of an audit trail, you could never go back and ask questions like "what day do most of our transactions occur on". 
By storing the event stream, you can answer these questions even if you never thought to ask them when you designed the system.

# challenges
## storage
Since each event must be added to an append-only data store, the data will grow forever. Snapshots and retention policies can mitigate this but at the cost of loosing the ability to query back to the beginning of time.
## performance
you must "replay" each event to build up the state of the application. Typically this happens on application startup. As the event store grows, this can become a performance concern. Again, snapshots of the state can easily reduce the pain here by limiting the number of events which must be replayed.
## reliablity
the code which projects those events into their current state must be effectively immutable. This challenge is more fundamental to the concept of event sourcing and is more difficult to overcome.

# 1494 Luca Pacioli
a friend of Leonardo da Vinci
he concept of double-entry bookkeeping
Each transaction would be logged along with the new balance. 
The idea revolutionized accounting and Pacioli is known to this day as the father of modern bookkeeping. Venetian merchants could now track inventory, balances over time, and track credits and debits.

# Double Entry Accounting and Event Sourcing
