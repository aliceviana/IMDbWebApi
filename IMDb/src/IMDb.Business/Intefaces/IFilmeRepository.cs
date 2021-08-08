using IMDb.Business.Helpers;
using IMDb.Business.Models;
using System;
using System.Threading.Tasks;

namespace IMDb.Business.Intefaces
{
    public interface IFilmeRepository : IDisposable
    {
        Task Adicionar(Filme filme);

        Task<Filme> ObterPorId(Guid id);

        Task<Response<Filme>> Obter(FiltroFilme filtro);
    }
}
