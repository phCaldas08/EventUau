using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Endereco.Core.TiposEnderecos.Queries.BuscarTipoEnderecoPorId;
using Event.Uau.Endereco.Persistence;
using Event.Uau.Endereco.ViewModel.Endereco;
using FluentValidation;
using MediatR;

namespace Event.Uau.Endereco.Core.TiposEnderecos.Commands.CadastrarTipoEndereco
{
    public class CadastrarTipoEnderecoCommandHandler : IRequestHandler<CadastrarTipoEnderecoCommand, TipoEnderecoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly CadastrarTipoEnderecoCommandValidator validator;

        public CadastrarTipoEnderecoCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
            this.validator = new CadastrarTipoEnderecoCommandValidator(context);
        }

        public async Task<TipoEnderecoViewModel> Handle(CadastrarTipoEnderecoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var tipoEndereco = mapper.Map<Domain.Entities.TipoEndereco>(request);

            await context.TiposEnderecos.AddAsync(tipoEndereco, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            var query = new BuscarTipoEnderecoPorIdQuery
            {
                IdTipoEndereco = tipoEndereco.Id,
                IdUsuarioLogado = request.IdUsuarioLogado,
                Token = request.Token
            };

            return await mediator.Send(query, cancellationToken);

        }
    }
}
