using IMDb.Business.Models;
using System;
using System.Threading.Tasks;

namespace IMDb.Business.Intefaces
{
    public interface IVotoRepository : IDisposable
    {
        Task Adicionar(Voto voto);

        Task<bool> ExisteVoto(Voto voto);
    }
}
