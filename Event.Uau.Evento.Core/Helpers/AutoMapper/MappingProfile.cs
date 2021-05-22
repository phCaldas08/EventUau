using System;
using AutoMapper;
using Event.Uau.Evento.Core.Event.Commands.Create;
using Event.Uau.Evento.Core.Event.Commands.Update;

namespace Event.Uau.Evento.Core.Helpers.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEventCommand, Domain.Entities.Event>();
            CreateMap<UpdateEventCommand, Domain.Entities.Event>();
        }
    }
}
