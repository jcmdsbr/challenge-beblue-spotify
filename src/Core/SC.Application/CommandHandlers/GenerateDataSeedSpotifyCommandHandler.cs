using System;
using System.Threading;
using System.Threading.Tasks;
using Polly;
using SC.Application.Repositories;
using SC.Core.Commands;
using SC.Core.Repository;
using SC.Domain.Commands.GenerateDataSeedSpotify;
using SC.Domain.Entities;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;

namespace SC.Application.CommandHandlers
{
    public class
        GenerateDataSeedSpotifyCommandHandler : ICommandHandler<GenerateDataSeedSpotifyCommand, GenerateDataSeedSpotifyCommandResult>
    {
        private readonly ICategoryWriteOnlyRepository _categories;
        private readonly IPlaylistWriteOnlyRepository _persistence;
        private readonly IUnitOfWork _unitOfWork;

        public GenerateDataSeedSpotifyCommandHandler(ICategoryWriteOnlyRepository categories,
            IPlaylistWriteOnlyRepository persistence, IUnitOfWork unitOfWork)
        {
            _categories = categories;
            _persistence = persistence;
            _unitOfWork = unitOfWork;
        }

        public async Task<GenerateDataSeedSpotifyCommandResult> Handle(GenerateDataSeedSpotifyCommand request,
            CancellationToken cancellationToken)
        {
            var canMigrate = await _categories.CheckMigratePlaylistCategory();

            if(!canMigrate) return new GenerateDataSeedSpotifyCommandResult();

            var categories = await _categories.GetCategoriesWithoutPlaylist();

            var spotifyWebApi = new SpotifyWebAPI
            {
                AccessToken = request.SpotifyToken,
                TokenType = "Bearer"
            };

            var policy = Policy.Handle<Exception>().WaitAndRetryAsync(3, x=> TimeSpan.FromSeconds(10));

            var policyResult = await policy.ExecuteAndCaptureAsync(async () => await BulkInsertPlaylists());

            async Task BulkInsertPlaylists()
            {
                while (categories.Count > 0)
                {
                    var category = categories.Peek();

                    var result = await spotifyWebApi.SearchItemsAsync(category.Description, SearchType.Playlist, 50);

                    foreach (var playlist in result.Playlists.Items)
                    {
                        await _persistence.AddAsync(Playlist.CreateNewPlaylist(category.Id, playlist.Name));
                    }

                    // Bulk Insert by category
                    await _unitOfWork.Commit();

                    // Remove category in stack
                    categories.Pop();
                }
            }

            var hasSuccess = policyResult.ExceptionType is null;

            return new GenerateDataSeedSpotifyCommandResult(hasSuccess);
        }
    }
}