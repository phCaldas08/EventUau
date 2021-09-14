using System;
using System.Collections.Generic;

namespace Event.Uau.Autenticacao.Test.Configuracoes.DadosTeste
{
    public static class Usuario
    {
        public static void CarregarUsuarios(this Persistence.EventUauDbContext context)
        {
            var usuarios = new List<Domain.Entities.Usuario>
            {
                new Domain.Entities.Usuario
                {
                    Cpf = "000.000.000-00",
                    DataNascimento = DateTime.Today.AddYears(-18),
                    Email = "teste@teste.com.br",
                    Endereco = "Rua Teste",
                    Nome = "Teste da Silva",
                    SobreMim = string.Empty,
                    Senha = "@Teste123",
                    Status = string.Empty,
                    Telefone = "11912345678",
                    ValorPorHora = 20
                }
            };

            context.Usuarios.AddRange(usuarios);
            context.SaveChanges();
        }
    }
}
