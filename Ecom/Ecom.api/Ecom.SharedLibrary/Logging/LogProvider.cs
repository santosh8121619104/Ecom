using Ecom.SharedLibrary.Common;
using Ecom.SharedLibrary.Logging.Interface;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.SharedLibrary.Logging
{
    public class LogProvider : ILogProvider
    {
        private static TelemetryConfiguration telemetryConfiguration;
        private readonly TelemetryClient telemetryClient;
        private static int logLevel = 0;
        private static string serviceName = "Ecom";
        static LogProvider()
        {
            telemetryConfiguration = TelemetryConfiguration.CreateDefault();
        }
        public LogProvider(IOptions<AppSettings> appSettings)
        {
            logLevel = Convert.ToInt32(appSettings.Value.LogLevel);
            telemetryClient = new TelemetryClient(telemetryConfiguration);
            telemetryClient.InstrumentationKey = appSettings.Value.AppInsightInstrumentationKey;
        }
        private void AddExtraProperty(IDictionary<string, string> extraProperty, TraceTelemetry traceTelemetry)
        {
            if (extraProperty != null)
            {
                foreach (var property in extraProperty)
                {
                    traceTelemetry.Properties.Add(property.Key, property.Value);
                }
            }
        }

        private static void AddExtraExceptionProperty(IDictionary<string, string> extraProperty, ExceptionTelemetry telemetry)
        {
            if (extraProperty != null)
            {
                foreach (var property in extraProperty)
                {
                    telemetry.Properties.Add(property.Key, property.Value);
                }
            }
        }

        //level 0 will log only error.
        public void LogError(string error, string correlationId = "", string userName = "", IDictionary<string, string> extraProperty = null) // 0 is Error
        {
            ExceptionTelemetry telemetry = new ExceptionTelemetry(new Exception(error));
            telemetry.Properties.Add("CorrelationId", correlationId);
            telemetry.Properties.Add("ServiceName", serviceName);
            telemetry.Properties.Add("UserName", userName);
            telemetry.Properties.Add("EventDataTime", DateTime.UtcNow.ToShortDateString() + "-" + DateTime.UtcNow.ToShortTimeString());
            AddExtraExceptionProperty(extraProperty, telemetry);
            telemetryClient.TrackException(telemetry);
        }

        //level 0 will log only error.
        public void LogError(Exception exception, string correlationId = "", string userName = "", IDictionary<string, string> extraProperty = null) // 0 is Error
        {
            ExceptionTelemetry telemetry = new ExceptionTelemetry(exception);
            telemetry.Properties.Add("CorrelationId", correlationId);
            telemetry.Properties.Add("ServiceName", serviceName);
            telemetry.Properties.Add("UserName", userName);
            telemetry.Properties.Add("EventDataTime", DateTime.UtcNow.ToShortDateString() + "-" + DateTime.UtcNow.ToShortTimeString());
            AddExtraExceptionProperty(extraProperty, telemetry);
            telemetryClient.TrackException(telemetry);
        }

        //level 1 will log information and error.
        public void LogWarning(string warning, string correlationId = "", string userName = "", IDictionary<string, string> extraProperty = null) // 1 is Warning
        {
            if (logLevel == 1 || logLevel == 2)
            {
                TraceTelemetry traceTelemetry = new TraceTelemetry();
                traceTelemetry.Message = warning;
                traceTelemetry.SeverityLevel = SeverityLevel.Warning;
                traceTelemetry.Properties.Add("CorrelationId", correlationId);
                traceTelemetry.Properties.Add("ServiceName", serviceName);
                traceTelemetry.Properties.Add("UserName", userName);
                traceTelemetry.Properties.Add("EventDataTime", DateTime.UtcNow.ToShortDateString() + "-" + DateTime.UtcNow.ToShortTimeString());
                AddExtraProperty(extraProperty, traceTelemetry);

                telemetryClient.TrackTrace(traceTelemetry);
            }
        }

        //level 2 will log information, warning and error
        public void LogInformation(string information, string correlationId = "", string userName = "", IDictionary<string, string> extraProperty = null) // 2 is Information
        {
            if (logLevel == 2)
            {
                TraceTelemetry traceTelemetry = new TraceTelemetry();
                traceTelemetry.Message = information;
                traceTelemetry.SeverityLevel = SeverityLevel.Information;
                traceTelemetry.Properties.Add("CorrelationId", correlationId);
                traceTelemetry.Properties.Add("ServiceName", serviceName);
                traceTelemetry.Properties.Add("UserName", userName);
                traceTelemetry.Properties.Add("EventDataTime", DateTime.UtcNow.ToShortDateString() + "-" + DateTime.UtcNow.ToShortTimeString());
                AddExtraProperty(extraProperty, traceTelemetry);

                telemetryClient.TrackTrace(traceTelemetry);
            }
        }

        public void Flush()
        {
            telemetryClient.Flush();
        }
    }
}

