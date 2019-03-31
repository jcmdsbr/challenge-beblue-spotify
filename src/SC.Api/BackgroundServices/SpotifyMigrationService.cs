using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SC.Api.BackgroundServices
{
    public class SpotifyMigrationService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;

        public SpotifyMigrationService(ILogger<SpotifyMigrationService> log) => _logger = log;
        public void Dispose()
        {

        }

        public  Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço de migração de catalogos iniciado.");


            _logger.LogInformation("Serviço de migração de catalogos concluido.");

            return Task.CompletedTask;

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço de migração de catalogos finalizado.");

            return Task.CompletedTask;
        }
    }
}
