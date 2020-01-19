using System;
using TariffComparison.Domain.Models;

namespace TariffComparison
{
    public class Price
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Money Cost { get; set; }
        public PaymentType PaymentType { get; set; }
        public int LimitKWh { get; set; }

        public Money GetAnnualPrice(int consumption, Currency currency = Currency.EUR) {
            Money price = new Money()
            {
                SelectedCurrency = currency
            };

            switch(this.PaymentType)
            {
                case PaymentType.Mothly:
                    price.Amount = this.Cost.Amount * 12;
                    break;
                case PaymentType.PerKWh:
                    price.Amount = this.Cost.Amount * consumption;
                    break;
                case PaymentType.UpToLimitPerKWh:
                    price.Amount = this.Cost.Amount;
                    break;
                case PaymentType.AboveLimitPerKWh:
                    if (consumption > LimitKWh)
                    {
                        price.Amount = this.Cost.Amount;
                    }
                    break;
                default:
                    throw new ArgumentException("Unhandled value: " + this.PaymentType.ToString());
            }

            return price;
        }
    }
}