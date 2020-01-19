using System.Collections.Generic;
using System.Linq;
using TariffComparison.Domain.Models;
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

        public IEnumerable<TariffSummary> CompareAnnualCosts(int[] consumptions)
        {
            var tariffPlans = _tariffPlans.GetAll();
            return tariffPlans.Select(_ => new TariffSummary
            {
                Name = _.Name,
                AnnualCosts = consumptions.Select(consumption => _.AnnualCost(consumption).Amount).ToList()
            });
        }
    }
}
