using BlazorWithSerilog.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog.Core;
using Serilog.Events;

namespace BlazorWithSerilog.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMessageLogger<WeatherForecastController> MsgLogger;
        private readonly ISampleExternalClass SampleClass;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMessageLogger<WeatherForecastController> msgLogger, ISampleExternalClass sample)
        {
            _logger = logger;
            MsgLogger = msgLogger;
            SampleClass = sample;

            EchoNativeSerilogLevel();
            EchoLogLevels();
            SampleClass.EchoLogLevels();

            MsgLogger.LogCritical($"--------------------------------------");
            MsgLogger.LogCritical("Changing local level to Information level");
            MsgLogger.LocalLoggingLevel = LoggingLevel.Information;
            EchoLogLevels();
            SampleClass.EchoLogLevels();

            MsgLogger.LogCritical($"--------------------------------------");
            MsgLogger.LogCritical("Changing global level to Debug level");
            MsgLogger.GlobalLoggingLevel = LoggingLevel.Debug;
            EchoLogLevels();
            SampleClass.EchoLogLevels();

            MsgLogger.LogCritical($"////////////////////////////////");
            MsgLogger.LogCritical("writing history");
            MsgLogger.MaxHistoryToKeep = 30;
            for (int n = 0; n < 200; n++)
            {
                MsgLogger.LogDebug($"msg num {n}");
            }
            MsgLogger.LogHistory(50);

        }

        private void EchoLogLevels()
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

        private void EchoNativeSerilogLevel()
        {
            MsgLogger.LogCritical($"--------------------------------------");
            _logger.LogCritical($"Current log level is {CurrentLogLevel()}");

            _logger.LogTrace("BuiltInLogger - this is a trace message");
            _logger.LogDebug("BuiltInLogger - this is a debug message");
            _logger.LogInformation("BuiltInLogger - this is an info message");
            _logger.LogWarning("BuiltInLogger - this is a warning message");
            _logger.LogError("BuiltInLogger - this is an error message");
            _logger.LogCritical("BuiltInLogger - this is a critical/fatal message");

        }


        private string CurrentLogLevel()
        {
            var level = "";
            if (_logger.IsEnabled(LogLevel.None)) level += "None ";
            if (_logger.IsEnabled(LogLevel.Trace)) level += "Trace ";
            if (_logger.IsEnabled(LogLevel.Debug)) level += "Debug ";
            if (_logger.IsEnabled(LogLevel.Information)) level += "Info ";
            if (_logger.IsEnabled(LogLevel.Warning)) level += "Warn ";
            if (_logger.IsEnabled(LogLevel.Error)) level += "Err ";
            if (_logger.IsEnabled(LogLevel.Critical)) level += "Crit ";
            return level;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
