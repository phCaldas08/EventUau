using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.Event.Queries.GetById;
using Xunit;

namespace Event.Uau.Evento.Test.Event.Handlers.Queries
{
    public class GetByIdQuery : IClassFixture<EventUauTestBase>
    {
        private readonly EventUauTestBase eventUauTestBase;

        public GetByIdQuery(EventUauTestBase eventUauTestBase)
        {
            this.eventUauTestBase = eventUauTestBase;
        }

        [Theory]
        [InlineData("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeee1")]
        [InlineData("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeee2")]
        [InlineData("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeee3")]
        public async Task ProcuraEventoPorKeyExistente(string key)
        {
            //Arrange
            var keyEsperada = new Guid(key);
            var request = new Core.Event.Queries.GetById.GetByIdQuery
            {
                Key = keyEsperada
            };

            var handler = new GetByIdQueryHandler(eventUauTestBase.Context);

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.Equal(keyEsperada, result.Key);
        }

        [Fact]
        public async Task ProcuraEventoPorKeyNaoExistente()
        {
            //Arrange
            var request = new Core.Event.Queries.GetById.GetByIdQuery
            {
                Key = new Guid()
            };

            var handler = new GetByIdQueryHandler(eventUauTestBase.Context);

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.Null(result);
        }
    }
}
