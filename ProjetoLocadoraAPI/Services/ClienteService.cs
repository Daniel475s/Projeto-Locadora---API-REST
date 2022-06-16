using ProjetoLocadoraAPI.DTOs;
using ProjetoLocadoraAPI.Model;
using ProjetoLocadoraAPI.Repositories.Interfaces;
using ProjetoLocadoraAPI.Services.Interfaces;

namespace ProjetoLocadoraAPI.Services
{
    public class ClienteService : InfClienteService
    {
        private InfClienteRepository _repository;

        public ClienteService(InfClienteRepository repository)
        {
            _repository = repository;
        }

        public ClienteDTO CadastrarCliente(ClienteDTO dto)
        {
            var ValidaCliente = _repository.ValidaCliente(dto.NomeCliente);

            if (ValidaCliente)
                throw new InvalidOperationException("Já existe um usuário cadastrado com esse mesmo nome.");

            var cliente = new Cliente()
            {
                IdCliente = 0,
                NomeCliente = dto.NomeCliente,
                Ativo = dto.Ativo ? 1 : 0,
            };

            var retorno = _repository.CadastrarCliente(cliente);

            if (retorno is null) return null;

            return new ClienteDTO()
            {
                IdCliente = retorno.IdCliente,
                NomeCliente = retorno.NomeCliente,
                Ativo = retorno.Ativo == 1 ? true : false
            };
        }

        public ClienteDTO GetCliente(int idCliente)
        {
            var dados = _repository.GetCliente(idCliente);

            if (dados is null) return null;

            return new ClienteDTO()
            {
                IdCliente = dados.IdCliente,
                NomeCliente = dados.NomeCliente,
                Ativo = dados.Ativo == 1 ? true : false
            };
        }

        public List<ClienteDTO> GetClientes()
        {
            var dados = _repository.GetClientes();

            if (dados?.Count == 0) return null;

            return dados.Select(x => new ClienteDTO()
            {
                IdCliente = x.IdCliente,
                NomeCliente = x.NomeCliente,
                Ativo = x.Ativo == 1 ? true : false
            })
            .ToList();
        }
    }
}
