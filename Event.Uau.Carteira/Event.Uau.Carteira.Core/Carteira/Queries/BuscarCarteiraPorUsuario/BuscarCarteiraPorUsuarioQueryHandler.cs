using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Carteira.Persistence;
using MediatR;

namespace Event.Uau.Carteira.Core.Carteira.Queries.BuscarCarteiraPorUsuario
{
    public class BuscarCarteiraPorUsuarioQueryHandler : IRequestHandler<BuscarCarteiraPorUsuarioQuery, int>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;

        public BuscarCarteiraPorUsuarioQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(BuscarCarteiraPorUsuarioQuery request, CancellationToken cancellationToken)
        {

        }
    }
}
