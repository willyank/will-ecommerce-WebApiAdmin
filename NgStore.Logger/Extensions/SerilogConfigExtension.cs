using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgStore.Logger.Extensions
{
    public class SerilogConfigExtension
    {
        static void SerilogWebapiConfig(IApplicationBuilder app)
        {
         //   app.UseSerilogRequestLogging();
        }
    }
}
