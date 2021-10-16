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
                }
            };

            //var commands = new List<Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand>
            //{
            //    new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
            //    {
            //        ConfirmarSenha = "@Teste123",
            //        Senha = "@Teste123",
            //        Cpf = "230.146.490-31",
            //        DataNascimento = DateTime.Today.AddYears(-18),
            //        Email = "teste@teste.com",
            //        Nome = "Teste de Oliveira",
            //        Telefone = "(11) 91234-1234",
            //    },
            //    new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
            //    {
            //        ConfirmarSenha = "@Parceiro123",
            //        Senha = "@Parceiro123",
            //        Cpf = "522.178.815-08",
            //        DataNascimento = DateTime.Today.AddYears(-22),
            //        Email = "camilaabreu@parceiro.com",
            //        Nome = "Camila Abreu",
            //        Telefone = "(11) 91234-4321",
            //    },
            //    new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
            //    {
            //        ConfirmarSenha = "@Parceiro123",
            //        Senha = "@Parceiro123",
            //        Cpf = "850.225.817-02",
            //        DataNascimento = DateTime.Today.AddYears(-30),
            //        Email = "parceiro@parceiro.com",
            //        Nome = "João da Silva",
            //        Telefone = "(11) 91234-4321",
            //    },
            //    new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
            //    {
            //        ConfirmarSenha = "@Parceiro123",
            //        Senha = "@Parceiro123",
            //        Cpf = "537.321.123-85",
            //        DataNascimento = DateTime.Today.AddYears(-25),
            //        Email = "felipesantos@parceiro.com",
            //        Nome = "Felipe dos Santos",
            //        Telefone = "(11) 91234-4321",
            //    },
            //    new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
            //    {
            //        ConfirmarSenha = "@Parceiro123",
            //        Senha = "@Parceiro123",
            //        Cpf = "321.654.987-15",
            //        DataNascimento = DateTime.Today.AddYears(-40),
            //        Email = "anamaria@parceiros.com",
            //        Nome = "Ana Maria",
            //        Telefone = "(11) 91234-4321",
            //    },
            //    new Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
            //    {
            //        ConfirmarSenha = "@Parceiro123",
            //        Senha = "@Parceiro123",
            //        Cpf = "941.561.345-15",
            //        DataNascimento = DateTime.Today.AddYears(-50),
            //        Email = "gabrielmarques@parceiros.com",
            //        Nome = "Gabriel Marques",
            //        Telefone = "(11) 91234-4321",
            //    }
            //};

            foreach (var command in commands)
                await mediator.Send(command);
        }

    }
}