using System;
using System.Collections.Generic;

namespace Event.Uau.Comum.Util.Exceptions
{
    public class EventUauBadRequestException : Exception
    {
        public string Erro { get; set; }

        public List<string> Mensagens { get; set; }

        public string TipoErro { get; set; }

    }
}
