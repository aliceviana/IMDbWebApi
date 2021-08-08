using IMDb.Business.Intefaces;
using IMDb.Business.Models;
using IMDb.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IMDb.Data.Repository
{
    public class VotoRepository : IVotoRepository
    {
        private readonly IMDbDbContext _context;

        public VotoRepository(IMDbDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Voto voto)
        {
            _context.Add(voto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteVoto(Voto voto)
        {
            return await _context.Votos
                .Where(x => x.UsuarioId == voto.UsuarioId && x.FilmeId == voto.FilmeId)
                .AsNoTracking()
                .AnyAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
