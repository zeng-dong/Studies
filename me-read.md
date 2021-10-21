# main challenges and mitigations

* Storage Growth — since data store is append only, table will grow indefinitely. 
	This can be mitigated using snapshots or retention policy strategies.
* Replaying Events — if the amount of events for constructing Aggregate is large it might lead to some performance issue when reconstructing 
	the current state of the aggregate. 
	This can be mitigated by using snapshots.
* Events versioning and events handling — when changing existing event, or adding/deleting features, a code which projected old events MUST be in place, 
	since it is used to reconstruct the state to the actual state. This means that if some feature is deprecated, its code cannot be removed 
	since it is used to reconstruct the state at that time. 
	This challenge is a bit harder to overcome but it can be mitigated.

# Event Store considerations
Requirements for the event store are the following:
* It is append only which means there is no update only insert
* It should store aggregate state and allow fetching events for given aggregate in order they were saved.
* It should use optimistic concurrency check: Optimistic concurrency check does not use locking on database level, 
	therefore reducing risk of deadlocks. Instead, concurrency check is done when saving.