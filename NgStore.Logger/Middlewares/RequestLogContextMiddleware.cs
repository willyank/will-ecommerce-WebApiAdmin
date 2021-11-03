using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NgStore.Logger.Middlewares
{
    public class RequestLogContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDiagnosticContext diagnosticContext;

        public RequestLogContextMiddleware(RequestDelegate next, IDiagnosticContext diagnosticContext)
        {
            _next = next;
            this.diagnosticContext = diagnosticContext;
        }

        public async Task Invoke(HttpContext context)
        {
            // Read and log request body data
            string requestBodyPayload = await ReadRequestBody(context.Request);

            if (!string.IsNullOrEmpty(requestBodyPayload))
            {
                requestBodyPayload = $"\r\n{requestBodyPayload.Trim()}";
                // LogContext.PushProperty("Body", requestBodyPayload);
            }
            this.diagnosticContext.Set("Body", requestBodyPayload);
            this.diagnosticContext.Set("ClientIP", context.Connection.RemoteIpAddress);
            // LogContext.PushProperty("ClientIP", context.Connection.RemoteIpAddress).Dispose();

            await _next(context);
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            HttpRequestRewindExtensions.EnableBuffering(request);

            var body = request.Body;
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            string requestBody = Encoding.UTF8.GetString(buffer);
            
            body.Seek(0, SeekOrigin.Begin);
            request.Body = body;

            //return requestBody.Replace("\"", "'");
            return requestBody;
            
        }

    }
}
