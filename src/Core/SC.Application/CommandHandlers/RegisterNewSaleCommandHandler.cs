using System.Linq;
using SC.Domain.Commands.RegisterNewSale;
using System.Threading;
using System.Threading.Tasks;
using SC.Application.Repositories;
using SC.Core.Commands;
using SC.Core.Repository;
using SC.Domain.Entities;

namespace SC.Application.CommandHandlers
{
    public class RegisterNewSaleCommandHandler : ICommandHandler<RegisterNewSaleCommand, RegisterNewSaleCommandResult>
    {
        private readonly IPlaylistWriteOnlyRepository _playlistWriteOnlyRepository;
        private readonly IWriteOnlyRepository<Sale> _persistence;
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
            
            var shopCar = await _playlistWriteOnlyRepository.ListBy(request.Playlists);

            var details = shopCar.Select(playlist => SaleDetail.Create(playlist.Id, playlist.Price, playlist.CategoryId));

            var register = Sale.Register(request.CustomerCpf, details);

            await _persistence.AddAsync(register);
            await _unitOfWork.Commit();

            return  new RegisterNewSaleCommandResult("");
        }
    }
}