using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Endereco.Persistence;
using Event.Uau.Endereco.ViewModel.Endereco;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace Event.Uau.Endereco.Core.Enderecos.Queries.BuscarEnderecoPorId
{
    public class BuscarEnderecoPorIdQueryHandler : IRequestHandler<BuscarEnderecoPorIdQuery, EnderecoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly BuscarEnderecoPorIdQueryValidator validator;

        public BuscarEnderecoPorIdQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = new BuscarEnderecoPorIdQueryValidator(context);
        }

        public async Task<EnderecoViewModel> Handle(BuscarEnderecoPorIdQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var endereco = await context.Enderecos.FirstOrDefaultAsync(i => i.Id == request.IdEndereco
                                                                         && i.IdExterno == request.IdExterno
                                                                         && i.TipoEndereco.Descricao.Equals(request.TipoEndereco.Descricao, StringComparison.CurrentCultureIgnoreCase));

            var enderecoViewModel = mapper.Map<EnderecoViewModel>(endereco);

            return enderecoViewModel;
        }
    }
}
