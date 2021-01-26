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
        private ILogHistory History;

        public int MaxHistoryToKeep
        {
            get => History.MaxHistoryToKeep;
            set => History.MaxHistoryToKeep = value;
        }

        public ServerMessageLogger(IMessageLogConfiguration cfg, ILogHistory hist)
        {
            History = hist;
            LogCfg = cfg;
            LocalLoggingLevel = GlobalLoggingLevel;
        }

        public void LogTrace(string msg)
        {
            var msgToWrite = $"{typeof(T)} {msg}";
            History.RecordHistory($"LogTrace: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Trace && LocalLoggingLevel > LoggingLevel.Trace) return;
            Log.Logger.Verbose(msgToWrite);
        }

        public void LogDebug(string msg)
        {
            var msgToWrite = $"{typeof(T)} {msg}";
            History.RecordHistory($"LogDebug: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Debug && LocalLoggingLevel > LoggingLevel.Debug) return;
            Log.Logger.Debug(msgToWrite);
        }

        public void LogInformation(string msg)
        {
            var msgToWrite = $"{typeof(T)} {msg}";
            History.RecordHistory($"LogInformation: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Information && LocalLoggingLevel > LoggingLevel.Information) return;
            Log.Logger.Information(msgToWrite);
        }

        public void LogWarning(string msg)
        {
            var msgToWrite = $"{typeof(T)} {msg}";
            History.RecordHistory($"LogWarning: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Warning && LocalLoggingLevel > LoggingLevel.Warning) return;
            Log.Logger.Warning(msgToWrite);
        }

        public void LogError(string msg)
        {
            var msgToWrite = $"{typeof(T)} {msg}";
            History.RecordHistory($"LogError: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Error && LocalLoggingLevel > LoggingLevel.Error) return;
            Log.Logger.Error(msgToWrite);
        }

        public void LogError(Exception exc)
        {
            var msgToWrite = $"{typeof(T)} {exc.Message}";
            History.RecordHistory($"LogError: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Error && LocalLoggingLevel > LoggingLevel.Error) return;
            Log.Logger.Error(msgToWrite);
        }

        public void LogError(string msg, Exception exc )
        {
            var msgToWrite = $"{typeof(T)} {msg} {exc.Message}";
            History.RecordHistory($"LogError: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Error && LocalLoggingLevel > LoggingLevel.Error) return;
            Log.Logger.Error(msgToWrite);
        }

        public void LogCritical(string msg)
        {
            var msgToWrite = $"{typeof(T)} {msg}";
            History.RecordHistory($"LogCritical: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Critical && LocalLoggingLevel > LoggingLevel.Critical ) return;
            Log.Logger.Fatal(msgToWrite);
        }


        public LoggingLevel GlobalLoggingLevel
        {
            get => LogCfg.LogLevel;
            set => LogCfg.LogLevel = value;
        }
        public LoggingLevel LocalLoggingLevel { get; set; }

        public void LogHistory(int numRows)
        {
            foreach (var msg in History.GetHistory())
            {
                Log.Logger.Error(msg);
            }
        }

    }
}
