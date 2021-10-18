using System;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Evento.ViewModel.Evento;

namespace Event.Uau.Evento.Core.StatusContratacao.Queries.BuscarStatusContratacaoPorId
{
    public class BuscarStatusContratacaoPorIdQuery : EventUauRequest<StatusContratacaoViewModel>
    {
        public string Id { get; set; }
    }
}
