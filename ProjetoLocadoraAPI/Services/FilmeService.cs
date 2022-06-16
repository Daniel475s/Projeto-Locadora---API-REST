using ProjetoLocadoraAPI.DTOs;
using ProjetoLocadoraAPI.Model;
using ProjetoLocadoraAPI.Repositories.Interfaces;
using ProjetoLocadoraAPI.Services.Interfaces;

namespace ProjetoLocadoraAPI.Services
{
    public class FilmeService : InfFilmeService
    {
        private InfFilmeRepository _repository;

        public FilmeService(InfFilmeRepository repository)
        {
            _repository = repository;
        }

        public FilmeDTO CadastrarFilme(FilmeDTO dto)
        {
            var filme = new Filme()
            {
                IdFilme = 0,
                NomeFilme = dto.NomeFilme,
                Ativo = dto.Ativo ? 1 : 0,
            };

            var retorno = _repository.CadastrarFilme(filme);

            if (retorno is null) return null;

            return new FilmeDTO()
            {
                IdFilme = retorno.IdFilme,
                NomeFilme = retorno.NomeFilme,
                Ativo = retorno.Ativo == 1 ? true : false
            };
        }

        public FilmeDTO GetFilme(int idFilme)
        {
            var dados = _repository.GetFilme(idFilme);

            if (dados is null) return null;

            return new FilmeDTO()
            {
                IdFilme = dados.IdFilme,
                NomeFilme = dados.NomeFilme,
                Ativo = dados.Ativo == 1 ? true : false
            };
        }

        public List<FilmeDTO> GetFilmes()
        {
            var dados = _repository.GetFilmes();

            if(dados?.Count == 0) return null;

            return dados.Select(x => new FilmeDTO()
            {
                IdFilme = x.IdFilme,
                NomeFilme = x.NomeFilme,
                Ativo = x.Ativo == 1 ? true : false
            })
            .ToList();
        }
    }
}
