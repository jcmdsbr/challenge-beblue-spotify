using Microsoft.AspNetCore.Mvc;
using SC.Bus;
using SC.Domain.Queries.Models;
using SC.Domain.Queries.Playlists;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace SC.Api.UseCases.GetPlaylists
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistsController : ControllerBase
    {
        private readonly IMediatorHandler _bus;

        public PlaylistsController(IMediatorHandler bus) => _bus = bus;

        [HttpGet]
        [ProducesResponseType(typeof(PlaylistPagedQueryModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<PlaylistPagedQueryModel> Get([Required]int page, [Required] int pageSize, string genre) 
                => await _bus.Execute(new GetPlaylistsPagedQuery(page, pageSize, genre));
    }
}