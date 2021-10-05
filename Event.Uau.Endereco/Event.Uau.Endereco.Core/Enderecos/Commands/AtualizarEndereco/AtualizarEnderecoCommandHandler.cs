using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Endereco.Core.Enderecos.Queries.BuscarEnderecoPorId;
using Event.Uau.Endereco.Infrastructure.Cep.Interfaces;
using Event.Uau.Endereco.Persistence;
using Event.Uau.Endereco.ViewModel.Endereco;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Endereco.Core.Enderecos.Commands.AtualizarEndereco
{
    public class AtualizarEnderecoCommandHandler : IRequestHandler<AtualizarEnderecoCommand, EnderecoViewModel>
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly EventUauDbContext context;
        private readonly ICepIntegracao cepIntegracao;
        private readonly AtualizarEnderecoCommandValidator validator;

        public AtualizarEnderecoCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator, ICepIntegracao cepIntegracao)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.context = context;
            this.cepIntegracao = cepIntegracao;
            this.validator = new AtualizarEnderecoCommandValidator(context, cepIntegracao);
        }

        public async Task<EnderecoViewModel> Handle(AtualizarEnderecoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var endereco = await context.Enderecos.FirstOrDefaultAsync(i => i.Id == request.IdEndereco
                                                                         && i.IdExterno == request.IdExterno
                                                                         && i.TipoEndereco.Descricao.Equals(request.TipoEndereco.Descricao, StringComparison.CurrentCultureIgnoreCase));

            endereco = mapper.Map(request, endereco);

            endereco.TipoEndereco = await context.TiposEnderecos.FirstOrDefaultAsync(i => i.Descricao.Equals(request.TipoEndereco.Descricao));

            var cep = await cepIntegracao.BuscarEnderecoPorCep(request.Cep);

            endereco.Bairro = cep.Bairro;
            endereco.Cidade = cep.Cidade;
            endereco.Logradouro = cep.Endereco;
            endereco.Estado = cep.Estado;

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
