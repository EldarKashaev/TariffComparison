using System;

namespace TariffComparison.Domain.Models
{
    public class Price
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Money Cost { get; set; }
        public BillingScheme BillingScheme { get; set; }
        public uint Limit { get; set; }

        public Money GetAnnualPrice(uint consumption, Currency currency = Currency.EUR) {
            var price = new Money
            {
                SelectedCurrency = currency
            };

            switch(this.BillingScheme)
            {
                case BillingScheme.Monthly:
                    price.Amount = this.Cost.Amount * 12;
                    break;
                case BillingScheme.PerUnit:
                    price.Amount = this.Cost.Amount * consumption;
                    break;
                case BillingScheme.UpToLimitPerUnit:
                    price.Amount = this.Cost.Amount;
                    break;
                case BillingScheme.AboveLimitPerUnit:
                    if (consumption > Limit)
                    {
                        price.Amount = this.Cost.Amount * (consumption - this.Limit);
                    }
                    break;
                default:
                    throw new ArgumentException("Unhandled value: " + this.BillingScheme);
            }

            return price;
        }
    }
}