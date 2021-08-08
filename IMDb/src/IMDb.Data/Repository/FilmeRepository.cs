using IMDb.Business.Helpers;
using IMDb.Business.Intefaces;
using IMDb.Business.Models;
using IMDb.Data.Context;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDb.Data.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly IMDbDbContext _context;

        public FilmeRepository(IMDbDbContext context) 
        {
            _context = context;
        }

        public async Task Adicionar(Filme filme)
        {
            _context.Add(filme);
            await _context.SaveChangesAsync();
        }

        public async Task<Filme> ObterPorId(Guid id)
        {
            var resultado = await _context.Filmes
                .AsNoTracking()
                .Include(x => x.Atores)
                .Include(x => x.Votos)
                .Where(x => x.Id == id)
                .ToListAsync();

            return resultado.FirstOrDefault();
        }

        public async Task<Response<Filme>> Obter(FiltroFilme filtro)
        {
            var predicate = PredicateBuilder.New<Filme>(true);

            if (filtro.Diretor != null && filtro.Diretor?.Trim() != string.Empty)
            {
                predicate = predicate.And(n => n.Diretor.Contains(filtro.Diretor));
            }

            if (filtro.Nome != null && filtro.Nome?.Trim() != string.Empty)
            {
                predicate = predicate.And(n => n.Nome.Contains(filtro.Nome));
            }

            if (filtro.Genero != null && filtro.Genero?.Trim() != string.Empty)
            {
                predicate = predicate.And(n => n.Genero.Contains(filtro.Genero));
            }

            if (filtro.Ator != null && filtro.Ator?.Trim() != string.Empty)
            {
                predicate = predicate.And(n => n.Atores != null && n.Atores.Where(x => x.Nome.Contains(filtro.Ator)).Any());
            }

            var total = await _context.Filmes
                .Where(predicate)
                .CountAsync();

            var resultado = await _context.Filmes
                .AsNoTracking()
                .Include(x => x.Atores)
                .Include(x => x.Votos)
                .Where(predicate)                          
                .ToListAsync();

            var dados = resultado.OrderByDescending(x => x.Nota).ThenBy(x => x.Nome)
                .Skip((filtro.NumeroPagina - 1) * filtro.TamanhoPagina)
                .Take(filtro.TamanhoPagina).ToList();

            return new Response<Filme>(dados, total);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
