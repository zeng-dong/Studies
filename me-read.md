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