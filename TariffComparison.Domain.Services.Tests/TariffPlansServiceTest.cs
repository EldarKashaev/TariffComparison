using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TariffComparison.Domain.Models;
using TariffComparison.Infrastructure.Core;

namespace TariffComparison.Domain.Services.Tests
{
    [TestClass]
    public class TariffPlansServiceTest
    {
        private readonly Mock<ITariffPlansInfrastructureService> _infrastructureService;
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

        [TestMethod]
        [DataRow(3500, "830")]
        [DataRow(4500, "1050")]
        [DataRow(6000, "1380")]
        public void CompareAnnualCosts_BasicElectricityTariff_SuccessFlow(int consumption, string expectedCost)
        {
            _infrastructureService.Setup(_ => _.GetAll()).Returns(_plans);
            var result = _target.CompareAnnualCosts(new[] { consumption }).ToList();
            
            _infrastructureService.Verify(_ =>_.GetAll(), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Name, "basic electricity tariff");
            Assert.AreEqual(result[0].AnnualCosts[0], Convert.ToDecimal(expectedCost));
        }

        [TestMethod]
        [DataRow(3500, "800")]
        [DataRow(4500, "950")]
        [DataRow(6000, "1400")]
        public void CompareAnnualCosts_PackagedTariff_SuccessFlow(int consumption, string expectedCost)
        {
            _infrastructureService.Setup(_ => _.GetAll()).Returns(_plans);
            var result = _target.CompareAnnualCosts(new[] { consumption }).ToList();

            _infrastructureService.Verify(_ => _.GetAll(), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[1].Name, "Packaged tariff");
            Assert.AreEqual(result[1].AnnualCosts[0], Convert.ToDecimal(expectedCost));
        }

        #region Base Tariff Plans

        private readonly IEnumerable<TariffPlan> _plans = new List<TariffPlan>
        {
            new TariffPlan
            {
                Id = 1,
                Name = "basic electricity tariff",
                PriceList = new List<Price>
                {
                    new Price
                    {
                        Id = 1,
                        Description = "base cost per month",
                        Limit = 0,
                        BillingScheme = BillingScheme.Monthly,
                        Cost = new Money
                        {
                            Amount = 5,
                            SelectedCurrency = Currency.EUR
                        }
                    },
                    new Price
                    {
                        Id = 2,
                        Description = "consumption cost",
                        Limit = 0,
                        BillingScheme = BillingScheme.PerUnit,
                        Cost = new Money
                        {
                            Amount = 0.22M,
                            SelectedCurrency = Currency.EUR
                        }
                    }
                }
            },
            new TariffPlan
            {
                Id = 2,
                Name = "Packaged tariff",
                PriceList = new List<Price>
                {
                    new Price
                    {
                        Id = 3,
                        Description = "up to 4000 kWh/year",
                        Limit = 4000,
                        BillingScheme = BillingScheme.UpToLimitPerUnit,
                        Cost = new Money
                        {
                            Amount = 800M,
                            SelectedCurrency = Currency.EUR
                        }
                    },
                    new Price
                    {
                        Id = 4,
                        Description = "above 4000 kWh/year",
                        Limit = 4000,
                        BillingScheme = BillingScheme.AboveLimitPerUnit,
                        Cost = new Money
                        {
                            Amount = 0.30M,
                            SelectedCurrency = Currency.EUR
                        }
                    }
                }
            }
        };

        #endregion
    }
}
