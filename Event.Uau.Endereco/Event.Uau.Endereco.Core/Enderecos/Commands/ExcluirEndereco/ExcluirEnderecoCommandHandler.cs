using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Endereco.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Endereco.Core.Enderecos.Commands.ExcluirEndereco
{
    public class ExcluirEnderecoCommandHandler : IRequestHandler<ExcluirEnderecoCommand, bool>
    {
        private readonly EventUauDbContext context;

        public ExcluirEnderecoCommandHandler(EventUauDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(ExcluirEnderecoCommand request, CancellationToken cancellationToken)
        {
            var endereco = await context.Enderecos
                .FirstOrDefaultAsync(i => i.Id == request.IdEndereco
                                        && i.IdExterno == request.IdExterno
                                        && i.TipoEndereco.Descricao.Equals(request.TipoEndereco, StringComparison.CurrentCultureIgnoreCase));

            context.Enderecos.Dele
        }
    }
}
