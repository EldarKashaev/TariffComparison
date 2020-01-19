using TariffComparison.Domain.Models;

namespace TariffComparison
{
    public class Price
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Money Cost { get; set; }
        public PaymentType PaymentType { get; set; }
        public uint LimitKWh { get; set; }
    }
}