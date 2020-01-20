using System.Collections.Generic;

namespace TariffComparison.WebApi.Models
{
    public class TariffPlansViewModel
    {
        public string name { get; set; }
        public List<decimal> annual_costs { get; set; }
    }
}
