using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Upload.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace Event.Uau.Upload.Core.Arquivo.Commands.UploadArquivos
{
    public class UploadArquivosCommandHandler : IRequestHandler<UploadArquivosCommand, int>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly UploadArquivosCommandValidator validator;

        public UploadArquivosCommandHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = new UploadArquivosCommandValidator(context);
        }

        public async Task<int> Handle(UploadArquivosCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var arquivo = await context.Arquivos.FirstOrDefaultAsync(i => i.IdContexto == request.IdContexto
                                            && i.Contexto.Equals(request.Contexto, StringComparison.CurrentCultureIgnoreCase)
                                            && i.IdUsuario == request.IdUsuarioLogado);

            if (arquivo == null)
            {
                arquivo = mapper.Map<Domain.Entities.Arquivo>(request);
                await context.Arquivos.AddAsync(arquivo);
            }
            else
                arquivo = mapper.Map(request, arquivo);

            await context.SaveChangesAsync(cancellationToken);
            return 0;
        }
    }
}
