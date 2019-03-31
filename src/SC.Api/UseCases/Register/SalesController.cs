using Microsoft.AspNetCore.Mvc;
using SC.Bus;
using SC.Domain.Commands.RegisterNewSale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SC.Api.UseCases.Register
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IMediatorHandler _bus;

        public SalesController(IMediatorHandler bus)
        {
            _bus = bus;
        }

        [HttpPost]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _bus.Send(new RegisterNewSaleCommand());

            return Ok(result);
        }
    }
}