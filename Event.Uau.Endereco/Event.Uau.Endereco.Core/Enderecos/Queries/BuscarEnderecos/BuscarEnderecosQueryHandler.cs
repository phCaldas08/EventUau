using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Endereco.Persistence;
using Event.Uau.Endereco.ViewModel.Endereco;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace Event.Uau.Endereco.Core.Enderecos.Queries.BuscarEnderecos
{
    public class BuscarEnderecosQueryHandler : IRequestHandler<BuscarEnderecosQuery, List<EnderecoViewModel>>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly BuscarEnderecosQueryValidator validator;

        public BuscarEnderecosQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = new BuscarEnderecosQueryValidator(context);
        }

        public async Task<List<EnderecoViewModel>> Handle(BuscarEnderecosQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var enderecos = await context.Enderecos.Where(i => i.IdExterno == request.IdExterno
                                                           && i.TipoEndereco.Descricao.Equals(request.TipoEndereco.Descricao, StringComparison.CurrentCultureIgnoreCase))
                                                  .ToListAsync();

            var enderecosViewModel = mapper.Map<List<EnderecoViewModel>>(enderecos);

            return enderecosViewModel;
        }
    }
}
