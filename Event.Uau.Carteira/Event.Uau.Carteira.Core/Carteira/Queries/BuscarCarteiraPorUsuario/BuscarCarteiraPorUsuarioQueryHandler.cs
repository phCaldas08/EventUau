using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Carteira.Persistence;
using Event.Uau.Carteira.ViewModel.Carteira;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Core.Carteira.Queries.BuscarCarteiraPorUsuario
{
    public class BuscarCarteiraPorUsuarioQueryHandler : IRequestHandler<BuscarCarteiraPorUsuarioQuery, CarteiraViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;

        public BuscarCarteiraPorUsuarioQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CarteiraViewModel> Handle(BuscarCarteiraPorUsuarioQuery request, CancellationToken cancellationToken)
        {
            var carteira = await context.Carteiras.FirstOrDefaultAsync(i => i.IdUsuario == request.IdUsuarioLogado);

            var carteiraViewModel = mapper.Map<CarteiraViewModel>(carteira);

            return carteiraViewModel;
        }
    }
}
