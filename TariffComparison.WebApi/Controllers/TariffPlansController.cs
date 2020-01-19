using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        private readonly ITariffPlansService _service;

        public TariffPlansController(ILogger<TariffPlansController> logger,
            ITariffPlansService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<TariffPlansViewModel> Get()
        {
            var tariffPlans = _service.GetAll();
            return tariffPlans.Select(_ => _.ToViewModel());
        }
    }
}
