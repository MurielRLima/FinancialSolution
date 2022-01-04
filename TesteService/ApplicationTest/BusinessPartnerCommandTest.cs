using FinancialDocument.Data.Context;
using FinancialDocument.Data.Repositories;
using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Service.CommandHandlers;
using FinancialDocument.Service.Commands;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
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

            //mediator.Setup(m => m.Publish(It.IsAny<BusinessPartnerAddCommand>(), It.IsAny<CancellationToken>())).Callback<BusinessPartnerAddCommand, CancellationToken>((notification, cToken) => _yourHandlerService.Handle(notification, cToken))

            BusinessPartnerAddCommandHandler handler = new BusinessPartnerAddCommandHandler(mediator.Object, repository.Object);

            ////Act
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Asert
            Assert.NotNull(x);

            //something like:
            //mediator.Verify(x => x.Publish(It.IsAny<CustomersChanged>()));
        }
    }
}
