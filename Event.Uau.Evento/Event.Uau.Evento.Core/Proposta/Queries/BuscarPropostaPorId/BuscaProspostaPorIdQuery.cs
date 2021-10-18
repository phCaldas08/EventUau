using System;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Evento.ViewModel.Evento;

namespace Event.Uau.Evento.Core.Proposta.Queries.BuscarPropostaPorId
{
    public class BuscaProspostaPorIdQuery : EventUauRequest<FuncionarioEventoViewModel>
    {
        public int IdEvento { get; set; }
    }
}
