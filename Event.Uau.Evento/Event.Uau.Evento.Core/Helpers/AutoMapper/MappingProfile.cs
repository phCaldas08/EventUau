using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Event.Uau.Evento.Core.Evento.Commands.CriarEvento;

namespace Event.Uau.Evento.Core.Helpers.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CriarEventoCommand, Domain.Entities.Evento>()
                .ForMember(i => i.IdUsuario, opt => opt.MapFrom(i => i.IdUsuarioLogado));

            CreateMap<Domain.Entities.Evento, ViewModel.Evento.EventoViewModel>();

            CreateMap<Domain.Entities.Evento, ViewModel.Evento.ResumoEventoViewModel>();

            CreateMap<Domain.Entities.FuncionarioEvento, ViewModel.Evento.FuncionarioEventoViewModel>();
        }
    }
}
