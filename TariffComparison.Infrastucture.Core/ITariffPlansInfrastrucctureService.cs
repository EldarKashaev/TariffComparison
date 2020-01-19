using System.Collections.Generic;

namespace TariffComparison.Infrastucture.Core
{
    public interface ITariffPlansInfrastrucctureService
    {
        IEnumerable<TariffPlan> GetAll();
    }
}
