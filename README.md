# BlazorWithSerilog
Using Serilog with Blazor


Blazor WASM Client does not support Serilog yet.  I get this error:

Error	BLAZORSDK1001	The project references the ASP.NET Core shared framework, which is not supported by Blazor WebAssembly apps. Remove the framework reference if directly referenced, or the package reference that adds the framework reference.	BlazorWithSerilog.Client	C:\Program Files\dotnet\sdk\5.0.102\Sdks\Microsoft.NET.Sdk.BlazorWebAssembly\targets\Microsoft.NET.Sdk.BlazorWebAssembly.Current.targets	635	

This project contains wrapper classes that work identically on the client and server, so the logger may be injected (via interface) into shared classes.
