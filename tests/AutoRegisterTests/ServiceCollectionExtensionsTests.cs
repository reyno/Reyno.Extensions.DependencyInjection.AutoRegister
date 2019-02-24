using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using AutoRegisterTests.TestTypes;
using System.Reflection;
using System;
using System.Linq;

namespace AutoRegisterTests {

    [TestClass]
    public class ServiceCollectionExtensionsTests {

        [TestMethod]
        public void GetInterfaces_WithInvalidType_ThrowException() {

            var attribute = new AutoRegisterAttribute(
                ServiceLifetime.Scoped,
                typeof(IService1)
                );

            Assert.ThrowsException<InvalidOperationException>(() =>
                AutoRegisterServiceCollectionExtensions.GetInterfaces(
                    typeof(ImplementsNoInterface).GetTypeInfo(),
                    attribute
                    )
                );

        }

        [TestMethod]
        public void GetInterfaces_WithoutInterface_ReturnsImplementationType() {

            var attribute = new AutoRegisterAttribute(
                ServiceLifetime.Scoped
                );

            var interfaces =
                AutoRegisterServiceCollectionExtensions.GetInterfaces(
                    typeof(ImplementsNoInterface).GetTypeInfo(),
                    attribute
                    );

            Assert.AreEqual(1, interfaces.Length);
            Assert.AreEqual(typeof(ImplementsNoInterface), interfaces.Single());

        }

        [TestMethod]
        public void GetInterfaces_WithType_ReturnsOnlyThatType() {

            var attribute = new AutoRegisterAttribute(
                ServiceLifetime.Scoped,
                typeof(IService2)
                );

            var interfaces =
                AutoRegisterServiceCollectionExtensions.GetInterfaces(
                    typeof(ImplementsService1And2).GetTypeInfo(),
                    attribute
                    );

            Assert.AreEqual(1, interfaces.Length);
            Assert.AreEqual(typeof(IService2), interfaces.Single());

        }

        [TestMethod]
        public void GetInterfaces_WithoutType_ReturnsAllInterfaces() {

            var attribute = new AutoRegisterAttribute(
                ServiceLifetime.Scoped
                );

            var interfaces =
                AutoRegisterServiceCollectionExtensions.GetInterfaces(
                    typeof(ImplementsService1And2).GetTypeInfo(),
                    attribute
                    );

            Assert.AreEqual(2, interfaces.Length);

        }

    }
}
