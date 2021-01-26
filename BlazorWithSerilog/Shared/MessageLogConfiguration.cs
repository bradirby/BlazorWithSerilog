using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWithSerilog.Shared
{
    public class MessageLogConfiguration : IMessageLogConfiguration
    {
        public LoggingLevel LogLevel { get; set; } = LoggingLevel.Warning;
    }

    public interface IMessageLogConfiguration
    {
        LoggingLevel LogLevel { get; set; }
    }
}
