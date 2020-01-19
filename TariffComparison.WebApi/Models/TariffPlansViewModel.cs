using Newtonsoft.Json;
using System.Collections.Generic;

namespace TariffComparison.WebApi.Models
{
    public class TariffPlansViewModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("annual_costs")]
        public List<decimal> AnnualCosts { get; set; }
    }
}
