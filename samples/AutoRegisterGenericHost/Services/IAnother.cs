using Microsoft.Extensions.DependencyInjection;

namespace AutoRegisterGenericHost.Services {

    [AutoRegisterUsage(AllowMultiple = true)]
    public interface IAnother {
        string Thing { get; }
    }
}