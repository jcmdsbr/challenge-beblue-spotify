using Microsoft.AspNetCore.Mvc;
using SC.Bus;
using SC.Domain.Queries.Models;
using SC.Domain.Queries.Sales;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SC.Api.UseCases.GetSale
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IMediatorHandler _bus;

        public SalesController(IMediatorHandler bus) => _bus = bus;

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(SaleViewQueryModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<SaleViewQueryModel> Get(Guid id) => await _bus.Execute(new GetSaleByIdQuery(id));
    }
}