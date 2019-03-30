using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SC.Api.UseCases.GetSale
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<int>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IEnumerable<int> Get() => Enumerable.Range(1,10);
    }
}