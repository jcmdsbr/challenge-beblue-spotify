using SC.Core.Commands;

namespace SC.Domain.Commands.GenerateDataSeedSpotify
{
    public class GenerateDataSeedSpotifyCommand : ICommand<GenerateDataSeedSpotifyCommandResult>
    {
        public GenerateDataSeedSpotifyCommand(string spotifyToken) => SpotifyToken = spotifyToken;

        public string SpotifyToken { get;}
    }
}