using System.Threading.Tasks;
using FunctionApp.Domain.Core;
using FunctionApp.Domain.Queries;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace FunctionApp
{
    public class Function1
    {
        private readonly IQueries _queries;

        public Function1(IQueries queries)
        {
            _queries = queries;
        }

        [Function(nameof(Run))]
        public async  Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req, FunctionContext executionContext)
        {
            var result = await _queries.Get<Querynr1>().Execute(new Querynr1.Request(""));

            return HttpResponseData.CreateResponse(req);
        }
    }
}