using IMDb.Business.Helpers;
using IMDb.Business.Models;
using System;
using System.Threading.Tasks;

namespace IMDb.Business.Intefaces
{
    public interface IUsuarioService
    {       
        Task<Usuario> Adicionar(Usuario usuario);

        Task<bool> Atualizar(Usuario usuario);

        Task<bool> Remover(Guid id);

        Task<Usuario> ObterPorId(Guid id);

        Task<Usuario> ObterPorUserNameSenha(string email, string senha);

        Task<Response<Usuario>> ObterUsuariosNaoAdministradores(Filtro filtro);
    }
}
