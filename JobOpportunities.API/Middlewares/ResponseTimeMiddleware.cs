using JobOpportunities.DataNoSql.CustomLogs;
using System.Diagnostics;

namespace JobOpportunities.API.Middlewares
{
    public class ResponseTimeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMongoDbLogger _logger;

        public ResponseTimeMiddleware(RequestDelegate next, IMongoDbLogger logger)
        {
            _next = next;
            _logger = logger;
        }
        public Task InvokeAsync(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();
            context.Response.OnStarting(() =>
            {
                watch.Stop();
                var apiEndpoint = context.Request.Path.Value;
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
                _logger.LogRequestTime(new ExecutionTime
                {
                    Path = apiEndpoint,
                    Time = responseTimeForCompleteRequest
                });
                return Task.CompletedTask;
            });
            // Call the next delegate/middleware in the pipeline  
            return this._next(context);
        }
    }
}
