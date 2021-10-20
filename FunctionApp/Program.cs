using System;
using FunctionApp.Domain;
using FunctionApp.Domain.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FunctionApp
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(s => s
                    .AddDomain()
                    .AddQueries())

                .Build();

            SanityCheck(host);

            host.Run();
        }

        private static void SanityCheck(IHost host)
        {
            var scope = host.Services.CreateScope();
            try
            {
                var list = Queries.QueriesLedger(scope.ServiceProvider);

                foreach (var (type, _) in list)
                {
                    var _ = scope.ServiceProvider.GetService(type) ?? throw new Exception($"BaseQuery: { type.Name } is not a configured service in Service Collection.");
                }
            }
            finally
            {
                scope.Dispose();
            }
        }
    }
}