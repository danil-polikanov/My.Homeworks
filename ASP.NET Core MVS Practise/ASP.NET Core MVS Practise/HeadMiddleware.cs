using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ASP.NET_Core_MVS_Practise
{
    public class HeadMiddleware
    {
        private readonly RequestDelegate _next;
        public IConfiguration Configuration;
        public HeadMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            Configuration = configuration;
            _next = next;
        }
        public Task InvokeAsync(HttpContext context)
        {

            context.Response.OnStarting(
                          () =>
                          {
                              context.Response.Headers.Add("X-Checked-By", $"{Configuration["LastName"]}");
                              return Task.CompletedTask;
                          });

            return this._next(context);
        }

    }
}
