using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DILib;

namespace DITester
{
    public interface IRegisterType
    {
    }

    abstract class AbstractType : IRegisterType
    {
    }

    public class ResolverType : IRegisterType
    {
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RegisterType()
        {
            DIContainer container = new DIContainer();
            container.Register<IRegisterType, ResolverType>();
            Assert.IsTrue(container.RegisterTypes.Count == 1);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldNotRegisteredAbstractType()
        {
            DIContainer container = new DIContainer();
            container.Register<IRegisterType, AbstractType>();
        }
    }
}
