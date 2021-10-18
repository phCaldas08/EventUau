using System;
using Event.Uau.Comum.ViewModel;

namespace Event.Uau.Evento.ViewModel.Evento
{
    public class StatusContratacaoViewModel : DecricaoIdViewModel<string> {
        public bool EhRecusado { get; set; } 
    }
}
