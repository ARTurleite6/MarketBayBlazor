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

        public async Task<List<StandFeirante>?> GetStandsFeira(int id)
        {
            var stands = await _httpClient.GetFromJsonAsync<List<StandFeirante>>($"Feira/Stands/{id}");
            if(stands != null)
            {
                foreach(var stand in stands)
                {
                    Console.WriteLine(stand.ID);
		        }

                return stands;
	        }
            return null;
	    }

        public async Task<Feira?> GetFeira(int id) 
        {
            var feira = await this._httpClient.GetFromJsonAsync<Feira>($"Feira/{id}");
            return feira;
        }
    }
}

