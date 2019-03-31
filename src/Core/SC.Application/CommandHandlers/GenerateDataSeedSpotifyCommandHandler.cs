using SC.Domain.Commands;
using SC.Domain.Commands.CreateNewPlaylist;
using System.Threading;
using System.Threading.Tasks;

namespace SC.Application.CommandHandlers
{
    public class
        GenerateDataSeedSpotifyCommandHandler : ICommandHandler<GenerateDataSeedSpotifyCommand, GenerateDataSeedSpotifyCommandResult>
    {
        //private readonly IReadOnlyRepository<Category> _categories;
        //private readonly IWriteOnlyRepository<Playlist> _persistence;

        public async Task<GenerateDataSeedSpotifyCommandResult> Handle(GenerateDataSeedSpotifyCommand request,
            CancellationToken cancellationToken)
        {
            //var categories = await _categories.List();


            return new GenerateDataSeedSpotifyCommandResult();
        }
    }
}