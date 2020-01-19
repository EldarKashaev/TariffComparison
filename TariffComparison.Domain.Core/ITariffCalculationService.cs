using TariffComparison.Domain.Models;

namespace TariffComparison.Domain.Services.Core
{
    public interface ITariffCalculationService
    {
        Money GetAnnualPice(int tariffId, uint consumption);
    }
}
