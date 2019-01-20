using System;

namespace Microsoft.Extensions.DependencyInjection {

    [AttributeUsage(AttributeTargets.Interface)]
    public class AutoRegisterUsageAttribute : Attribute {

        public AutoRegisterUsageAttribute() {

        }

        public bool AllowMultiple { get; set; } = false;
    }
}