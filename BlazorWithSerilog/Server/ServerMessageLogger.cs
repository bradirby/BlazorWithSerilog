using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWithSerilog.Shared;
using Serilog;

namespace BlazorWithSerilog.Server
{
    public class ServerMessageLogger<T> : IMessageLogger<T>
    {
        private IMessageLogConfiguration LogCfg { get; set; }

        public ServerMessageLogger(IMessageLogConfiguration cfg)
        {
            LogCfg = cfg;
            LocalLoggingLevel = GlobalLoggingLevel;
        }

        public void LogTrace(string msg)
        {
            if (GlobalLoggingLevel > LoggingLevel.Trace && LocalLoggingLevel > LoggingLevel.Trace) return;
            Log.Logger.Verbose($"{typeof(T)} {msg}");
        }

        public void LogDebug(string msg)
        {
            if (GlobalLoggingLevel > LoggingLevel.Debug && LocalLoggingLevel > LoggingLevel.Debug) return;
            Log.Logger.Debug($"{typeof(T)} {msg}");
        }

        public void LogInformation(string msg)
        {
            if (GlobalLoggingLevel > LoggingLevel.Information && LocalLoggingLevel > LoggingLevel.Information) return;
            Log.Logger.Information($"{typeof(T)} {msg}");
        }

        public void LogWarning(string msg)
        {
            if (GlobalLoggingLevel > LoggingLevel.Warning && LocalLoggingLevel > LoggingLevel.Warning) return;
            Log.Logger.Warning($"{typeof(T)} {msg}");
        }

        public void LogError(string msg)
        {
            if (GlobalLoggingLevel > LoggingLevel.Error && LocalLoggingLevel > LoggingLevel.Error) return;
            Log.Logger.Error($"{typeof(T)} {msg}");
        }

        public void LogError(Exception exc)
        {
            if (GlobalLoggingLevel > LoggingLevel.Error && LocalLoggingLevel > LoggingLevel.Error) return;
            Log.Logger.Error($"{typeof(T)} {exc.Message}");
        }

        public void LogError(string msg, Exception exc )
        {
            if (GlobalLoggingLevel > LoggingLevel.Error && LocalLoggingLevel > LoggingLevel.Error) return;
            Log.Logger.Error($"{typeof(T)} {msg} {exc.Message}");
        }

        public void LogCritical(string msg)
        {
            if (GlobalLoggingLevel > LoggingLevel.Critical && LocalLoggingLevel > LoggingLevel.Critical ) return;
            Log.Logger.Fatal($"{typeof(T)} {msg}");
        }


        public LoggingLevel GlobalLoggingLevel
        {
            get => LogCfg.LogLevel;
            set => LogCfg.LogLevel = value;
        }

        public LoggingLevel LocalLoggingLevel { get; set; }
    }
}
