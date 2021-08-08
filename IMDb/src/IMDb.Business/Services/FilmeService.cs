using IMDb.Business.Helpers;
using IMDb.Business.Intefaces;
using IMDb.Business.Models;
using IMDb.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IMDb.Business.Services
{
    public class FilmeService : BaseService, IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository, INotificador notificador) : base(notificador)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<bool> Adicionar(Filme filme)
        {
            if (!ExecutarValidacao(new FilmeValidation(), filme)) return false;

            await _filmeRepository.Adicionar(filme);

            return true;
        }

        public async Task<Filme> ObterPorId(Guid id)
        {
            return await _filmeRepository.ObterPorId(id);
        }

        public async Task<Response<Filme>> Obter(FiltroFilme filtro)
        {
            return await _filmeRepository.Obter(filtro);
        }

        public void Dispose()
        {
            _filmeRepository?.Dispose();
        }       
    }
}
