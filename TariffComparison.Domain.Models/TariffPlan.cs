using System.Collections.Generic;
using System.Linq;

namespace TariffComparison.Domain.Models
{
    public class TariffPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Price> PriceList { get; set; }

        public Money AnnualCost(uint consumption)
        {
            return new Money {
                Amount = PriceList.Sum(_ => _.GetAnnualPrice(consumption).Amount),
                SelectedCurrency = Currency.EUR
            };
        }
    }
}
