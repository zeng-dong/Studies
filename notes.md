# Implementing the Model

Transforming the results of event storming to code.
Different styles of performing the behavior in domain entities.

* What the entities and value objects are
* How to ensure that the domain model is always in a valid state

## the framework
* to place this set of base classes and interfaces
* some components that will allow our domain model to work with things like database, message bus, web server, and so on. According to onion architecture
principles, these are adapters. Our project, in the end, will need to have a collection of adapters for all pieces of infrastructure that are being used.

## Transferring the model to code
1. we need to identify which building blocks our implementation will be based on.
These building blocks are often referenced as Domain-Driven Design (DDD) tactical
patterns, as opposed to DDD strategic patterns. Some even say that tactical patterns can be
ignored in favor of strategic patterns. Although I agree that Ubiquitous Language, Bounded
Context, and Context Map are the essential parts of DDD, I still believe that some tactical
patterns are useful and bring clarity and common language for the implementation.

### Entities

### Value objects
characteristics of value objects as expressiveness and strong encapsulation
* Fundamentally, value objects allow declaring entity properties with explicit types that use Ubiquitous Language. 
* Besides, such objects can explicitly define how they can be created and what operations can be performed within and between them.