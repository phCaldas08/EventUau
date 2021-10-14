using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Autenticacao.Persistence;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Autenticacao.Core.Usuario.Queries.BuscarUsuarios
{
    public class BuscarUsuariosQueryHandler : IRequestHandler<BuscarUsuariosQuery, ListaUsuarioViewModel>
    {
        private readonly IMapper mapper;
        private readonly EventUauDbContext context;
        private readonly BuscarUsuariosQueryValidator validator;

        public BuscarUsuariosQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
            this.validator = new BuscarUsuariosQueryValidator();
        }

        public async Task<ListaUsuarioViewModel> Handle(BuscarUsuariosQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var usuariosQuery = context.Usuarios.Where(i => request.IdsUsuarios == null || request.IdsUsuarios.Contains(i.Id));

            usuariosQuery = usuariosQuery.Where(i => string.IsNullOrWhiteSpace(request.TextoProcurado)
                                                     || i.Nome.Contains(request.TextoProcurado, StringComparison.CurrentCultureIgnoreCase)
                                                     || i.SobreMim.Contains(request.TextoProcurado, StringComparison.CurrentCultureIgnoreCase));

            var tamanhoTotal = usuariosQuery.Count();

            var usuarios = await usuariosQuery
                .OrderBy(i => i.Nome)
                .Skip(request.Indice * request.TamanhoPagina)
                .Take(request.TamanhoPagina)
                .ToListAsync();

            var usuariosViewModel = mapper.Map<List<UsuarioViewModel>>(usuarios);

            return new ListaUsuarioViewModel
            {
                Indice = request.Indice,
                Resultados = usuariosViewModel,
                TamanhoPagina = usuariosViewModel.Count,
                Total = tamanhoTotal
            };
                
        }
    }
}
