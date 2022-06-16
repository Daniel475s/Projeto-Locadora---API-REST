using ProjetoLocadoraAPI.Model;

namespace ProjetoLocadoraAPI.Repositories.Interfaces
{
    public interface InfFilmeRepository
    {
        List<Filme> GetFilmes();
        Filme GetFilme(int idFilme);
        Filme CadastrarFilme(Filme filme);
    }
}
