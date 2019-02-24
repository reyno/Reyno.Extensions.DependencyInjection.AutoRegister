using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Microsoft.Extensions.Hosting {

    public static class AutoRegisterHostBuilderExtensions {

        public static IHostBuilder AutoRegisterServices(this IHostBuilder hostBuilder) {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return AutoRegisterServices(hostBuilder, assemblies);
        }

        public static IHostBuilder AutoRegisterServices(this IHostBuilder hostBuilder, params Assembly[] assemblies) {

            hostBuilder.ConfigureServices((context, services) => {
                services.AutoRegisterServices(assemblies);
            });

            return hostBuilder;

        }
    }
}