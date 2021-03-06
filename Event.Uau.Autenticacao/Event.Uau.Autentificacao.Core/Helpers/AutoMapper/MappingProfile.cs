using System;
using AutoMapper;
using Event.Uau.Comum.Util.Extensoes;

namespace Event.Uau.Autenticacao.Core.Helpers.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Usuario, ViewModel.Autenticacao.UsuarioViewModel>();

            CreateMap<Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand, Domain.Entities.Usuario>()
                .ForMember(i => i.Senha, opt => opt.MapFrom(cadastrar => cadastrar.Senha.ToHash()))
                .ForMember(i => i.Telefone, opt => opt.MapFrom(cadastrar => cadastrar.Telefone.LimparTelefone()));

            CreateMap<Parceiro.Commands.CadastrarParceiro.CadastrarParceiroCommand, Domain.Entities.Parceiro>()
                .ForMember(i => i.IdUsuario, opt => opt.MapFrom(cadastrar => cadastrar.IdUsuarioLogado))
                .ForMember(i => i.Especialidades, opt => opt.Ignore());

            CreateMap<Parceiro.Commands.AtualizarParceiro.AtualizarParceiroCommand, Domain.Entities.Parceiro>()
                .ForMember(i => i.IdUsuario, opt => opt.MapFrom(cadastrar => cadastrar.IdUsuarioLogado))
                .ForMember(i => i.Especialidades, opt => opt.Ignore());

            CreateMap<Domain.Entities.Parceiro, ViewModel.Autenticacao.ParceiroViewModel>();

            CreateMap<Domain.Entities.Parceiro, ViewModel.Autenticacao.ParceiroResumoViewModel>();                
            
            CreateMap<Domain.Entities.Especialidade, ViewModel.Autenticacao.EspecialidadeViewModel>();

            CreateMap<Usuario.Commands.AtualizarUsuario.AtualizarUsuarioCommand, Domain.Entities.Usuario>();

            CreateMap<Especialidade.Commands.CadastrarEspecialidade.CadastrarEspecialidadeCommand, Domain.Entities.Especialidade>();

        }
    }
}
