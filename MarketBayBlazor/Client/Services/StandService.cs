namespace MarketBayBlazor.Client.Services;

public class StandService : IStandService
{
    public HttpClient _httpClient;

    public StandService(HttpClient _httpClient)
    {
        this._httpClient = _httpClient;
    }

    public async Task<StandFeirante?> GetStand(int ID)
    {
        return await this._httpClient.GetFromJsonAsync<StandFeirante>($"api/stand/{ID}");
    }
}