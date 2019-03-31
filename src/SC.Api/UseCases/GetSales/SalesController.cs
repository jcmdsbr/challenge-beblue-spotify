using Microsoft.AspNetCore.Mvc;
using SC.Bus;
using SC.Domain.Queries.Models;
using SC.Domain.Queries.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SC.Api.UseCases.GetSales
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IMediatorHandler _bus;

        public SalesController(IMediatorHandler bus) => _bus = bus;

        [HttpGet]
        [ProducesResponseType(typeof(SalePagedQueryModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<SalePagedQueryModel> Get([Required]int page, [Required] int pageSize, DateTime? dtInitial, DateTime? dtEnd) 
                => await _bus.Execute(new GetSalesPagedQuery(page,pageSize,dtInitial,dtEnd));
    }
}