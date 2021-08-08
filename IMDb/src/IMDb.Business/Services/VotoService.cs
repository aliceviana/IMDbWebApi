using IMDb.Business.Intefaces;
using IMDb.Business.Models;
using IMDb.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace IMDb.Business.Services
{
    public class VotoService : BaseService, IVotoService
    {
        private readonly IVotoRepository _votoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IFilmeRepository _filmeRepository;

        public VotoService(IVotoRepository votoRepository,
            IFilmeRepository filmeRepository,
            INotificador notificador,
            IUsuarioRepository usuarioRepository) : base(notificador)
        {
            _votoRepository = votoRepository;
            _usuarioRepository = usuarioRepository;
            _filmeRepository = filmeRepository;
        }

        public async Task<bool> Votar(Guid filmeId, decimal nota, string email)
        {
            var usuario = await _usuarioRepository.ObterPorEmail(email);

            if (usuario == null)
            {
                Notificar("Usuário não localizado!");
                return false;
            }

            var filme = await _filmeRepository.ObterPorId(filmeId);

            if (filme == null)
            {
                Notificar("Filme não localizado!");
                return false;
            }

            var voto = new Voto { FilmeId = filmeId, UsuarioId = usuario.Id, Nota = nota };

            if (!ExecutarValidacao(new VotoValidation(), voto)) return false;

            if (await _votoRepository.ExisteVoto(voto))
            {
                Notificar("Já existe voto deste usuário para este filme!");

                return false;
            }

            await _votoRepository.Adicionar(voto);

            return true;
        }

        public void Dispose()
        {
            _votoRepository?.Dispose();
        }
    }
}
