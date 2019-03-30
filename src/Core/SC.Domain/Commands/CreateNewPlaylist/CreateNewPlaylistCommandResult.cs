namespace SC.Domain.Commands.CreateNewPlaylist
{
    public class CreateNewPlaylistCommandResult : CommandResult
    {
        public CreateNewPlaylistCommandResult(bool success = true)
        {
            Success = success;
        }
    }
}