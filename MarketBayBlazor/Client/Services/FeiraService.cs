using System;

namespace MarketBayBlazor.Client.Services
{
    public class FeiraService : IFeiraService
    {
        private readonly HttpClient _httpClient;

        public FeiraService(HttpClient _httpClient)
        {
            this._httpClient = _httpClient;
        }

        public async Task<List<Feira>?> GetFeiras()
        {
            var feiras = await this._httpClient.GetFromJsonAsync<List<Feira>>("Feira");
            if (feiras != null)
                return feiras;
            return null;
        }
    }
}

