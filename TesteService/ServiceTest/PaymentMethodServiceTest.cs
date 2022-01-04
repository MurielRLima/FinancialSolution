using FinancialDocument.Domain.Entities;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace TesteService
{
    public class PaymentMethodServiceTest
    {

        private readonly ITestOutputHelper output;

        public PaymentMethodServiceTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestSimpleSum()
        {
            PaymentMethod service = new PaymentMethod();
            Double valueTest = 255.15;

            var r = service.GetInstallmentsValue(3, valueTest);

            foreach (var value in r)
                output.WriteLine(value.ToString());

            Assert.Equal(valueTest, Math.Round(r.Sum(), 2, MidpointRounding.AwayFromZero));
        }

        [Fact]
        public void TestTitheSum()
        {
            PaymentMethod service = new PaymentMethod();
            Double valueTest = 554.17;

            var r = service.GetInstallmentsValue(3, valueTest);

            foreach (var value in r)
                output.WriteLine(value.ToString());

            Assert.Equal(valueTest, Math.Round(r.Sum(), 2, MidpointRounding.AwayFromZero));
        }

        [Fact]
        public void TestOneInstallment()
        {
            PaymentMethod service = new PaymentMethod();
            Double valueTest = 258.15;

            var r = service.GetInstallmentsValue(1, valueTest);

            foreach (var value in r)
                output.WriteLine(value.ToString());

            Assert.Equal(valueTest, Math.Round(r.Sum(), 2, MidpointRounding.AwayFromZero));
        }

        [Fact]
        public void TestCustomInstallment()
        {
            PaymentMethod service = new PaymentMethod();
            Double valueTest = 25848484.15;

            var r = service.GetInstallmentsValue(15, valueTest);

            foreach(var value in r)
            output.WriteLine(value.ToString());

            Assert.Equal(valueTest, Math.Round(r.Sum(), 2, MidpointRounding.AwayFromZero));
        }
    }
}
