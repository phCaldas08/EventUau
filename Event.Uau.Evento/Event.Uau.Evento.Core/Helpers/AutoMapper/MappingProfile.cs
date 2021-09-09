using System;
using AutoMapper;
using Event.Uau.Evento.Core.Evento.Commands.CriarEvento;

namespace Event.Uau.Evento.Core.Helpers.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CriarEventoCommand, Domain.Entities.Evento>();
            CreateMap<Domain.Entities.Evento, ViewModel.Evento.EventoViewModel>();
            CreateMap<Domain.Entities.Especialidade, ViewModel.Especialidade.EspecialidadeViewModel>();
        }
    }
}
