using System.Collections.Generic;
using TariffComparison.Domain.Services.Core;
using TariffComparison.Infrastucture.Core;

namespace TariffComparison.Domain
{
    public class TariffPlansService : ITariffPlansService
    {
        private readonly ITariffPlansInfrastrucctureService _tariffPlans;
        public TariffPlansService(ITariffPlansInfrastrucctureService tariffPlans)
        {
            _tariffPlans = tariffPlans;
        }
        public IEnumerable<TariffPlan> GetAll()
        {
            return _tariffPlans.GetAll();
        }
    }
}
