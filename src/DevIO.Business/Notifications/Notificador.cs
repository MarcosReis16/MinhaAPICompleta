using System.Collections.Generic;
using System.Linq;
using DevIO.Business.Interfaces;

namespace DevIO.Business.Notifications
{
    public class Notificador : INotificador
    {
        private IList<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }

        public IList<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }
    }
}