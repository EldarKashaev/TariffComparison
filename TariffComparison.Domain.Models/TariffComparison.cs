using System.Collections.Generic;

namespace TariffComparison.Domain.Models
{
    public class TariffSummary
    {
        public string Name { get; set; }
        public List<decimal> AnnualCosts { get; set; }
    }
}
