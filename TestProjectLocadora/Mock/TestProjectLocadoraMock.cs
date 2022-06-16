using ProjetoLocadoraAPI.Repositories.Interfaces;
using ProjetoLocadoraAPI.Services.Interfaces;
using Moq;


namespace TestProjectLocadora.Mock
{
    internal class TestProjectLocadoraMock
    {
        public Mock<InfClienteService> ClienteService { get; set; }
        public Mock<InfFilmeService> FilmeService { get; set; }
        public Mock<InfLocacaoService> LocacaoService { get; set; }

        public Mock<InfClienteRepository> ClienteRepository { get; set; }
        public Mock<InfFilmeRepository> FilmeRepository { get; set; }
        public Mock<InfLocacaoRepository> LocacaoRepository { get; set; }

        public TestProjectLocadoraMock()
        {
            ClienteService = new Mock<InfClienteService>();
            FilmeService = new Mock<InfFilmeService>();
            LocacaoService = new Mock<InfLocacaoService>();
            ClienteRepository = new Mock<InfClienteRepository>();
            FilmeRepository = new Mock<InfFilmeRepository>();
            LocacaoRepository = new Mock<InfLocacaoRepository>();
        }

    }
}
