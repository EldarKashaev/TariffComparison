using System;
using System.Collections.Generic;
using System.Linq;
using TariffComparison.Domain.Services.Core;

namespace TariffComparison.Domain
{
    public class TariffPlansService : ITariffPlansService
    {
        public IEnumerable<TariffPlan> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new TariffPlan
            {
                Name = $"Tariff_Plan_{rng.Next().ToString()}"
            });
        }
    }
}
