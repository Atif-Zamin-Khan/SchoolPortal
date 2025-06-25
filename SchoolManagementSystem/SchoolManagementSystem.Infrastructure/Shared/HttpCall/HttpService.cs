using Microsoft.AspNetCore.Http; 
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Shared.HttpCall
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<TResponse?> SendAsync<TRequest, TResponse>(
            HttpMethod method,
            string url,
            TRequest? requestBody = default,
            Dictionary<string, string>? headers = null)
        {
            try
            {
                using var request = new HttpRequestMessage(method, url);

                // Ensure HttpContext and Session are available
                var session = _httpContextAccessor.HttpContext?.Session;
                if (session == null)
                {
                    throw new InvalidOperationException("Session is not available.");
                }


                // Retrieve the stored token from session
                var authToken = session.GetString("Authorization"); // Now this will work

                // Add Authorization header if token exists
                if (!string.IsNullOrEmpty(authToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {authToken}");
                }

                // Add custom headers if provided
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }

                // Add JSON Body for non-GET requests
                if (requestBody != null && method != HttpMethod.Get)
                { 
                    string json = JsonSerializer.Serialize(requestBody);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }

                using var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                // Deserialize response
                var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<TResponse>(responseStream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            catch (HttpRequestException httpEx)
            {
                throw new Exception($"HTTP request error while calling {url}: {httpEx.Message}", httpEx);
            }
            catch (JsonException jsonEx)
            {
                throw new Exception($"Error deserializing response from {url}: {jsonEx.Message}", jsonEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error during HTTP request to {url}: {ex.Message}", ex);
            }

        }
    }
}