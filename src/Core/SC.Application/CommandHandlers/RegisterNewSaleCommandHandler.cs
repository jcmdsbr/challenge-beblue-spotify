using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Polly;
using SC.Application.Repositories;
using SC.Core.Commands;
using SC.Core.Repository;
using SC.Domain.Commands.RegisterNewSale;
using SC.Domain.Entities;

namespace SC.Application.CommandHandlers
{
    public class RegisterNewSaleCommandHandler : ICommandHandler<RegisterNewSaleCommand, RegisterNewSaleCommandResult>
    {
        private readonly IWriteOnlyRepository<Sale> _persistence;
        private readonly IPlaylistWriteOnlyRepository _playlistWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterNewSaleCommandHandler(IPlaylistWriteOnlyRepository playlistWriteOnlyRepository,
            IWriteOnlyRepository<Sale> persistence, IUnitOfWork unitOfWork)
        {
            _playlistWriteOnlyRepository = playlistWriteOnlyRepository;
            _persistence = persistence;
            _unitOfWork = unitOfWork;
        }

        public async Task<RegisterNewSaleCommandResult> Handle(RegisterNewSaleCommand request,
            CancellationToken cancellationToken)
        {
            var policy = Policy.Handle<Exception>().WaitAndRetryAsync(3, x => TimeSpan.FromSeconds(10));

            var policyResult = await policy.ExecuteAndCaptureAsync(async () => await RegisterSale());

            async Task RegisterSale()
            {
                var shopCar = await _playlistWriteOnlyRepository.ListBy(request.Playlists);

                var details =
                    shopCar.Select(playlist => SaleDetail.CreateByPlaylist(playlist));

                var register = Sale.Register(request.CustomerCpf, details.ToList());

                await _persistence.AddAsync(register);
                await _unitOfWork.Commit();

            };

            var hasSuccess = !policyResult.ExceptionType.HasValue;

            var message = hasSuccess ? "Registred Sale" : policyResult.FinalException.Message;

            return new RegisterNewSaleCommandResult(hasSuccess, message);
        }
    }
}