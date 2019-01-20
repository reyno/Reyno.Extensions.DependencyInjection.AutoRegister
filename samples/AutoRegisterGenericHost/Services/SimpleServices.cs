using Microsoft.Extensions.DependencyInjection;

namespace AutoRegisterGenericHost.Services {

    [AutoRegister(ServiceLifetime.Singleton)]
    public class SimpleService : IAnother {
        public string Thing => "This is from SimpleService";
    }
}