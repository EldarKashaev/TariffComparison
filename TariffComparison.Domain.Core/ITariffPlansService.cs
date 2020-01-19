using System.Collections.Generic;
using TariffComparison.Domain.Models;

namespace TariffComparison.Domain.Services.Core
{
    public interface ITariffPlansService
    {
        IEnumerable<TariffSummary> CompareAnnualCosts(int[] consumptions);
    }
}
