
using Microsoft.AspNetCore.Http;

namespace SchoolManagementSystem.Infrastructure.Shared.HttpCall
{
    public interface IHttpService
    {
        Task<TResponse?> SendAsync<TRequest, TResponse>(HttpMethod method,string url,TRequest? requestBody = default,Dictionary<string, string>? headers = null);
    }
}
