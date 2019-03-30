using System.Threading;
using System.Threading.Tasks;
using SC.Application.Repository;
using SC.Domain.Commands;
using SC.Domain.Commands.CreateNewPlaylist;
using SC.Domain.Models;

namespace SC.Application.CommandHandlers
{
    public class
        CreateNewPlaylistCommandHandler : ICommandHandler<CreateNewPlaylistCommand, CreateNewPlaylistCommandResult>
    {
        private readonly IReadOnlyRepository<Category> _categories;
        private readonly IWriteOnlyRepository<Playlist> _persistence;

        public async Task<CreateNewPlaylistCommandResult> Handle(CreateNewPlaylistCommand request,
            CancellationToken cancellationToken)
        {
            var categories = await _categories.List();


            return new CreateNewPlaylistCommandResult();
        }
    }
}