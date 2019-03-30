using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SC.Bus;
using SC.Domain.Commands.CreateNewPlaylist;

namespace SC.Api.BackgroundServices
{
    public class SpotifyMigrationService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IMediatorHandler _bus;
        public SpotifyMigrationService(ILogger<SpotifyMigrationService> log, IMediatorHandler bus)
        {
            _logger = log;
            _bus = bus;
        }
        public void Dispose()
        {
            
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço de migração de catalogos iniciado.");

            await _bus.Send(new CreateNewPlaylistCommand());

            _logger.LogInformation("Serviço de migração de catalogos concluido.");
             
        }

        public  Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço de migração de catalogos finalizado.");

            return Task.CompletedTask;
        }
    }
}
