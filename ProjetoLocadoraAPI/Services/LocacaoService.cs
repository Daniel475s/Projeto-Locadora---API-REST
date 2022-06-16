using ProjetoLocadoraAPI.DTOs;
using ProjetoLocadoraAPI.Model;
using ProjetoLocadoraAPI.Repositories.Interfaces;
using ProjetoLocadoraAPI.Services.Interfaces;

namespace ProjetoLocadoraAPI.Services
{
    public class LocacaoService : InfLocacaoService
    {
        private InfLocacaoRepository _repository;

        public LocacaoService(InfLocacaoRepository repository)
        {
            _repository = repository;
        }

        public bool DevolverFilme(int idLocacao, out string mensagem)
        {
            mensagem = null;

            var locacao = _repository.GetLocacao(idLocacao);

            if (locacao is null)
                throw new InvalidOperationException("Locação não encontrada.");

            if(DateTime.Now > locacao.DataDevolucao)
            {
                locacao.EmAtraso = 1;
                mensagem = "Filme devolvido com atraso.";
            }

            var retorno = _repository.DevolverFilme(locacao);

            if (retorno is null) return false;

            return true;
        }

        public LocacaoDTOOutput AlugarFilme(LocacaoDTOInput dto)
        {
            var validaDisponibilidadeFilme = _repository.ValidaDisponibilidadeFilme(dto.IdFilme);

            if (!validaDisponibilidadeFilme)
                throw new InvalidOperationException("Filme indisponível para alugar.");

            var locacao = new Locacao()
            {
                IdLocacao = 0,
                IdFilme = dto.IdFilme,
                IdCliente = dto.IdCliente,
                DataLocacao = DateTime.Now,
                DataDevolucao = DateTime.Now.AddDays(7),
                Ativo = 1
            };

            var retorno = _repository.AlugarFilme(locacao);

            if (retorno is null) return null;

            return new LocacaoDTOOutput()
            {
                IdLocacao = retorno.IdLocacao,
                IdFilme = retorno.IdFilme,
                Filme = retorno.Filme?.NomeFilme,
                IdCliente = retorno.IdCliente,
                Cliente = retorno.Cliente?.NomeCliente,
                DataLocacao = retorno.DataLocacao.ToString("dd/MM/yyyy"),
                DataDevolucao = retorno.DataDevolucao.ToString("dd/MM/yyyy"),
                EmAtraso = retorno.EmAtraso == 1 ? true : false,
                Ativo = retorno.Ativo == 1 ? true : false
            };
        }

        public LocacaoDTOOutput GetLocacao(int idLocacao)
        {
            var dados = _repository.GetLocacao(idLocacao);

            if (dados is null) return null;

            return new LocacaoDTOOutput()
            {
                IdLocacao = dados.IdLocacao,
                IdFilme = dados.IdFilme,
                Filme = dados.Filme?.NomeFilme,
                IdCliente = dados.IdCliente,
                Cliente = dados.Cliente?.NomeCliente,
                DataLocacao = dados.DataLocacao.ToString("dd/MM/yyyy"),
                DataDevolucao = dados.DataDevolucao.ToString("dd/MM/yyyy"),
                EmAtraso = dados.EmAtraso == 1 ? true : false,
                Ativo = dados.Ativo == 1 ? true : false
            };
        }

        public List<LocacaoDTOOutput> GetLocacoes()
        {
            var dados = _repository.GetLocacoes();

            if (dados?.Count == 0) return null;

            return dados.Select(x => new LocacaoDTOOutput()
            {
                IdLocacao = x.IdLocacao,
                IdFilme = x.IdFilme,
                Filme = x.Filme?.NomeFilme,
                IdCliente = x.IdCliente,
                Cliente = x.Cliente?.NomeCliente,
                DataLocacao = x.DataLocacao.ToString("dd/MM/yyyy"),
                DataDevolucao = x.DataDevolucao.ToString("dd/MM/yyyy"),
                EmAtraso = x.EmAtraso == 1 ? true : false,
                Ativo = x.Ativo == 1 ? true : false
            })
            .ToList();
        }
    }
}
