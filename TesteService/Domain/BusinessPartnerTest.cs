using FinancialDocument.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace TesteService.Domain
{
    public class BusinessPartnerTest
    {
        private readonly ITestOutputHelper output;

        public BusinessPartnerTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test_Telephone_Entity()
        {
            BusinessPartner entity = new BusinessPartner();
            entity.Telephone = "asd12 123e qsd 134 123";

            output.WriteLine(entity.Telephone);

            Assert.Equal("12123134123", entity.Telephone);
        }

        [Fact]
        public void Test_Celphone_Entity()
        {
            BusinessPartner entity = new BusinessPartner();
            entity.Celphone = "+55 (123) 98871-16527";

            output.WriteLine(entity.Celphone);

            Assert.Equal("551239887116527", entity.Celphone);
        }
    }
}
