# Implementing the Model

Transforming the results of event storming to code.
Different styles of performing the behavior in domain entities.

* What the entities and value objects are
* How to ensure that the domain model is always in a valid state

## the framework
* to place this set of base classes and interfaces
* some components that will allow our domain model to work with things like database, message bus, web server, and so on. According to onion architecture
principles, these are adapters. Our project, in the end, will need to have a collection of adapters for all pieces of infrastructure that are being used.
