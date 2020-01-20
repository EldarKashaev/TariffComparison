using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TariffComparison.Infrastructure.Core;

namespace TariffComparison.Domain.Services.Tests
{
    [TestClass]
    public class TariffPlansServiceTest
    {
        private Mock<ITariffPlansInfrastructureService> _infrastructureService;
        private readonly TariffPlansService _target;

        public TariffPlansServiceTest()
        {
            _infrastructureService = new Mock<ITariffPlansInfrastructureService>();
            _target = new TariffPlansService(_infrastructureService.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareAnnualCosts_NullValue_ThrowArgumentException()
        {
            _target.CompareAnnualCosts(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareAnnualCosts_NegativeValue_ThrowArgumentException()
        {
            _target.CompareAnnualCosts(new[] { -1, -23444, 3000 });
        }
    }
}
