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
                .ForMember(i => i.IdUsuario, opt => opt.MapFrom(cadastrar => cadastrar.IdUsuarioLogado));

            CreateMap<Domain.Entities.Parceiro, ViewModel.Autenticacao.ParceiroViewModel>();

            CreateMap<Domain.Entities.Parceiro, ViewModel.Autenticacao.ParceiroResumoViewModel>()
                .ForMember(i => i.Nome, opt => opt.MapFrom(i => i.Usuario.Nome));                
            
            CreateMap<Domain.Entities.Especialidade, ViewModel.Especialidade.EspecialidadeViewModel>();

            CreateMap<Usuario.Commands.AtualizarUsuario.AtualizarUsuarioCommand, Domain.Entities.Usuario>();

            CreateMap<Especialidade.Commands.CadastrarEspecialidade.CadastrarEspecialidadeCommand, Domain.Entities.Especialidade>();

        }
    }
}
