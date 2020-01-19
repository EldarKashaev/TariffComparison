namespace TariffComparison.Domain.Models
{
    //TODO: Here we have to implement a Money Pattern in C#
    public class Money
    {
        public decimal Amount { get; set; }
        public Currency SelectedCurrency { get; set; }
    }
}
