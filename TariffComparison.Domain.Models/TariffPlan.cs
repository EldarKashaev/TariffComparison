using System;
using System.Collections.Generic;
using System.Linq;
using TariffComparison.Domain.Models;

namespace TariffComparison
{
    public class TariffPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Price> PriceList { get; set; }

        public Money AnnualCost(int consuption)
        {
            return new Money {
                Amount = PriceList.Sum(_ => _.GetAnnualPrice(consuption, Currency.EUR).Amount),
                SelectedCurrency = Currency.EUR
            };
        }
    }
}
