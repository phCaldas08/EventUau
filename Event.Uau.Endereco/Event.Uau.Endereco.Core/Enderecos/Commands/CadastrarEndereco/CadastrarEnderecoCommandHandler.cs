using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Endereco.Core.Enderecos.Queries.BuscarEnderecoPorId;
using Event.Uau.Endereco.Persistence;
using Event.Uau.Endereco.ViewModel.Endereco;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace Event.Uau.Endereco.Core.Enderecos.Commands.CadastrarEndereco
{
    public class CadastrarEnderecoCommandHandler : IRequestHandler<CadastrarEnderecoCommand, EnderecoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly CadastrarEnderecoCommandValidator validator;

        public CadastrarEnderecoCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
            this.validator = new CadastrarEnderecoCommandValidator(context);
        }

        public async Task<EnderecoViewModel> Handle(CadastrarEnderecoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var endereco = mapper.Map<Domain.Entities.Endereco>(request);

            endereco.TipoEndereco = await context.TiposEnderecos.FirstOrDefaultAsync(i => i.Descricao.Equals(request.TipoEndereco.Descricao, StringComparison.CurrentCultureIgnoreCase));

            await context.Enderecos.AddAsync(endereco, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            var query = new BuscarEnderecoPorIdQuery
            {
                IdEndereco = endereco.Id,
                IdExterno = request.IdExterno,
                IdUsuarioLogado = request.IdUsuarioLogado,
                TipoEndereco = request.TipoEndereco,
                Token = request.Token
            };

            return await mediator.Send(query, cancellationToken);

        }
    }
}
