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

        public Task<List<Feira>?> GetFeiras()
        {
            var feiras = this._httpClient.GetFromJsonAsync<List<Feira>>("api/Feira");
            return feiras;
        }

        public async Task<List<StandFeirante>?> GetStandsFeira(int id)
        {
            var stands = await _httpClient.GetFromJsonAsync<List<StandFeirante>>($"api/Feira/Stands/{id}");
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

        public Task<Feira?> GetFeira(int id) 
        {
            var feira = this._httpClient.GetFromJsonAsync<Feira>($"api/Feira/{id}");
            return feira;
        }

        public async Task InscreveEmFeira(FeiraSubmitDTO request)
        {
            var stand = await this._httpClient.PostAsJsonAsync($"api/Feira/Inscrever/{request.FeiraID}", request);
            if(stand.IsSuccessStatusCode)
            {
                Console.WriteLine("Stand adicionado com sucesso");
            }
        }

        public async Task<List<Feira>?> GetFeirasOrganizador(int id)
        {
            var feiras = await this._httpClient.GetFromJsonAsync<List<Feira>>($"api/feira/organizador/{id}");
            return feiras;
        }
    }
}

