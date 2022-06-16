using ProjetoLocadoraAPI.Context;
using ProjetoLocadoraAPI.Model;
using ProjetoLocadoraAPI.Repositories.Interfaces;

namespace ProjetoLocadoraAPI.Repositories
{
    public class FilmeRepository : InfFilmeRepository
    {
        private PLocadoraDBContext _context;

        public FilmeRepository(PLocadoraDBContext context)
        {
            _context = context;
        }

        public Filme CadastrarFilme(Filme filme)
        {
            if (filme is null)
                throw new NullReferenceException("Filme não existe, Tente Novamente.");

            var entity = _context.Set<Filme>().Add(filme);
            var count = _context.SaveChanges();

            return count > 0 ? entity.Entity : null;
        }

        public Filme GetFilme(int idFilme)
        {
            return _context.Set<Filme>().FirstOrDefault(x => x.IdFilme == idFilme);
        }

        public List<Filme> GetFilmes()
        {
            return _context.Set<Filme>().ToList();
        }
    }
}
