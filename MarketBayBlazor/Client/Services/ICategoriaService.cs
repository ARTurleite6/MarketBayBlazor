namespace MarketBayBlazor.Client.Services;

public interface ICategoriaService
{
    public Task<List<Categoria>?> GetCategorias(); 
}