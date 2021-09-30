using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Upload.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Upload.Core.Arquivo.Commands.DeletarArquivo
{
    public class DeletarArquivoCommandHandler : IRequestHandler<DeletarArquivoCommand, int>
    {
        private readonly EventUauDbContext context;
        private readonly DeletarArquivoCommandValidator validator;

        public DeletarArquivoCommandHandler(EventUauDbContext context)
        {
            this.context = context;
            this.validator = new DeletarArquivoCommandValidator(context);
        }

        public async Task<int> Handle(DeletarArquivoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var arquivo = await context.Arquivos.FirstOrDefaultAsync(i => i.IdContexto == request.IdContexto && i.Contexto == request.Contexto);

            context.Arquivos.Remove(arquivo);

            await context.SaveChangesAsync(cancellationToken);

            return 0;
        }
    }
}
