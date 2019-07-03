using AutoRegisterGenericHost.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AutoRegisterGenericHost.HostedServices {

    [AutoRegister(ServiceLifetime.Singleton, typeof(IHostedService))]
    public class MainHostedService : IHostedService {
        private readonly IEnumerable<IAnother> _anothers;
        private readonly ILogger<MainHostedService> _logger;
        private readonly ISomething _something;

        public MainHostedService(
            ILogger<MainHostedService> logger,
            ISomething something,
            IEnumerable<IAnother> anothers
            ) {
            _anothers = anothers;
            _logger = logger;
            _something = something;
        }

        public Task StartAsync(CancellationToken cancellationToken) {

            _logger.LogInformation("Starting {service}", nameof(MainHostedService));

            _something.Do();
            foreach (var another in _anothers)
                _logger.LogInformation("IAnother.Thing = {result}", another.Thing);

            return Task.CompletedTask;

        }

        public Task StopAsync(CancellationToken cancellationToken) {

            _logger.LogInformation("Stopping {service}", nameof(MainHostedService));

            return Task.CompletedTask;

        }

    }
}
