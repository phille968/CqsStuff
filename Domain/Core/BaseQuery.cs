using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FunctionApp.Domain.Core
{
    public abstract class BaseQuery<TQuery, TIn, TOut> : IQuery<TQuery>
    {
        protected readonly ILogger<TQuery> Logger;

        protected BaseQuery(ILogger<TQuery> logger)
        {
            Logger = logger;
        }

        public abstract Task<TOut> Execute(TIn req);

        protected virtual async Task<TOut> RunQuery(Func<Task<TOut>> func)
        {
            var caller = typeof(TQuery).Name;

            TOut @out;
            try
            {
                Logger.LogInformation($"Executing: {caller}");

                @out = await func();
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Error Executing  Query: {caller}");
                return default;
            }

            Logger.LogInformation($"Executed: {caller}, with result: {System.Text.Json.JsonSerializer.Serialize(@out)}");

            return @out;
        }

        public abstract record Request(params object[] Inupt);
    }
}