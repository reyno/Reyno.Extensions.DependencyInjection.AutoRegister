using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection {

    internal static class ServiceCollectionExtensions {

        public static void AutoRegisterServices(this IServiceCollection services, Assembly[] assemblies) {

            var items = GetTypesToRegister(assemblies);

            foreach (var item in items)
                services.RegisterType(item.typeInfo, item.attribute);

        }

        internal static Type[] GetInterfaces(TypeInfo implementationType, AutoRegisterAttribute attribute) {

            var allInterfaces = implementationType.GetInterfaces();

            if (attribute.ServiceTypes != default && attribute.ServiceTypes.Length > 0) {
                var invalidInterfaces = attribute.ServiceTypes.Where(x => !x.IsAssignableFrom(implementationType));
                if (invalidInterfaces.Count() > 0)
                    throw new InvalidOperationException(
                        string.Concat(
                            Environment.NewLine,
                            $"[{implementationType.FullName}] does not implement the following types",
                            string.Concat(
                                invalidInterfaces.Select(x => string.Concat(Environment.NewLine, $" - {x.FullName}"))
                                ),
                            Environment.NewLine
                            ));

                return attribute.ServiceTypes;
            }

            return allInterfaces.Count() == 0
                ? new[] { implementationType }
                : allInterfaces
                ;

        }


        public static IEnumerable<(TypeInfo typeInfo, AutoRegisterAttribute attribute)> GetTypesToRegister(Assembly[] assemblies)
            => from assembly in assemblies
               from type in assembly.DefinedTypes
               let attribute = type.GetCustomAttribute<AutoRegisterAttribute>()
               where attribute != null
               select (type, attribute);

        public static void RegisterType(this IServiceCollection services, TypeInfo implementationType, AutoRegisterAttribute attribute) {

            var interfaces = GetInterfaces(implementationType, attribute);

            foreach (var serviceType in interfaces) {

                var usageAttribute = serviceType.GetCustomAttribute<AutoRegisterUsageAttribute>();

                // check for multiples
                var allowMultiple = !(usageAttribute?.AllowMultiple).IsDefault();
                if (!allowMultiple && services.Any(x => x.ServiceType == serviceType))
                    throw new InvalidOperationException($"Multiple registrations of type [{serviceType.FullName}] not allowed.");

                services.Add(new ServiceDescriptor(
                    serviceType,
                    implementationType,
                    attribute.ServiceLifetime
                    ));

            }
        }
    }

}