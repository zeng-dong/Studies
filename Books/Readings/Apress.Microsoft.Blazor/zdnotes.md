# source code
https://github.com/PeterHimschoot/microsoft-blazor-book-3

# Blazor templates
* dotnet new --list
* dotnet new blazorwasm --hosted -o MyFirstBlazor
* cd into the server dir
	- dotnet build
	- dotnet run

# files
The Blazor bootstrap process requires a bunch of special files, especially dotnet.wasm 
	* dotnet.wasm is the .NET runtime compiled as WebAssembly
This is served by the Blazor middleware, which is installed by the UseBlazorFrameworkFiles instruction.