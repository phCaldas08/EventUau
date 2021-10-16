using System;
using System.Collections.Generic;
using System.Linq;
using Event.Uau.Comum.Util.Exceptions;

namespace Event.Uau.Comum.Configuracao.Helpers
{
    public class ExceptionBody
    {
        public string Erro { get; set; }

        public List<string> Mensagens { get; set; }

        public string TipoErro { get; set; }

        public ExceptionBody(FluentValidation.ValidationException validationException)
        {
            Erro = "Erro no corpo da requisição.";
            Mensagens = validationException.Errors.Select(x => x.ErrorMessage).ToList();
            TipoErro = validationException.GetType().ToString();
        }

        public ExceptionBody(Exception exception)
        {
            Erro = exception.Message + exception.InnerException?.Message;
            TipoErro = exception.GetType().ToString();
        }

        public ExceptionBody(EventUauBadRequestException eventUauBadRequest)
        {
            this.Erro = eventUauBadRequest.Erro;
            this.Mensagens = eventUauBadRequest.Mensagens;
            this.TipoErro = eventUauBadRequest.TipoErro;
        }
    }
}
