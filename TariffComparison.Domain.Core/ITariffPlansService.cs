using System.Collections.Generic;

namespace TariffComparison.Domain.Services.Core
{
    public interface ITariffPlansService
    {
        IEnumerable<TariffPlan> GetAll();
    }
}
