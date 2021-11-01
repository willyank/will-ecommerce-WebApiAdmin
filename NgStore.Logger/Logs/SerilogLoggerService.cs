using Serilog;
using Serilog.Events;
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
            //     .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //.Enrich.FromLogContext()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("logs/log.txt",
                rollingInterval: RollingInterval.Day,
                rollOnFileSizeLimit: true)
            .CreateLogger();
        }
        public void Debug(string debug)
        {
            Log.Information("Hello, Serilog! debug");
        }

        public void Dispose()
        {
            Log.CloseAndFlush();
        }

        public void Error(string error)
        {
            throw new NotImplementedException();
        }

        public void Info(string info)
        {
            Log.Information("Hello, Serilog!");
        }

        public void Warning(string warn)
        {
            throw new NotImplementedException();
        }
    }
}
