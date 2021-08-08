using IMDb.Business.Helpers;
using IMDb.Business.Intefaces;
using IMDb.Business.Models;
using IMDb.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IMDb.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMDbDbContext _context;

        public UsuarioRepository(IMDbDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(Guid id)
        {
            var entity = await _context.Usuarios.FindAsync(id);
            entity.Excluido = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await _context.Usuarios.
                Where(x => x.Id == id && x.Excluido == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObterPorEmailSenha(string email, string senha)
        {
            return await _context.Usuarios.
                Where(x => x.Email == email && x.Senha == senha && x.Excluido == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObterPorEmail(string email)
        {
            return await _context.Usuarios.
                Where(x => x.Email == email && x.Excluido == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Response<Usuario>> ObterUsuariosNaoAdministradores(Filtro filtro)
        {
            var dados = await _context.Usuarios
                .Where(x => x.Excluido == false && x.Role == "usuario")
                .OrderBy(x => x.Nome)
                .Skip((filtro.NumeroPagina - 1) * filtro.TamanhoPagina)
                .Take(filtro.TamanhoPagina)
                .AsNoTracking()
                .ToListAsync();

            var total = await _context.Usuarios
                .Where(x => x.Excluido == false && x.Role == "usuario")
                .CountAsync();

            return new Response<Usuario>(dados, total);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
