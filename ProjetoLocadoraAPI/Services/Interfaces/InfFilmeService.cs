using ProjetoLocadoraAPI.DTOs;

namespace ProjetoLocadoraAPI.Services.Interfaces
{
    public interface InfFilmeService
    {
        List<FilmeDTO>? GetFilmes();
        FilmeDTO GetFilme(int idFilme);
        FilmeDTO CadastrarFilme(FilmeDTO dto);
    }
}
