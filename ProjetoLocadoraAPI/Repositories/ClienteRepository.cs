using ProjetoLocadoraAPI.Context;
using ProjetoLocadoraAPI.Model;
using ProjetoLocadoraAPI.Repositories.Interfaces;

namespace ProjetoLocadoraAPI.Repositories
{
    public class ClienteRepository : InfClienteRepository
    {
        private PLocadoraDBContext _context;

        public ClienteRepository(PLocadoraDBContext context)
        {
            _context = context;
        }

        public Cliente CadastrarCliente(Cliente cliente)
        {
            if (cliente is null)
                throw new NullReferenceException("Cliente não existe, Tente Novamente.");

            var entity = _context.Set<Cliente>().Add(cliente);
            var count = _context.SaveChanges();

            return count > 0 ? entity.Entity : null;
        }

        public Cliente GetCliente(int idCliente)
        {
            return _context.Set<Cliente>().FirstOrDefault(x => x.IdCliente == idCliente);
        }

        public List<Cliente> GetClientes()
        {
            return _context.Set<Cliente>().ToList();
        }

        public bool ValidaCliente(string NomeCliente)
        {
            return _context.Set<Cliente>().Any(x => x.NomeCliente == NomeCliente && x.Ativo == 1);
        }
    }
}
