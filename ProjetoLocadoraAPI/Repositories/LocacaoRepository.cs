using ProjetoLocadoraAPI.Context;
using ProjetoLocadoraAPI.Model;
using ProjetoLocadoraAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProjetoLocadoraAPI.Repositories
{
    public class LocacaoRepository : InfLocacaoRepository
    {
        private PLocadoraDBContext _context;

        public LocacaoRepository(PLocadoraDBContext context)
        {
            _context = context;
        }

        public Locacao DevolverFilme(Locacao locacao)
        {
            if (locacao is null)
                throw new NullReferenceException("Locação não existe, Tente Novamente.");

            locacao.DataDevolucao = DateTime.Now;
            locacao.Ativo = 0;

            var entity = _context.Set<Locacao>().Update(locacao);
            var count = _context.SaveChanges();

            return count > 0 ? entity.Entity : null;
        }

        public Locacao AlugarFilme(Locacao locacao)
        {
            if (locacao is null)
                throw new NullReferenceException("Locação não existe, Tente Novamente.");

            var entity = _context.Set<Locacao>().Add(locacao);
            var count = _context.SaveChanges();

            return count > 0 ? GetLocacao(entity.Entity.IdLocacao) : null;
        }

        public Locacao GetLocacao(int idLocacao)
        {
            return _context.Set<Locacao>().Include(x => x.Cliente).Include(x => x.Filme).FirstOrDefault(x => x.IdLocacao == idLocacao);
        }

        public List<Locacao> GetLocacoes()
        {
            return _context.Set<Locacao>().Include(x => x.Cliente).Include(x => x.Filme).ToList();
        }

        public bool ValidaDisponibilidadeFilme(int idFilme)
        {
            throw new NotImplementedException();
        }

    }
}
