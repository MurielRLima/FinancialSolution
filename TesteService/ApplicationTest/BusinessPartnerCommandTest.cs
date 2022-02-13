using FinancialDocument.Data.Repositories;
using FinancialDocument.Service.CommandHandlers;
using FinancialDocument.Service.Commands;
using MediatR;
using Moq;
using System.IO;
using System.Text.Json;
using Xunit;
using Xunit.Abstractions;

namespace TesteService.ApplicationTest
{
    public class BusinessPartnerCommandTest
    {
        private readonly ITestOutputHelper output;

        public BusinessPartnerCommandTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public async void CommandPost_Test()
        {
            //Arange
            var mediator = new Mock<IMediator>();
            var repository = new Mock<BusinessPartnerRepository>();

            var s = File.ReadAllText("../../../Json/businessPartnerPost.json");
            var command = JsonSerializer.Deserialize<BusinessPartnerAddCommand>(s);

            BusinessPartnerAddCommandHandler handler = new BusinessPartnerAddCommandHandler(mediator.Object, repository.Object);

            ////Act
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Asert
            Assert.NotNull(x);

            //mediator.Verify(x => x.Publish(It.IsAny<BusinessPartnerAddResponse>()));
        }
    }
}
