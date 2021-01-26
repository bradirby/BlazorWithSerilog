using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWithSerilog.Shared;

namespace BlazorWithSerilog.Client
{
    public class ClientMessageLogger<T> : IMessageLogger<T>
    {
        private IMessageLogConfiguration LogCfg;


        public ClientMessageLogger(IMessageLogConfiguration cfg)
        {
            LogCfg = cfg;
            LocalLoggingLevel = LogCfg.LogLevel;
            Console.WriteLine($"global is {GlobalLoggingLevel}");
            Console.WriteLine($"initializing local to {LocalLoggingLevel}");
        }

        public LoggingLevel LocalLoggingLevel { get;set; }

        public LoggingLevel GlobalLoggingLevel
        {
            get => LogCfg.LogLevel;
            set => LogCfg.LogLevel = value;
        }

        public void LogTrace(string msg)
        {
            if (GlobalLoggingLevel > LoggingLevel.Trace && LocalLoggingLevel > LoggingLevel.Trace) return;
            Console.WriteLine($"{typeof(T)} {msg}");
        }

        public void LogDebug(string msg)
        {
            if (GlobalLoggingLevel > LoggingLevel.Debug && LocalLoggingLevel > LoggingLevel.Debug) return;
            Console.WriteLine($"{typeof(T)} {msg}");
        }

        public void LogInformation(string msg)
        {
            if (GlobalLoggingLevel > LoggingLevel.Information && LocalLoggingLevel > LoggingLevel.Information) return;
            Console.WriteLine($"{typeof(T)} {msg}");
        }

        public void LogWarning(string msg)
        {
            if (GlobalLoggingLevel > LoggingLevel.Warning && LocalLoggingLevel > LoggingLevel.Warning) return;
            Console.WriteLine($"{typeof(T)} {msg}");
        }

        public void LogError(string msg)
        {
            if (GlobalLoggingLevel > LoggingLevel.Error && LocalLoggingLevel > LoggingLevel.Error) return;
            Console.WriteLine($"{typeof(T)} {msg}");
        }

        public void LogError(Exception exc)
        {
            if (GlobalLoggingLevel > LoggingLevel.Error && LocalLoggingLevel > LoggingLevel.Error) return;
            Console.WriteLine($"{typeof(T)} {exc.Message}");
        }

        public void LogError(string msg, Exception exc)
        {
            if (GlobalLoggingLevel > LoggingLevel.Error && LocalLoggingLevel > LoggingLevel.Error) return;
            Console.WriteLine($"{typeof(T)} {msg} {exc.Message}");
        }

        public void LogCritical(string msg)
        {
            if (GlobalLoggingLevel > LoggingLevel.Critical && LocalLoggingLevel > LoggingLevel.Critical) return;
            Console.WriteLine($"{typeof(T)} {msg}");
        }

    }
}
