using System.Collections.Generic;
using TariffComparison.Domain.Models;
using TariffComparison.Infrastructure.Core;

namespace TariffComparison.Infrastructure
{
    public class TariffPlansInfrastructureService : ITariffPlansInfrastructureService
    {
        private readonly IEnumerable<TariffPlan> _tariffPlans = new List<TariffPlan>
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

        public IEnumerable<TariffPlan> GetAll()
        {
            return _tariffPlans;
        }
    }
}
