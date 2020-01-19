using System.Collections.Generic;
using TariffComparison.Domain.Models;
using TariffComparison.Infrastucture.Core;

namespace TariffComparison.Infastructure
{
    public class TariffPlansInfrastrucctureService : ITariffPlansInfrastrucctureService
    {
        private readonly IEnumerable<TariffPlan> tariffPlans = new List<TariffPlan>
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
                        LimitKWh = 0,
                        PaymentType = PaymentType.Mothly,
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
                        LimitKWh = 0,
                        PaymentType = PaymentType.PerKWh,
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
                        LimitKWh = 4000,
                        PaymentType = PaymentType.UpToLimit,
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
                        LimitKWh = 4000,
                        PaymentType = PaymentType.AboveLimit,
                        Cost = new Money
                        {
                            Amount = 0.30M,
                            SelectedCurrency = Currency.EUR
                        }
                    }
                }
            }
        };

        public IEnumerable<TariffPlan> GetAll()
        {
            return tariffPlans;
        }
    }
}
