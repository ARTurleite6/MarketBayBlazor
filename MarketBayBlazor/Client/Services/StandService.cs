namespace MarketBayBlazor.Client.Services;

public class StandService : IStandService
{
    public HttpClient _httpClient;

    public StandService(HttpClient _httpClient)
    {
        this._httpClient = _httpClient;
    }

    public async Task DesativaStand(StandFeirante stand)
    {
        var res = await this._httpClient.PutAsJsonAsync($"api/stand/{stand.ID}", stand);
        if(res.IsSuccessStatusCode)
        {
            Console.WriteLine("Stand Inativo com sucesso");
        }
        else
        {
            Console.WriteLine("Ocorreu erro a dar update ao stand");
        }
    }

    public async Task<StandFeirante?> GetStand(int ID)
    {
        return await this._httpClient.GetFromJsonAsync<StandFeirante>($"api/stand/{ID}");
    }
}