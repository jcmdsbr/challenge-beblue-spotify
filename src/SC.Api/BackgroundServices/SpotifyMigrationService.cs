using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SC.Bus;
using SC.Domain.Commands.GenerateDataSeedSpotify;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SC.Api.BackgroundServices
{
    public class SpotifyMigrationService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IServiceScopeFactory _factory;
        private readonly IConfiguration _configuration;

        public SpotifyMigrationService(ILogger<SpotifyMigrationService> logger,
            IServiceScopeFactory factory, IConfiguration configuration)
        {
            _logger = logger;
            _factory = factory;
            _configuration = configuration;
        }

        public void Dispose()
        {

        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço de migração de catalogos iniciado.");

            using (IServiceScope factory = _factory.CreateScope())
            {
                IMediatorHandler bus = factory.ServiceProvider.GetRequiredService<IMediatorHandler>();
                string acessToken = _configuration.GetSection("SpotifyToken").Get<string>();

                await bus.Send(new GenerateDataSeedSpotifyCommand(acessToken));
            }

            _logger.LogInformation("Serviço de migração de catalogos concluido.");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço de migração de catalogos finalizado.");

            return Task.CompletedTask;
        }
    }
}
