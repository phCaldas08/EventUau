using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Endereco.Persistence;
using Event.Uau.Endereco.ViewModel.Endereco;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Endereco.Core.TiposEnderecos.Queries.BuscarTipoEnderecoPorId
{
    public class BuscarTipoEnderecoPorIdQueryHandler : IRequestHandler<BuscarTipoEnderecoPorIdQuery, TipoEnderecoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly BuscarTipoEnderecoPorIdQueryValidator validator;

        public BuscarTipoEnderecoPorIdQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = new BuscarTipoEnderecoPorIdQueryValidator(context);
        }

        public async Task<TipoEnderecoViewModel> Handle(BuscarTipoEnderecoPorIdQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var tipoEndereco = await context.TiposEnderecos.FirstOrDefaultAsync(i => i.Id == request.IdTipoEndereco);

            var tipoEnderecoViewModel = mapper.Map<TipoEnderecoViewModel>(tipoEndereco);

            return tipoEnderecoViewModel;
            
        }
    }
}
