using System;

namespace BlazorWithSerilog.Shared
{
    public interface IMessageLogger<T>
    {
        void LogTrace(string msg);

        void LogDebug(string msg);

        void LogInformation(string msg);
        
        void LogError(string msg);
        
        void LogWarning(string msg);
        
        void LogError(Exception exc);
       
        void LogError(string msg, Exception exc);

        void LogCritical(string msg);

        LoggingLevel LocalLoggingLevel { get; set; }

        LoggingLevel GlobalLoggingLevel { get; set; }
    }
}
