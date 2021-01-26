using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWithSerilog.Shared;

namespace BlazorWithSerilog.Server.Controllers
{
    public class SampleExternalClass : ISampleExternalClass
    {
        private IMessageLogger<SampleExternalClass> MsgLogger;

        public SampleExternalClass(IMessageLogger<SampleExternalClass> log)
        {
            MsgLogger = log;
        }

        public void EchoLogLevels()
        {
            MsgLogger.LogCritical($"--------------------------------------");
            MsgLogger.LogCritical($"MsgLogger - local log level {MsgLogger.LocalLoggingLevel}");
            MsgLogger.LogCritical($"MsgLogger - global log level {MsgLogger.GlobalLoggingLevel}");
            MsgLogger.LogTrace($"MsgLogger - this is a trace message");
            MsgLogger.LogTrace($"MsgLogger - this is a trace message");
            MsgLogger.LogDebug($"MsgLogger - this is a debug message");
            MsgLogger.LogInformation($"MsgLogger - this is an info message");
            MsgLogger.LogWarning($"MsgLogger - this is a warning message");
            MsgLogger.LogError($"MsgLogger - this is an error message");
            MsgLogger.LogCritical($"MsgLogger - this is a critical/fatal message");
        }
    }

    public interface ISampleExternalClass
    {
        void EchoLogLevels();
    }
}
