using ProjetoLocadoraAPI.Controllers;
using ProjetoLocadoraAPI.DTOs;
using ProjetoLocadoraAPI.Model;
using ProjetoLocadoraAPI.Services;
using TestProjectLocadora.Mock;
using Moq;

namespace ProjetoLocadoraAPITeste
{
    public class LocadoraControllerTests
    {
        private readonly ClienteService _clienteService;
        private readonly FilmeService _filmeService;
        private readonly LocacaoService _locacaoService;
        private readonly LocadoraController _controller;
        private readonly TestProjectLocadoraMock _mock;

        public LocadoraControllerTests()
        {
            _mock = new TestProjectLocadoraMock();
            _clienteService = new ClienteService(_mock.ClienteRepository.Object);
            _filmeService = new FilmeService(_mock.FilmeRepository.Object);
            _locacaoService = new LocacaoService(_mock.LocacaoRepository.Object);
            _controller = new LocadoraController(_clienteService, _filmeService, _locacaoService);
        }

        [Fact]
        public void TestarGetClientes()
        {
            //arrange
            _mock.ClienteRepository.Setup(x => x.GetClientes()).Returns(this.GetClientes());
            _mock.ClienteService.Setup(x => x.GetClientes()).Returns(this.GetClientesDTO());

            //act
            var result = _controller.GetClientes();

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotEmpty((List<ClienteDTO>)result.Value.Dados);
        }

        [Fact]
        public void TestarGetClientesPorId()
        {
            //arrange
            var idCliente = 1;

            _mock.ClienteRepository.Setup(x => x.GetCliente(idCliente)).Returns(this.GetCliente());
            _mock.ClienteService.Setup(x => x.GetCliente(idCliente)).Returns(this.GetClienteDTO());

            //act
            var result = _controller.GetClientes(idCliente);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotNull((ClienteDTO)result.Value.Dados);
        }

        [Fact]
        public void TestarCadastrarCliente()
        {
            //arrange
            var dto = new ClienteDTO()
            {
                IdCliente = 0,
                NomeCliente = "Daniel da Silva Soares",
                Ativo = true
            };

            _mock.ClienteRepository.Setup(x => x.CadastrarCliente(It.IsAny<Cliente>())).Returns(this.GetCliente());
            _mock.ClienteService.Setup(x => x.CadastrarCliente(dto)).Returns(this.GetClienteDTO());

            //act
            var result = _controller.CadastrarCliente(dto);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotNull((ClienteDTO)result.Value.Dados);
        }

        [Fact]
        public void TestarCadastrarClienteExistente()
        {
            //arrange
            var dto = new ClienteDTO()
            {
                IdCliente = 0,
                NomeCliente = "Daniel da Silva Soares",
                Ativo = true
            };

            _mock.ClienteRepository.Setup(x => x.CadastrarCliente(It.IsAny<Cliente>())).Returns(this.GetCliente());
            _mock.ClienteRepository.Setup(x => x.ValidaCliente(dto.NomeCliente)).Returns(true);
            _mock.ClienteService.Setup(x => x.CadastrarCliente(dto)).Returns(this.GetClienteDTO());

            //act and assert
            var exception = Assert.Throws<InvalidOperationException>(() => _controller.CadastrarCliente(dto));
            Assert.Equal("Já existe um usuário cadastrado com o esse nome.", exception.Message);
        }

        [Fact]
        public void TestarGetFilmes()
        {
            //arrange
            _mock.FilmeRepository.Setup(x => x.GetFilmes()).Returns(this.GetFilmes());
            _mock.FilmeService.Setup(x => x.GetFilmes()).Returns(this.GetFilmesDTO());

            //act
            var result = _controller.GetFilmes();

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotEmpty((List<FilmeDTO>)result.Value.Dados);
        }

        [Fact]
        public void TestarGetFilmesPorId()
        {
            //arrange
            var idFilme = 1;

            _mock.FilmeRepository.Setup(x => x.GetFilme(idFilme)).Returns(this.GetFilme());
            _mock.FilmeService.Setup(x => x.GetFilme(idFilme)).Returns(this.GetFilmeDTO());

            //act
            var result = _controller.GetFilmes(idFilme);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotNull((FilmeDTO)result.Value.Dados);
        }

        [Fact]
        public void TestarCadastrarFilme()
        {
            //arrange
            var dto = new FilmeDTO()
            {
                IdFilme = 0,
                NomeFilme = "Rocky Balboa",
                Ativo = true
            };

            _mock.FilmeRepository.Setup(x => x.CadastrarFilme(It.IsAny<Filme>())).Returns(this.GetFilme());
            _mock.FilmeService.Setup(x => x.CadastrarFilme(dto)).Returns(this.GetFilmeDTO());

            //act
            var result = _controller.CadastrarFilme(dto);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotNull((FilmeDTO)result.Value.Dados);
        }

        [Fact]
        public void TestarGetLocacoes()
        {
            //arrange
            _mock.LocacaoRepository.Setup(x => x.GetLocacoes()).Returns(this.GetLocacoes());
            _mock.LocacaoService.Setup(x => x.GetLocacoes()).Returns(this.GetLocacoesDTOOutput());

            //act
            var result = _controller.GetLocacoes();

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotEmpty((List<LocacaoDTOOutput>)result.Value.Dados);
        }

        [Fact]
        public void TestarGetLocacaoPorId()
        {
            //arrange
            var idLocacao = 1;

            _mock.LocacaoRepository.Setup(x => x.GetLocacao(idLocacao)).Returns(this.GetLocacao());
            _mock.LocacaoService.Setup(x => x.GetLocacao(idLocacao)).Returns(this.GetLocacaoDTOOutput());

            //act
            var result = _controller.GetLocacoes(idLocacao);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotNull((LocacaoDTOOutput)result.Value.Dados);
        }

        [Fact]
        public void TestarCadastrarLocacao()
        {
            //arrange
            var dto = new LocacaoDTOInput()
            {
                IdLocacao = 0,
                IdFilme = 1,
                IdCliente = 1
            };

            _mock.LocacaoRepository.Setup(x => x.AlugarFilme(It.IsAny<Locacao>())).Returns(this.GetLocacao());
            _mock.LocacaoRepository.Setup(x => x.ValidaDisponibilidadeFilme(dto.IdFilme)).Returns(true);
            _mock.LocacaoService.Setup(x => x.AlugarFilme(dto)).Returns(this.GetLocacaoDTOOutput());

            //act
            var result = _controller.AlugarFilme(dto);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotNull((LocacaoDTOOutput)result.Value.Dados);
        }

        [Fact]
        public void TestarCadastrarLocacaoNaoDisponivel()
        {
            //arrange
            var dto = new LocacaoDTOInput()
            {
                IdLocacao = 0,
                IdFilme = 1,
                IdCliente = 1
            };

            _mock.LocacaoRepository.Setup(x => x.AlugarFilme(It.IsAny<Locacao>())).Returns(this.GetLocacao());
            _mock.LocacaoRepository.Setup(x => x.ValidaDisponibilidadeFilme(dto.IdFilme)).Returns(false);
            _mock.LocacaoService.Setup(x => x.AlugarFilme(dto)).Returns(this.GetLocacaoDTOOutput());

            //act and assert
            var exception = Assert.Throws<InvalidOperationException>(() => _controller.AlugarFilme(dto));
            Assert.Equal("Filme não disponível para locação.", exception.Message);
        }

        [Fact]
        public void TestarDevolverLocacao()
        {
            //arrange
            var idLocacao = 1;
            string msgRetornoLocacao = null as string;

            _mock.LocacaoRepository.Setup(x => x.DevolverFilme(It.IsAny<Locacao>())).Returns(this.GetLocacao());
            _mock.LocacaoRepository.Setup(x => x.GetLocacao(idLocacao)).Returns(this.GetLocacao());
            _mock.LocacaoService.Setup(x => x.DevolverFilme(idLocacao, out msgRetornoLocacao)).Returns(true);

            //act
            var result = _controller.DevolverFilme(idLocacao);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.True((bool)result.Value.Dados);
        }

        [Fact]
        public void TestarDevolverLocacaoComAtraso()
        {
            //arrange
            var idLocacao = 1;
            string msgRetornoLocacao = null as string;

            _mock.LocacaoRepository.Setup(x => x.DevolverFilme(It.IsAny<Locacao>())).Returns(this.GetLocacao());
            _mock.LocacaoRepository.Setup(x => x.GetLocacao(idLocacao)).Returns(this.GetLocacaoEmAtraso());
            _mock.LocacaoService.Setup(x => x.DevolverFilme(idLocacao, out msgRetornoLocacao)).Returns(true);

            //act
            var result = _controller.DevolverFilme(idLocacao);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.True((bool)result.Value.Dados);
            Assert.Equal("Filme devolvido com atraso.", result.Value.Mensagem);
        }


        private ClienteDTO GetClienteDTO()
        {
            return new ClienteDTO()
            {
                IdCliente = 1,
                NomeCliente = "Daniel da Silva Soares",
                Ativo = true
            };
        }

        private List<ClienteDTO> GetClientesDTO()
        {
            return new List<ClienteDTO>()
            {
                new ClienteDTO()
                {
                    IdCliente = 1,
                    NomeCliente = "Adonis",
                    Ativo = true
                },
                new ClienteDTO()
                {
                    IdCliente = 2,
                    NomeCliente = "Mario",
                    Ativo = true
                },
            };
        }

        private Cliente GetCliente()
        {
            return new Cliente()
            {
                IdCliente = 1,
                NomeCliente = "Daniel da Silva Soares",
                Ativo = 1
            };
        }

        private List<Cliente> GetClientes()
        {
            return new List<Cliente>()
            {
                new Cliente()
                {
                    IdCliente = 1,
                    NomeCliente = "Adonis",
                    Ativo = 1
                },
                new Cliente()
                {
                    IdCliente = 2,
                    NomeCliente = "Mario",
                    Ativo = 1
                },
            };
        }

        private FilmeDTO GetFilmeDTO()
        {
            return new FilmeDTO()
            {
                IdFilme = 1,
                NomeFilme = "Rocky Balboa",
                Ativo = true
            };
        }

        private List<FilmeDTO> GetFilmesDTO()
        {
            return new List<FilmeDTO>()
            {
                new FilmeDTO()
                {
                    IdFilme = 1,
                    NomeFilme = "Rocky Balboa",
                    Ativo = true
                },
                new FilmeDTO()
                {
                    IdFilme = 2,
                    NomeFilme = "Pantera Negra",
                    Ativo = true
                },
            };
        }

        private Filme GetFilme()
        {
            return new Filme()
            {
                IdFilme = 1,
                NomeFilme = "Daniel da Silva Soares",
                Ativo = 1
            };
        }

        private List<Filme> GetFilmes()
        {
            return new List<Filme>()
            {
                new Filme()
                {
                    IdFilme = 1,
                    NomeFilme = "Adonis",
                    Ativo = 1
                },
                new Filme()
                {
                    IdFilme = 2,
                    NomeFilme = "Mario",
                    Ativo = 1
                },
            };
        }

        private LocacaoDTOInput GetLocacaoDTOInput()
        {
            return new LocacaoDTOInput()
            {
                IdLocacao = 1,
                IdFilme = 1,
                IdCliente = 1
            };
        }

        private List<LocacaoDTOInput> GetLocacoesDTOInput()
        {
            return new List<LocacaoDTOInput>()
            {
                new LocacaoDTOInput()
                {
                    IdLocacao = 1,
                    IdFilme = 1,
                    IdCliente = 1
                },
                new LocacaoDTOInput()
                {
                    IdLocacao = 1,
                    IdFilme = 2,
                    IdCliente = 1
                },
            };
        }

        private LocacaoDTOOutput GetLocacaoDTOOutput()
        {
            return new LocacaoDTOOutput()
            {
                IdLocacao = 1,
                IdFilme = 1,
                Filme = "Rocky Balboa",
                IdCliente = 1,
                Cliente = "Daniel da Silva Soares",
                DataLocacao = DateTime.Now.ToString("dd/MM/yyyy"),
                DataDevolucao = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy"),
                EmAtraso = false,
                Ativo = true
            };
        }

        private List<LocacaoDTOOutput> GetLocacoesDTOOutput()
        {
            return new List<LocacaoDTOOutput>()
            {
                new LocacaoDTOOutput()
                {
                    IdLocacao = 1,
                    IdFilme = 1,
                    Filme = "Rocky Balboa",
                    IdCliente = 1,
                    Cliente = "Daniel da Silva Soares",
                    DataLocacao = DateTime.Now.ToString("dd/MM/yyyy"),
                    DataDevolucao = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy"),
                    EmAtraso = false,
                    Ativo = true
                },
                new LocacaoDTOOutput()
                {
                    IdLocacao = 2,
                    IdFilme = 2,
                    Filme = "Pantera Negra",
                    IdCliente = 2,
                    Cliente = "Mario",
                    DataLocacao = DateTime.Now.ToString("dd/MM/yyyy"),
                    DataDevolucao = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy"),
                    EmAtraso = false,
                    Ativo = true
                },
            };
        }

        private Locacao GetLocacao()
        {
            return new Locacao()
            {
                IdLocacao = 1,
                IdFilme = 1,
                IdCliente = 1,
                DataLocacao = DateTime.Now,
                DataDevolucao = DateTime.Now.AddDays(7),
                EmAtraso = 0,
                Ativo = 1
            };
        }

        private Locacao GetLocacaoEmAtraso()
        {
            return new Locacao()
            {
                IdLocacao = 1,
                IdFilme = 1,
                IdCliente = 1,
                DataLocacao = DateTime.Now.AddDays(-8),
                DataDevolucao = DateTime.Now.AddDays(-1),
                EmAtraso = 0,
                Ativo = 1
            };
        }

        private List<Locacao> GetLocacoes()
        {
            return new List<Locacao>()
            {
                new Locacao()
                {
                    IdLocacao = 1,
                    IdFilme = 1,
                    IdCliente = 1,
                    DataLocacao = DateTime.Now,
                    DataDevolucao = DateTime.Now.AddDays(7),
                    EmAtraso = 0,
                    Ativo = 1
                },
                new Locacao()
                {
                    IdLocacao = 2,
                    IdFilme = 2,
                    IdCliente = 2,
                    DataLocacao = DateTime.Now,
                    DataDevolucao = DateTime.Now.AddDays(7),
                    EmAtraso = 0,
                    Ativo = 1
                },
            };
        }

    }
}
