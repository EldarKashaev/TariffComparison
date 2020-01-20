using System;
using System.Linq;

namespace TariffComparison.WebApi.Validators
{
    public static class Validator
    {
        public static void Validate(this int[] consumptions)
        {
            if (consumptions.Any(_ => _ < 0))
            {
                throw new ArgumentException("Negative value provided");
            }
        }
    }
}
