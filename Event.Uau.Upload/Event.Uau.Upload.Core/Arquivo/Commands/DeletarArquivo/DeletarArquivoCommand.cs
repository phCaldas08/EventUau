using System;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Upload.Core.Arquivo.Commands.DeletarArquivo
{
    public class DeletarArquivoCommand : EventUauRequest<int>
    {
        public int IdContexto { get; set; }

        public string Contexto { get; set; }
    }
}
