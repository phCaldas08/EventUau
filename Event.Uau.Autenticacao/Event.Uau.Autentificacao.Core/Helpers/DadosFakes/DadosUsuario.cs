﻿using System;
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
                    Cpf = "402.094.690-64",
                    DataNascimento = DateTime.Today.AddYears(-18),
                    Email = "parceiro@parceiro.com",
                    Nome = "Parceiro de Oliveira",
                    Telefone = "(11) 91234-4321",
                },
            };

            foreach (var command in commands)
                await mediator.Send(command);
        }

    }
}