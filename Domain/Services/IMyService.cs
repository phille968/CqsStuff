using System.Threading.Tasks;

namespace FunctionApp.Domain.Services
{
    public interface IMyService
    {
        Task<string> ReturnString(string inString);
    }
}