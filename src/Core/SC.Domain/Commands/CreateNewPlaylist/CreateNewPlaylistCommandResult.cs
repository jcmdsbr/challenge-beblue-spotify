namespace SC.Domain.Commands.CreateNewPlaylist
{
    public class CreateNewPlaylistCommandResult : CommandResult
    {
        public CreateNewPlaylistCommandResult(bool success)
        {
            Success = success;
        }
    }
}