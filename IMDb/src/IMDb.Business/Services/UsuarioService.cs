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
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return null;

            if (await _usuarioRepository.ObterPorEmail(usuario.Email) != null)
            {
                Notificar("Já existe usuário cadastrado com este e-mail!");
                return null;
            }

            usuario.Senha = Utils.GerarHashMd5(usuario.Senha);

            await _usuarioRepository.Adicionar(usuario);

            return usuario;
        }

        public async Task<bool> Atualizar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return false;

            usuario.Senha = Utils.GerarHashMd5(usuario.Senha);

            await _usuarioRepository.Atualizar(usuario);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (await _usuarioRepository.ObterPorId(id) == null)
            {
                Notificar("Usuário não localizado.");
                return false;
            }

            await _usuarioRepository.Remover(id);
            return true;
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await _usuarioRepository.ObterPorId(id);
        }

        public async Task<Usuario> ObterPorUserNameSenha(string email, string senha)
        {
            var novaSenha = Utils.GerarHashMd5(senha);
            return await _usuarioRepository.ObterPorEmailSenha(email, novaSenha);
        }        

        public async Task<Response<Usuario>> ObterUsuariosNaoAdministradores(Filtro filtro)
        {
            return await _usuarioRepository.ObterUsuariosNaoAdministradores(filtro);
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}
