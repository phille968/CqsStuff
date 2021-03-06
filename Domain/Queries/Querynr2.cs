using System.Threading.Tasks;
using FunctionApp.Domain.Core;
using FunctionApp.Domain.Services;
using Microsoft.Extensions.Logging;

namespace FunctionApp.Domain.Queries
{
    public class Querynr2 : BaseQuery<Querynr1, Querynr2.Request, string>
    {
        private readonly IMyService _myService;

        public Querynr2(IMyService myService, ILogger<Querynr1> logger) : base(logger)
        {
            _myService = myService;
        }

        public override async Task<string> Execute(Request req) =>
            await RunQuery(async () =>
            {
                return await _myService.ReturnString(req.InString);
            });

        public new record Request(string InString);
    }
}