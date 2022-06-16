using ProjetoLocadoraAPI.DTOs;
using ProjetoLocadoraAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoLocadoraAPI.Services.Interfaces
{
    public interface InfClienteService
    {

        List<ClienteDTO> GetClientes();
        ClienteDTO GetCliente(int idCliente);
        ClienteDTO CadastrarCliente(ClienteDTO dto);

    }
}
