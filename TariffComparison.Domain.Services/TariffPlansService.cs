using System;
using System.Collections.Generic;
using System.Linq;
using TariffComparison.Domain.Core;
using TariffComparison.Domain.Models;
using TariffComparison.Infrastructure.Core;

namespace TariffComparison.Domain.Services
{
    public class TariffPlansService : ITariffPlansService
    {
        private readonly ITariffPlansInfrastructureService _tariffPlans;
        public TariffPlansService(ITariffPlansInfrastructureService tariffPlans)
        {
            _tariffPlans = tariffPlans;
        }

        public IEnumerable<TariffSummary> CompareAnnualCosts(int[] consumptions)
        {
            if (consumptions == null)
            {
                throw new ArgumentException($"{nameof(consumptions)} is null");
            }
            if (consumptions.Any(value => value < 0))
            {
                throw new ArgumentException("Consumption cannot be negative value");
            }

            Array.Sort(consumptions);

            var tariffPlans = _tariffPlans.GetAll();
            return tariffPlans.Select(_ => new TariffSummary
            {
                Name = _.Name,
                AnnualCosts = consumptions.Select(consumption => _.AnnualCost((uint)consumption).Amount).ToList()
            });
        }
    }
}
