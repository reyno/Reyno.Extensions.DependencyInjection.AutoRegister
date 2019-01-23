using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRegisterTests.TestTypes {
    public class ImplementsNoInterface { }
    public class ImplementsService1 : IService1 { }
    public class ImplementsService1And2 : IService1, IService2 { }
}
