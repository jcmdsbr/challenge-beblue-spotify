using Microsoft.AspNetCore.Mvc;
using SC.Bus;
using SC.Domain.Queries.Models;
using SC.Domain.Queries.Playlists;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SC.Api.UseCases.GetPlaylist
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistsController : ControllerBase
    {
        private readonly IMediatorHandler _bus;

        public PlaylistsController(IMediatorHandler bus) => _bus = bus;

        
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(PlaylistViewQueryModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<PlaylistViewQueryModel> Get(Guid id) => await _bus.Execute(new GetPlaylistByIdQuery(id));
    }
}