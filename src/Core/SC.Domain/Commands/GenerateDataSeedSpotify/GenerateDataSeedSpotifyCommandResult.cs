namespace SC.Domain.Commands.GenerateDataSeedSpotify
{
    public class GenerateDataSeedSpotifyCommandResult : CommandResult
    {
        public GenerateDataSeedSpotifyCommandResult(bool success = true) => Success = success;
    }
}