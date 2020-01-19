using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TariffComparison.Domain.Services.Core;
using TariffComparison.WebApi.Mappers;
using TariffComparison.WebApi.Models;

namespace TariffComparison.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TariffPlansController : ControllerBase
    {
        private readonly ILogger<TariffPlansController> _logger;
        private readonly ITariffPlansService _tariffPlansService;

        public TariffPlansController(ILogger<TariffPlansController> logger,
            ITariffPlansService tariffPlansService)
        {
            _logger = logger;
            _tariffPlansService = tariffPlansService;
        }

        [HttpGet("{consumptions}")]
        public IEnumerable<TariffPlansViewModel> Get([FromQuery] int[] consumptions)
        {
            return _tariffPlansService.CompareAnnualCosts(consumptions).Select(_ => _.ToViewModel());
        }
    }
}
