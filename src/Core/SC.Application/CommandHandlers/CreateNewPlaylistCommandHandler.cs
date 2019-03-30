using System.Threading;
using System.Threading.Tasks;
using SC.Domain.Commands;
using SC.Domain.Commands.CreateNewPlaylist;

namespace SC.Application.CommandHandlers
{
    public class CreateNewPlaylistCommandHandler : ICommandHandler<CreateNewPlaylistCommand, CreateNewPlaylistCommandResult>
    {
        public Task<CreateNewPlaylistCommandResult> Handle(CreateNewPlaylistCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}