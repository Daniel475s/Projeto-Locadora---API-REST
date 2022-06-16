using ProjetoLocadoraAPI.DTOs;
using ProjetoLocadoraAPI.Services.Interfaces;
using ProjetoLocadoraAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoLocadoraAPI.Controllers
{
    
        [ApiController]
        [Route("api")]
        public class LocadoraController : ControllerBase
        {
            private InfClienteService _clienteService;
            private InfFilmeService _filmeService;
            private InfLocacaoService _locacaoService;

            public LocadoraController(InfClienteService clienteService, InfFilmeService filmeService, InfLocacaoService locacaoService)
            {
                _clienteService = clienteService;
                _filmeService = filmeService;
                _locacaoService = locacaoService;
            }

            [HttpGet("filmes")]
            public ActionResult<RetornoAPI> GetFilmes()
            {
                var retorno = _filmeService.GetFilmes();

                if (retorno?.Count == 0) return NoContent();

                return new RetornoAPI()
                {
                    Dados = retorno,
                    Mensagem = null
                };
            }

            [HttpGet("filmes/{idFilme}")]
            public ActionResult<RetornoAPI> GetFilmes(int idFilme)
            {
                var retorno = _filmeService.GetFilme(idFilme);

                if (retorno is null) return NoContent();

                return new RetornoAPI()
                {
                    Dados = retorno,
                    Mensagem = null
                };
            }

            [HttpPost("filmes")]
            public ActionResult<RetornoAPI> CadastrarFilme([FromBody] FilmeDTO dto)
            {
                var retorno = _filmeService.CadastrarFilme(dto);

                if (retorno is null) return NoContent();

                return new RetornoAPI()
                {
                    Dados = retorno,
                    Mensagem = null
                };
            }

            [HttpGet("clientes")]
            public ActionResult<RetornoAPI> GetClientes()
            {
                var retorno = _clienteService.GetClientes();

                if (retorno is null) return NoContent();

                return new RetornoAPI()
                {
                    Dados = retorno,
                    Mensagem = null
                };
            }

            [HttpGet("clientes/{idCliente}")]
            public ActionResult<RetornoAPI> GetClientes(int idCliente)
            {
                var retorno = _clienteService.GetCliente(idCliente);

                if (retorno is null) return NoContent();

                return new RetornoAPI()
                {
                    Dados = retorno,
                    Mensagem = null
                };
            }

            [HttpPost("clientes")]
            public ActionResult<RetornoAPI> CadastrarCliente([FromBody] ClienteDTO dto)
            {
                var retorno = _clienteService.CadastrarCliente(dto);

                if (retorno is null) return NoContent();

                return new RetornoAPI()
                {
                    Dados = retorno,
                    Mensagem = null
                };
            }

            [HttpGet("locacoes")]
            public ActionResult<RetornoAPI> GetLocacoes()
            {
                var retorno = _locacaoService.GetLocacoes();

                if (retorno is null) return NoContent();

                return new RetornoAPI()
                {
                    Dados = retorno,
                    Mensagem = null
                };
            }

            [HttpGet("locacoes/{idLocacao}")]
            public ActionResult<RetornoAPI> GetLocacoes(int idLocacao)
            {
                var retorno = _locacaoService.GetLocacao(idLocacao);

                if (retorno is null) return NoContent();

                return new RetornoAPI()
                {
                    Dados = retorno,
                    Mensagem = null
                };
            }

            [HttpPost("locacoes")]
            public ActionResult<RetornoAPI> AlugarFilme([FromBody] LocacaoDTOInput dto)
            {
                var retorno = _locacaoService.AlugarFilme(dto);

                if (retorno is null) return NoContent();

                return new RetornoAPI()
                {
                    Dados = retorno,
                    Mensagem = null
                };
            }

            [HttpDelete("locacoes/{idLocacao}")]
            public ActionResult<RetornoAPI> DevolverFilme(int idLocacao)
            {
                var mensagemRetorno = null as string;

                var retorno = _locacaoService.DevolverFilme(idLocacao, out mensagemRetorno);

                return new RetornoAPI()
                {
                    Dados = retorno,
                    Mensagem = mensagemRetorno
                };
            }
        }
}
