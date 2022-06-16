using Microsoft.EntityFrameworkCore;
using ProjetoLocadoraAPI.Model;

namespace ProjetoLocadoraAPI.Context
{
    public class PLocadoraDBContext : DbContext
    {
        public PLocadoraDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Filme>? Filmes { get; set; }
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Locacao>? Locacoes { get; set; }

    }
}
