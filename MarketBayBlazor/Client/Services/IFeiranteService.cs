namespace MarketBayBlazor.Client.Services;
public interface IFeiranteService
{
    public Task<bool> RegistaFeirante(FeiranteDTO feirante);
}