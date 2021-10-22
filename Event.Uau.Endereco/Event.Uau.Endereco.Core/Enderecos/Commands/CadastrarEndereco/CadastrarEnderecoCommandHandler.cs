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
using Event.Uau.Endereco.Infrastructure.Cep.Interfaces;

namespace Event.Uau.Endereco.Core.Enderecos.Commands.CadastrarEndereco
{
    public class CadastrarEnderecoCommandHandler : IRequestHandler<CadastrarEnderecoCommand, EnderecoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly ICepIntegracao cepIntegracao;
        private readonly CadastrarEnderecoCommandValidator validator;

        public CadastrarEnderecoCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator, ICepIntegracao cepIntegracao)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
            this.cepIntegracao = cepIntegracao;
            this.validator = new CadastrarEnderecoCommandValidator(context, cepIntegracao);
        }

        public async Task<EnderecoViewModel> Handle(CadastrarEnderecoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var endereco = mapper.Map<Domain.Entities.Endereco>(request);

            endereco.TipoEndereco = await context.TiposEnderecos.FirstOrDefaultAsync(i => i.Descricao.Equals(request.TipoEndereco.Descricao, StringComparison.CurrentCultureIgnoreCase));

            if (request.Bairro == null || request.Logradouro == null || request.Cidade == null || request.Estado == null)
            {
                var cep = await cepIntegracao.BuscarEnderecoPorCep(request.Cep);

                endereco.Bairro = cep.Bairro;
                endereco.Cidade = cep.Cidade;
                endereco.Logradouro = cep.Endereco;
                endereco.Estado = cep.Estado;
            } else
            {
                endereco.Bairro = request.Bairro;
                endereco.Cidade = request.Cidade;
                endereco.Logradouro = request.Logradouro;
                endereco.Estado = request.Estado;
            }

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
