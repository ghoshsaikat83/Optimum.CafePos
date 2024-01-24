using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;


namespace Optimum.CafePos.WebServices
{
    public class HttpClientWrapper<T>
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper(string baseUri)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUri) };
        }

        public async Task<T> GetAsync(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var response = await _httpClient.PostAsync(
                endpoint,
                new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(data),
                    Encoding.UTF8,
                    "application/json"
                )
            );

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<TResponse>();
        }
    }
}

