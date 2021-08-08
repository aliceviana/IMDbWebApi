using IMDb.Business.Helpers;
using IMDb.Business.Models;
using System;
using System.Threading.Tasks;

namespace IMDb.Business.Intefaces
{
    public interface IUsuarioRepository : IDisposable
    {
        Task Adicionar(Usuario usuario);

        Task Atualizar(Usuario usuario);

        Task Remover(Guid id);

        Task<Usuario> ObterPorId(Guid id);

        Task<Usuario> ObterPorEmailSenha(string email, string senha);

        Task<Response<Usuario>> ObterUsuariosNaoAdministradores(Filtro filtro);

        Task<Usuario> ObterPorEmail(string email);
    }
}
