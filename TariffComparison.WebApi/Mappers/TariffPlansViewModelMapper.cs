using TariffComparison.WebApi.Models;

namespace TariffComparison.WebApi.Mappers
{
    public static class TariffPlansViewModelMapper
    {
        public static TariffPlansViewModel ToViewModel(this TariffPlan model)
        {
            return new TariffPlansViewModel
            {
                Name = model.Name
            };
        }
    }
}
