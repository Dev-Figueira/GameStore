using GameStore.Domain.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
