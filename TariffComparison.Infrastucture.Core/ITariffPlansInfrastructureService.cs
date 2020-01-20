using System.Collections.Generic;
using TariffComparison.Domain.Models;

namespace TariffComparison.Infrastructure.Core
{
    public interface ITariffPlansInfrastructureService
    {
        IEnumerable<TariffPlan> GetAll();
    }
}
