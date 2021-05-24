using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.Event.Queries.GetList;
using Xunit;

namespace Event.Uau.Evento.Test.Event.Handlers.Queries
{
    public class GetListQuery : IClassFixture<EventUauTestBase>
    {
        private readonly EventUauTestBase eventUauTestBase;

        public GetListQuery(EventUauTestBase eventUauTestBase)
        {
            this.eventUauTestBase = eventUauTestBase;
        }

        [Fact]
        public async Task ProcuraListaSemFiltroPreenchido()
        {
            //Arrange
            var qtdEsperada = 3;
            var request = new Core.Event.Queries.GetList.GetListQuery();
            var handler = new GetListQueryHandler(eventUauTestBase.Context);

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.Equal(qtdEsperada, result.Count());
        }

        [Fact]
        public async Task ProcuraListaComRequestNula()
        {
            //Arrange
            var handler = new GetListQueryHandler(eventUauTestBase.Context);

            //Act

            //Assert
            await Assert.ThrowsAsync<NullReferenceException>(() =>
                //Act
                handler.Handle(null, CancellationToken.None));
        }


        [Theory]
        [InlineData(3, 0, 3)]
        [InlineData(1, 0, 1)]
        [InlineData(2, 0, 2)]
        [InlineData(0, 1, 0)]
        public async Task ProcurarPorRangeDeData(int qtdEsperada, int mesesInicio, int mesesTermino)
        {
            //Arrange
            var request = new Core.Event.Queries.GetList.GetListQuery
            {
                StartDate = DateTime.Now.AddMonths(mesesInicio),
                EndDate = DateTime.Now.AddMonths(mesesTermino),
            };
            var handler = new GetListQueryHandler(eventUauTestBase.Context);

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.Equal(qtdEsperada, result.Count());

        }

        [Theory]
        [InlineData(3, 3)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(0, -1)]
        public async Task ProcuraComDataInicialNula(int qtdEsperada, int mesesTermino)
        {
            //Arrange
            var request = new Core.Event.Queries.GetList.GetListQuery
            {
                StartDate = null,
                EndDate = DateTime.Now.AddMonths(mesesTermino),
            };
            var handler = new GetListQueryHandler(eventUauTestBase.Context);

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.Equal(qtdEsperada, result.Count());

        }


        [Theory]
        [InlineData(0, 3)]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(3, 0)]
        public async Task ProcuraComDataFinalNula(int qtdEsperada, int mesesInicio)
        {
            //Arrange
            var request = new Core.Event.Queries.GetList.GetListQuery
            {
                EndDate = null,
                StartDate = DateTime.Now.AddMonths(mesesInicio),
            };
            var handler = new GetListQueryHandler(eventUauTestBase.Context);

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.Equal(qtdEsperada, result.Count());

        }

        [Theory]
        [InlineData(1, "DesCrICAO 1")]
        [InlineData(3, "Descricao")]
        [InlineData(1, "dESCRICAO 2")]
        public async Task BuscaPorPalavrasIgnorandoCase(int qtdEsperada, string textoPesquisa)
        {
            //Arrange
            var request = new Core.Event.Queries.GetList.GetListQuery
            {
                textSearch = textoPesquisa
            };
            var handler = new GetListQueryHandler(eventUauTestBase.Context);

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.Equal(qtdEsperada, result.Count());

        }



    }
}
