using System.Collections.Generic;
using DevIO.Business.Notifications;

namespace DevIO.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        IList<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}