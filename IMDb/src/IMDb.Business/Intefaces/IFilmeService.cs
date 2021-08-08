using IMDb.Business.Helpers;
using IMDb.Business.Models;
using System;
using System.Threading.Tasks;

namespace IMDb.Business.Intefaces
{
    public interface IFilmeService 
    {

        Task<Filme> ObterPorId(Guid id);

        Task<bool> Adicionar(Filme filme);

        Task<Response<Filme>> Obter(FiltroFilme filtro);
    }
}
