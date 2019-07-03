using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRegisterTests.TestTypes {

    public interface IService1 { }

    public interface IService2 { }

    [AutoRegisterUsage(AllowMultiple = true)]
    public interface IService3 { }

}
