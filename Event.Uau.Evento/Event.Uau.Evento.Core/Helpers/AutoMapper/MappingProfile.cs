using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Event.Uau.Evento.Core.Evento.Commands.CriarEvento;
using Event.Uau.Evento.Core.Proposta.Commands.EnviarPropostaFuncionario;

namespace Event.Uau.Evento.Core.Helpers.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CriarEventoCommand, Domain.Entities.Evento>()
                .ForMember(i => i.IdUsuario, opt => opt.MapFrom(i => i.IdUsuarioLogado));

            CreateMap<Domain.Entities.Evento, ViewModel.Evento.EventoViewModel>()
                .ForMember(i => i.FuncionariosEvento, opt => opt.MapFrom(i => i.Funcionarios));

            CreateMap<Domain.Entities.Evento, ViewModel.Evento.ResumoEventoViewModel>();

            CreateMap<Domain.Entities.FuncionarioEvento, ViewModel.Evento.FuncionarioEventoViewModel>();

            CreateMap<EnviarPropostaFuncionarioCommand, Domain.Entities.FuncionarioEvento>()
                .ForMember(i => i.IdUsuario, opt => opt.MapFrom(i => i.Usuario.Id))
                .ForMember(i => i.IdEspecialidade, opt => opt.MapFrom(i => i.Especialidade.Id))
                .ForMember(i => i.IdStatusContratacao, opt => opt.MapFrom(i => "PEN"))
                .ForMember(i => i.Salario, opt => opt.MapFrom(i => i.SalarioComTaxa));

            CreateMap<Domain.Entities.FuncionarioEvento, ViewModel.Evento.FuncionarioEventoViewModel>();

            CreateMap<Domain.Entities.FuncionarioEvento, ViewModel.Evento.PropostaEventoViewModel>()
                .ForMember(i => i.ValorProposta, opt => opt.MapFrom(i => i.Salario))
                .ForMember(i => i.Status, opt => opt.MapFrom(i => i.Evento.Status));

            CreateMap<Domain.Entities.Evento, ViewModel.Evento.PropostaEventoViewModel>();

            CreateMap<StatusContratacao.Commands.CadastrarStatusContratacao.CadastrarStatusContratacaoCommand, Domain.Entities.StatusContratacao>();

            CreateMap<Domain.Entities.StatusContratacao, ViewModel.Evento.StatusContratacaoViewModel>();

            CreateMap<Domain.Entities.Status, ViewModel.Evento.StatusViewModel>();

            CreateMap<Status.Commands.CadastrarStatus.CadastrarStatusCommand, Domain.Entities.Status>();
                
        }
    }
}
