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

3. then can 'docker ps' and see
	* daprio/dapr:1.6.0   "./placement"     : is there in case you want to use the Actor building block
	* zipkin/zipkin                         : used for observability
	* redis                                 : used for the state store and pub sub messaging Dapa building blocks

4. and it created a default components folder, which can be found in the dot Dapper folder:
	* ls $env:USERPROFILE\.dapr\components

## install dapr runtime on Kubernetes

# start a sidecar
* dapr run --dapr-http-port 3500