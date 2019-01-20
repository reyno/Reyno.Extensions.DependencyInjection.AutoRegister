using System;

namespace Microsoft.Extensions.DependencyInjection {

    [AttributeUsage(AttributeTargets.Class)]
    public class AutoRegisterAttribute : Attribute {

        public readonly ServiceLifetime ServiceLifetime;
        public readonly Type[] ServiceTypes;

        public AutoRegisterAttribute(
            ServiceLifetime serviceLifetime,
            params Type[] serviceTypes
            ) {
            ServiceLifetime = serviceLifetime;
            ServiceTypes = serviceTypes;
        }

    }
}