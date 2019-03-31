namespace SC.Domain.Commands.CreateNewPlaylist
{
    public class GenerateDataSeedSpotifyCommandResult : CommandResult
    {
        public GenerateDataSeedSpotifyCommandResult(bool success = true) => Success = success;
    }
}