using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Autenticacao.Test.Configuracoes;
using Xunit;

namespace Event.Uau.Autenticacao.Test.Usuario.Commands
{
    public class CadastrarUsuarioTest : IClassFixture<EventUauAutenticacaoTestBase>
    {
        private readonly EventUauAutenticacaoTestBase @base;

        public CadastrarUsuarioTest(EventUauAutenticacaoTestBase @base)
        {
            this.@base = @base;
        }

        [Fact]
        public async Task CadastrarUsuario()
        {
            //Arrange
            var command = new Core.Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand
            {
                ConfirmarSenha = "@Teste123",
                Senha = "@Teste123",
                Cpf = "230.146.490-31",
                DataNascimento = DateTime.Today.AddYears(-18),
                Email = "teste.1@teste.com.br",
                Nome = "Teste",
                SobreNome = "De Oliveira",
                Telefone = "(11) 91234-1234",
            };

            var handler = new Core.Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommandHandler(@base.context, @base.mapper);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
        }
    }
}
