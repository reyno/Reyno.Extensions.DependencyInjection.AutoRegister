using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRegisterGenericHost.Services {

    [AutoRegister(ServiceLifetime.Singleton)]
    public class SuperService1 : ISomething, IAnother {
        private readonly ILogger<SuperService1> _logger;

        public SuperService1(
            ILogger<SuperService1> logger
            ) {
            _logger = logger;
        }

        public string Thing => "Here's the thing";

        public void Do() {
            _logger.LogInformation("I did something!");
        }

    }

}
