using System;
using TariffComparison.Domain.Models;
using TariffComparison.Domain.Services.Core;

namespace TariffComparison.Domain.Services
{
    public class TariffCalculationService : ITariffCalculationService
    {
        public Money GetAnnualPice(int tariffId, uint consumption)
        {
            throw new NotImplementedException();
        }
    }
}
