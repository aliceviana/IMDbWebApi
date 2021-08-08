using IMDb.Business.Models;
using System;
using System.Threading.Tasks;

namespace IMDb.Business.Intefaces
{
    public interface IVotoService
    {
        Task<bool> Votar(Guid filmeId, decimal nota, string email);
    }
}
