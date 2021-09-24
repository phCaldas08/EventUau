using System;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Upload.ViewModel.Upload;
using MediatR;

namespace Event.Uau.Upload.Core.Arquivo.Queries.DownloadArquivos
{
    public class DownloadArquivosQuery : EventUauRequest<ArquivoViewModel>
    {
        public string Contexto { get; set; }
        public int IdContexto { get; set; }
    }
}
