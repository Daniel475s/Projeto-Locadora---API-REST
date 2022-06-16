using ProjetoLocadoraAPI.DTOs;

namespace ProjetoLocadoraAPI.Services.Interfaces
{
    public interface InfLocacaoService
    {
        List<LocacaoDTOOutput> GetLocacoes();
        LocacaoDTOOutput GetLocacao(int idLocacao);
        LocacaoDTOOutput AlugarFilme(LocacaoDTOInput dto);
        bool DevolverFilme(int idLocacao, out string mensagem);
    }
}
