using System;
using System.Collections.Generic;

namespace TariffComparison
{
    public class TariffPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Price> PriceList { get; set; }
    }
}
