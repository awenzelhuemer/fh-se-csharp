using CurrencyConverter.Blazor.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CurrencyConverter.Blazor.Services
{
    public class ConverterService : IConverterService
    {
        private const string ServicePath = "/api/currencies";
        private readonly HttpClient httpClient;

        public ConverterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Response<IEnumerable<CurrencyData>>> GetAllAsync()
        {
            var response = await httpClient.GetAsync(ServicePath);

            IEnumerable<CurrencyData> data = null;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                data = await response.Content.ReadFromJsonAsync<IEnumerable<CurrencyData>>();
            }
            return new Response<IEnumerable<CurrencyData>>(data, response.StatusCode);
        }
    }
}
