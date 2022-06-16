using ProjetoLocadoraAPI.Model;

namespace ProjetoLocadoraAPI.Repositories.Interfaces
{
    public interface InfLocacaoRepository
    {
        List<Locacao> GetLocacoes();
        Locacao GetLocacao(int idLocacao);
        Locacao AlugarFilme(Locacao locacao);
        Locacao DevolverFilme(Locacao locacao);
        bool ValidaDisponibilidadeFilme(int idFilme);
    }
}
