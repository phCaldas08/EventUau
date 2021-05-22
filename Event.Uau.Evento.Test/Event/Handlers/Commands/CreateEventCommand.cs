using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.Event.Commands.Create;
using Xunit;

namespace Event.Uau.Evento.Test.Event.Handlers.Commands
{
    public class CreateEventCommand : IClassFixture<EventUauTestBase>
    {
        public readonly EventUauTestBase eventUauTestBase;

        public CreateEventCommand(EventUauTestBase eventUauTestBase)
        {
            this.eventUauTestBase = eventUauTestBase;
        }

        [Fact]
        public async Task CriarEvento()
        {
            //Arrange
            var command = new Core.Event.Commands.Create.CreateEventCommand
            {
                Description = "Evento de teste",
                Name = "Evento Teste",
                Date = DateTime.Now.AddDays(10)
            };

            var commandHandler = new CreateEventCommandHandler(eventUauTestBase.Context);

            //Act
            var createdEvent = await commandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.NotNull(createdEvent);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-30)]
        public async Task CriarEventoComDataNoPassado(int mesesParaAdicionar)
        {
            //Arrange
            var command = new Core.Event.Commands.Create.CreateEventCommand
            {
                Description = "Evento de teste",
                Name = "Evento Teste",
                Date = DateTime.Now.AddMonths(mesesParaAdicionar)
            };

            var commandHandler = new CreateEventCommandHandler(eventUauTestBase.Context);

            //Assert
            var actualException = await Assert.ThrowsAsync<Exception>(() =>
                //Act
                commandHandler.Handle(command, CancellationToken.None));
        }
    }
}
