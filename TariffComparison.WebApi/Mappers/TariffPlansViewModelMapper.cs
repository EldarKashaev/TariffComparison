using TariffComparison.Domain.Models;
using TariffComparison.WebApi.Models;

namespace TariffComparison.WebApi.Mappers
{
    public static class TariffPlansViewModelMapper
    {
        public static TariffPlansViewModel ToViewModel(this TariffSummary model)
        {
            return new TariffPlansViewModel
            {
                name = model.Name,
                annual_costs = model.AnnualCosts
            };
        }
    }
}
