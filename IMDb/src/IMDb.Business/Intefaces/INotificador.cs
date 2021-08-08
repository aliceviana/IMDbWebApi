using System.Collections.Generic;
using IMDb.Business.Notificacoes;

namespace IMDb.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();

        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}