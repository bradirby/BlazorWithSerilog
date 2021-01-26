# BlazorWithSerilog
Using Serilog with Blazor

This is a sample project to demonstrate how to use Serilog with Blazor.  Since Blazor does not support Serilog yet, this is really just a demonstration of using Serilog with .NET Core.  However I've added wrapper classes around the loggers on the server and client which both implement a shared interface.  This abstracts the Serilog logger so the same log surface area can be used on both the client and server.  This also allows the logger to be injected into classes that are shared between the client and server.

I've added a local and global log level setting which can be changed at run time in response to errors.  Logs are written if they qualify in either the global or local setting.

I also added a log history which retroactively logs all messages regardless of severity level.  This is useful in exception handlers when the log level is set to something high (like Warning) but you want to see the 20 most recent logs.

