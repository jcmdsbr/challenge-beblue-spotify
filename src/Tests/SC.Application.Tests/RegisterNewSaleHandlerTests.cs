using System;
using Xunit;
using System.Linq;
using SC.Domain.Commands.RegisterNewSale;
using SC.Application.CommandHandlers;
using SC.Core.Repository;
using SC.Domain.Entities;
using NSubstitute;
using SC.Application.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SC.Application.Tests
{
    public class RegisterNewSaleHandlerTests
    {
        private readonly IWriteOnlyRepository<Sale> _persistenceMock;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlaylistWriteOnlyRepository _playlistWriteOnlyRepository;
        public RegisterNewSaleHandlerTests()
        {
            _persistenceMock = Substitute.For<IWriteOnlyRepository<Sale>>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _playlistWriteOnlyRepository = Substitute.For<IPlaylistWriteOnlyRepository>();
        }

        [Theory]
        [InlineData("12103169603")]
        [InlineData("40947626638")]
        [InlineData("83423267054")]
        public async void RegisterSuccess(string value)
        {
            var playlistsMock = Enumerable.Range(1, 10).Select(x => Guid.NewGuid()).ToList();
            var command = new RegisterNewSaleCommand(playlistsMock, value);
            var handler = new RegisterNewSaleCommandHandler(_playlistWriteOnlyRepository, _persistenceMock, _unitOfWork);
            var category = new Random().Next(4);

            // Get playlists mock
            _playlistWriteOnlyRepository.ListBy(playlistsMock)
               .Returns(Task.FromResult(playlistsMock.Select(x => Playlist.CreateNewPlaylist(category, x.ToString())).ToList()));

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.True(result.Success);
        }
    }
}
