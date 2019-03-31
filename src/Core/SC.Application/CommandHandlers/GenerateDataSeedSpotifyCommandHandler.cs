using SC.Domain.Commands;
using System.Threading;
using System.Threading.Tasks;
using SC.Domain.Commands.GenerateDataSeedSpotify;
using SpotifyAPI.Web;

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
            SpotifyWebAPI api = new SpotifyWebAPI
            {
                AccessToken = request.SpotifyToken,
                TokenType = "Bearer"
            };

            var result = await api.SearchItemsAsync("", SpotifyAPI.Web.Enums.SearchType.Playlist, 50);

            return new GenerateDataSeedSpotifyCommandResult();
        }
    }
}