using System.Threading.Tasks;

namespace FunctionApp.Domain.Services
{
    public class MyService : IMyService
    {
        public async Task<string> ReturnString(string inString)
        {
            return await Task.FromResult("Am I evil?" + inString);
        }
    }
}