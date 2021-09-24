using System;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Upload.Core.Arquivo.Commands.UploadArquivos
{
    public class UploadArquivosCommand : EventUauRequest<int>
    {
        public string Contexto { get; set; }
        public int IdContexto { get; set; }
        public byte[] Conteudo { get; set; }
        public string Nome { get; set; }
        public string TipoConteudo { get; set; }
    }
}
