using Microsoft.AspNetCore.Http;
using s19551DocMid.DTO;
using s19551DocMid.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s19551DocMid.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

       public async Task InvokeAsync(HttpContext context,IDbService writterService)
        {
            LoggingFile file = null;
            if (context.Request != null)
            {
                file = new LoggingFile();
                file.path = context.Request.Path; 
                file.method = context.Request.Method;
                file.queryString = context.Request.QueryString.ToString();
                file.body = "";

                using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    file.body = await reader.ReadToEndAsync();
                }
                writterService.SaveLogData(file);
            }

            if (_next != null) await _next(context);
            
        }
    }
}
