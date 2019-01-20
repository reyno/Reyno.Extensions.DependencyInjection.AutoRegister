using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Microsoft.AspNetCore.Hosting {

    public static class WebHostBuilderExtensions {

        public static IWebHostBuilder AutoRegisterServices(this IWebHostBuilder webHostBuilder)
            => AutoRegisterServices(
                webHostBuilder,
                AppDomain.CurrentDomain.GetAssemblies()
                );

        public static IWebHostBuilder AutoRegisterServices(this IWebHostBuilder webHostBuilder, params Assembly[] assemblies) {

            return webHostBuilder.ConfigureServices((context, services) => {
                services.AutoRegisterServices(assemblies);
            });

        }

    }
}