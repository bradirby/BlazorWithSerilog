using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWithSerilog.Shared
{
    public class MessageLogConfiguration : IMessageLogConfiguration
    {
        /// <summary>
        /// Logging level active for all logs.  If a message qualifies for this level, or the local level, it is written out.
        /// </summary>
        public LoggingLevel LogLevel { get; set; } = LoggingLevel.Warning;

        public int MaxHistoryToKeep { get; set; } = 100;

    }

    public interface IMessageLogConfiguration
    {
        LoggingLevel LogLevel { get; set; }
        int MaxHistoryToKeep { get; set; }
    }
}
