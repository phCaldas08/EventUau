using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Upload.Persistence;
using Event.Uau.Upload.ViewModel.Upload;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace Event.Uau.Upload.Core.Arquivo.Queries.DownloadArquivos
{

    public class DownloadArquivosQueryHandler : IRequestHandler<DownloadArquivosQuery, ArquivoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly DownloadArquivosQueryValidator validator;

        public DownloadArquivosQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = new DownloadArquivosQueryValidator(context);
        }

        public async Task<ArquivoViewModel> Handle(DownloadArquivosQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var arquivo = await context.Arquivos.FirstOrDefaultAsync(i => i.IdContexto == request.IdContexto
                                       && i.Contexto.Equals(request.Contexto, StringComparison.CurrentCultureIgnoreCase));

            var arquivoViewModel = mapper.Map<ArquivoViewModel>(arquivo);

            return arquivoViewModel;
        }
    }

}
