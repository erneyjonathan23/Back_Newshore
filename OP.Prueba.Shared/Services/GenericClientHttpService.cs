using Newtonsoft.Json;
using OP.Prueba.Application.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace OP.Prueba.Shared.Services
{
    [ExcludeFromCodeCoverage]
    public class GenericClientHttpService : IGenericClientHttpService
    {
        static HttpClient client = new HttpClient();
        public async Task<TOut> GetRequestAsync<TOut>(string url, CancellationToken cancellationToken,
            string jwtToken, string? keyValue = null, string? keyName = null)
        {
            string responseBody = string.Empty;
            client.DefaultRequestHeaders.Clear();
            if (keyValue != null && keyName != null)
                client.DefaultRequestHeaders.Add(keyName, keyValue);

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<TOut>(responseBody);
        }
    }
}