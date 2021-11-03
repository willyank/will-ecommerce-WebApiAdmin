using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgStore.Framework.Logs
{
    public class SerilogLoggerService : ILoggerService
    {
        public SerilogLoggerService()
        {
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            // .Enrich.WithProperty("teste", "testeeee")
            .Enrich.WithExceptionDetails()
            //.MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File(                
                path: "logs/log-.txt",                
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}][{ClientIP}] {Message}{Body}{NewLine}{Exception}",
                // formatter: new JsonFormatter(renderMessage: true),
                rollingInterval: RollingInterval.Day,
                rollOnFileSizeLimit: true)
            .CreateLogger();
        }

        public void Dispose()
        {
            Log.CloseAndFlush();
        }

        public void Error(Exception ex, string error)
        {
            Log.Error(ex, error);
        }

        public void Info(string info)
        {
            Log.Information(info);
        }

        public void Warning(string warn)
        {
            throw new NotImplementedException();
        }
    }
}
