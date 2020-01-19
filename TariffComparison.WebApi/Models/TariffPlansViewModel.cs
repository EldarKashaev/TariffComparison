using Newtonsoft.Json;

namespace TariffComparison.WebApi.Models
{
    public class TariffPlansViewModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
