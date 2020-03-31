using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConscensiaTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ConscensiaController : ControllerBase
    {
        private readonly ILogger<ConscensiaController> _logger;

        public ConscensiaController(ILogger<ConscensiaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Int32 GetRandomNumber()
        {
            var rng = new Random();
            return rng.Next(1, 100);
        }
    }
}
