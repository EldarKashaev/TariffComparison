using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TariffComparison.Domain.Core;
using TariffComparison.WebApi.Mappers;
using TariffComparison.WebApi.Models;
using TariffComparison.WebApi.Validators;

namespace TariffComparison.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TariffPlansController : ControllerBase
    {
        private readonly ITariffPlansService _tariffPlansService;

        public TariffPlansController(ITariffPlansService tariffPlansService)
        {
            _tariffPlansService = tariffPlansService;
        }

        [HttpGet("compare")]
        public IEnumerable<TariffPlansViewModel> Get([FromQuery(Name = "consumption")] int[] consumptions)
        {
            consumptions.Validate();
            return _tariffPlansService.CompareAnnualCosts(consumptions).Select(_ => _.ToViewModel());
        }
    }
}
