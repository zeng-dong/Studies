# setting up
1. install or update dapr
	* go to dapr git hub and copy powershell command for installation
	* run
2. run 'dapr init' to install runtime
	* run 'dapr uninstall' to uninstall previous runtime
	* once it complete: 
		* our machine is ready to run Dapper applications in self hosted mode
		*  There are three Docker containers that will have been started 
			* by the way, it's not essential that you have these containers running to use Dapper in self hosted mode you're completely free to define your own Dapper components

There's a reddish container which is . There's a zip king container which is  and there's also a Dapper placement container, which 
. That point to services that aren't running locally as docker containers. Another thing that happened when we ran Dapper in it is that it created a default components folder, which can be found in the dot Dapper folder. It might use a profile. So if I look inside that folder on my computer, you can see that there are two YAML files and these define the state and pub sub Dapa building blocks. And these default components make it even easier for us to get started with local development. And both of these components make use of that dapper reddest container that got created for us with the Dapper in IT command.
3. then can 'docker ps' and see
	* daprio/dapr:1.6.0   "./placement"     : is there in case you want to use the Actor building block
	* zipkin/zipkin                         : used for observability
	* redis                                 : used for the state store and pub sub messaging Dapa building blocks


## install dapr runtime on Kubernetes