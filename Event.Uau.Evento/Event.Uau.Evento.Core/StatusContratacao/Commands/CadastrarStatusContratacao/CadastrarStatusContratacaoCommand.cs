using System;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Evento.ViewModel.Evento;

namespace Event.Uau.Evento.Core.StatusContratacao.Commands.CadastrarStatusContratacao
{
    public class CadastrarStatusContratacaoCommand : EventUauRequest<StatusContratacaoViewModel>
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public bool EhRecusado { get; set; }
    }
}
