using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AutoRegisterGenericHost {
    class Program {

        static void Main(string[] args) {

            var host = new HostBuilder()
                .ConfigureLogging((context, builder) => {
                    builder.AddConsole();
                    builder.AddDebug();
                })
                .AutoRegisterServices()
                .UseConsoleLifetime()
                .Build();

            host.Run();

        }

    }
}
