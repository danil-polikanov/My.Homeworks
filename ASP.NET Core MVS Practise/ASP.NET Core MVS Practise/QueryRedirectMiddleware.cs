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
    public class QueryRedirectMiddleware
    {
        private readonly RequestDelegate _next;
        public IConfiguration Configuration;
        public QueryRedirectMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            Configuration = configuration;
            _next = next;
        }
        public Task InvokeAsync(HttpContext context)
        {
            var stringQuery = context.Request.Query["r"].ToString();
            context.Response.Redirect(stringQuery);
            return this._next(context);
        }

    }
}
