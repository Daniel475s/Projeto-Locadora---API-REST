using ProjetoLocadoraAPI.Model;

namespace ProjetoLocadoraAPI.Repositories.Interfaces
{
    public interface InfClienteRepository
    {
        List<Cliente> GetClientes();
        Cliente GetCliente(int idCliente);
        Cliente CadastrarCliente(Cliente cliente);
        bool ValidaCliente(string NomeCliente);
    }
}
