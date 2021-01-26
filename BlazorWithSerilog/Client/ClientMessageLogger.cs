using System;
using System.Linq;
using BlazorWithSerilog.Shared;

namespace BlazorWithSerilog.Client
{
    public class ClientMessageLogger<T> : IMessageLogger<T>
    {

        private ILogHistory History;
        private IMessageLogConfiguration LogCfg;


        public ClientMessageLogger(IMessageLogConfiguration cfg, ILogHistory hist)
        {
            History = hist;
            LogCfg = cfg;
            LocalLoggingLevel = LogCfg.LogLevel;
        }

        public LoggingLevel LocalLoggingLevel { get;set; }

        public LoggingLevel GlobalLoggingLevel
        {
            get => LogCfg.LogLevel;
            set => LogCfg.LogLevel = value;
        }

        public int MaxHistoryToKeep
        {
            get => History.MaxHistoryToKeep;
            set => History.MaxHistoryToKeep = value;
        }

      
        public void LogHistory(int numRows)
        {
            foreach (var msg in History.GetHistory())
            {
                Console.WriteLine(msg);
            }
        }

        public void LogTrace(string msg)
        {
            var msgToWrite = $"{typeof(T)} {msg}";
            History.RecordHistory($"LogTrace: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Trace && LocalLoggingLevel > LoggingLevel.Trace) return;
            Console.WriteLine(msgToWrite);
        }

        public void LogDebug(string msg)
        {
            var msgToWrite = $"{typeof(T)} {msg}";
            History.RecordHistory($"LogTrace: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Debug && LocalLoggingLevel > LoggingLevel.Debug) return;
            Console.WriteLine(msgToWrite);
        }

        public void LogInformation(string msg)
        {
            var msgToWrite = $"{typeof(T)} {msg}";
            History.RecordHistory($"LogTrace: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Information && LocalLoggingLevel > LoggingLevel.Information) return;
            Console.WriteLine(msgToWrite);
        }

        public void LogWarning(string msg)
        {
            var msgToWrite = $"{typeof(T)} {msg}";
            History.RecordHistory($"LogTrace: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Warning && LocalLoggingLevel > LoggingLevel.Warning) return;
            Console.WriteLine(msgToWrite);
        }

        public void LogError(string msg)
        {
            var msgToWrite = $"{typeof(T)} {msg}";
            History.RecordHistory($"LogTrace: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Error && LocalLoggingLevel > LoggingLevel.Error) return;
            Console.WriteLine(msgToWrite);
        }

        public void LogError(Exception exc)
        {
            var msgToWrite = $"{typeof(T)} {exc.Message}";
            History.RecordHistory($"LogTrace: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Error && LocalLoggingLevel > LoggingLevel.Error) return;
            Console.WriteLine(msgToWrite);
        }

        public void LogError(string msg, Exception exc)
        {
            var msgToWrite = $"{typeof(T)} {msg} {exc.Message}";
            History.RecordHistory($"LogTrace: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Error && LocalLoggingLevel > LoggingLevel.Error) return;
            Console.WriteLine(msgToWrite);
        }

        public void LogCritical(string msg)
        {
            var msgToWrite = $"{typeof(T)} {msg}";
            History.RecordHistory($"LogTrace: {msgToWrite}");
            if (GlobalLoggingLevel > LoggingLevel.Critical && LocalLoggingLevel > LoggingLevel.Critical) return;
            Console.WriteLine(msgToWrite);
        }

    }
}
