using System;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Evento.ViewModel.Evento;

namespace Event.Uau.Evento.Core.Status.Commands.CadastrarStatus
{
    public class CadastrarStatusCommand : EventUauRequest<StatusViewModel>
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
    }
}
