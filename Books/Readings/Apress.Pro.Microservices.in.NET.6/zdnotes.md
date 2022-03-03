# chapter 4 First Microservice

## interprocess communication
* IPC
* two major drawbacks of using RPC-style communication
	* latency
	* must know the network address.
		- server discovery

## Transport Mechanisms

# REST 
* transfer data using stateless connections
* provides a form of state over the stateless protocol HTTP
* The development of HTTP 1.1 and Uniform Resource Identifiers standards utilized REST
* best suited for text-based payloads and not binary payloads

# gRPC
* a binary protocl 
* type specific and uses Protocol Buffers to serialize and deserialize data
    * so you must know the type definitions at design time for both parties to understand how to manage the data
    * proto definition files to define our data structure

    