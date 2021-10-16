using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;

namespace Event.Uau.Autenticacao.Core.Helpers.DadosFakes
{
    public static class DadosUsuario
    {
        public static async Task CarregarUsuariosAsync(this IMediator mediator)
        {
            var commands = new List<Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand>
            {
                new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
                {
                    ConfirmarSenha = "@Teste123",
                    Senha = "@Teste123",
                    Cpf = "230.146.490-31",
                    DataNascimento = DateTime.Today.AddYears(-18),
                    Email = "teste@teste.com",
                    Nome = "Teste de Oliveira",
                    Telefone = "(11) 91234-1234",
                },
                new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
                {
                    ConfirmarSenha = "@Parceiro123",
                    Senha = "@Parceiro123",
                    Cpf = "916.625.770-01",
                    DataNascimento = DateTime.Today.AddYears(-22),
                    Email = "camilaabreu@parceiro.com",
                    Nome = "Camila Abreu",
                    Telefone = "(11) 91234-4321",
                },
                new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
                {
                    ConfirmarSenha = "@Parceiro123",
                    Senha = "@Parceiro123",
                    Cpf = "270.213.820-90",
                    DataNascimento = DateTime.Today.AddYears(-30),
                    Email = "parceiro@parceiro.com",
                    Nome = "João da Silva",
                    Telefone = "(11) 91234-4322",
                },
                new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
                {
                    ConfirmarSenha = "@Parceiro123",
                    Senha = "@Parceiro123",
                    Cpf = "316.024.430-09",
                    DataNascimento = DateTime.Today.AddYears(-25),
                    Email = "felipesantos@parceiro.com",
                    Nome = "Felipe dos Santos",
                    Telefone = "(11) 91234-4323",
                },
                new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
                {
                    ConfirmarSenha = "@Parceiro123",
                    Senha = "@Parceiro123",
                    Cpf = "596.634.670-45",
                    DataNascimento = DateTime.Today.AddYears(-40),
                    Email = "anamaria@parceiros.com",
                    Nome = "Ana Maria",
                    Telefone = "(11) 91234-4324",
                },
                new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
                {
                    ConfirmarSenha = "@Parceiro123",
                    Senha = "@Parceiro123",
                    Cpf = "941.097.710-05",
                    DataNascimento = DateTime.Today.AddYears(-50),
                    Email = "gabrielmarques@parceiros.com",
                    Nome = "Gabriel Marques",
                    Telefone = "(11) 91234-4325"
                },
                new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
                {
                    ConfirmarSenha = "@Parceiro123",
                    Senha = "@Parceiro123",
                    Cpf = "147.188.370-14",
                    DataNascimento = DateTime.Today.AddYears(-35),
                    Email = "dilanferreira@parceiros.com",
                    Nome = "Dilan Ferreira",
                    Telefone = "(11) 95425-4325",
                },
                new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
                {
                    ConfirmarSenha = "@Parceiro123",
                    Senha = "@Parceiro123",
                    Cpf = "624.092.220-05",
                    DataNascimento = DateTime.Today.AddYears(-42),
                    Email = "rebeccakeil@parceiros.com",
                    Nome = "Rebecca Keil",
                    Telefone = "(11) 94324-4325",
                },
                new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
                {
                    ConfirmarSenha = "@Parceiro123",
                    Senha = "@Parceiro123",
                    Cpf = "428.484.220-09",
                    DataNascimento = DateTime.Today.AddYears(-44),
                    Email = "hazaeljanes@parceiros.com",
                    Nome = "Hazael Janes",
                    Telefone = "(11) 94323-4325",
                },
                new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
                {
                    ConfirmarSenha = "@Parceiro123",
                    Senha = "@Parceiro123",
                    Cpf = "210.583.070-61",
                    DataNascimento = DateTime.Today.AddYears(-23),
                    Email = "eliseufraga@parceiros.com",
                    Nome = "Eliseu Fraga",
                    Telefone = "(11) 94322-4325",
                },
                new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
                {
                    ConfirmarSenha = "@Parceiro123",
                    Senha = "@Parceiro123",
                    Cpf = "895.035.900-60",
                    DataNascimento = DateTime.Today.AddYears(-39),
                    Email = "simarabastos@parceiros.com",
                    Nome = "Simara Bastos",
                    Telefone = "(11) 94321-4325",
                }
            };

            foreach (var command in commands)
                await mediator.Send(command);
        }

    }
}