namespace MarketBayBlazor.Client.Services;
public interface IFeiranteService
{
    public Task<bool> RegistaFeirante(FeiranteDTO feirante);

    public Task<Feirante?> GetFeirante(int ID);
}