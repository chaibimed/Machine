using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineCafe.WebApi.Infrastructure;
using Moq;
using Ninject;
using Ninject.Extensions.ChildKernel;
using Ninject.Modules;
using Ninject.Parameters;
using NUnit.Framework;

namespace MachineCafe.UnitTests
{
    [TestFixture]
    public class NinjectResolverTests
    {
        [Test]
        public void GivenNoConfiguration_ShouldReturnsNull()
        {
            var depResolver = new NinjectResolver();
            //act & assert
            Assert.That(depResolver.GetService(typeof(IFakeService)), Is.Null);
        }

        [Test]
        public void GivenSingletonConfiguration_WhenResolveDepedency_ShouldReturnsTheRightType()
        {
            //arrange
            var depResolver = new NinjectResolver(new FakeNinjectModule());
            //act & assert
            Assert.That(depResolver.GetService(typeof(IFakeService)), Is.TypeOf<FakeService>());
        }

        [Test]
        public void GivenSingletonConfiguration_WhenWeResolveDependencies_ShouldTheSameInstance()
        {
            //arrange
            var depResolver = new NinjectResolver(new FakeNinjectModule());
            //act
            var instanceFirstCall = depResolver.GetService(typeof(IFakeService));
            var instanceSecondCall = depResolver.GetService(typeof(IFakeService));
            //assert
            Assert.That(instanceFirstCall, Is.EqualTo(instanceSecondCall));
        }

        [Test]
        public void CanResolve_RequestScopedDependency()
        {
            //arrange
            var depResolver = new NinjectResolver();
            depResolver.AddRequestScopedModules(new FakeNinjectModule());
            //assert
            Assert.That(depResolver.BeginScope().GetService(typeof(IFakeService)), Is.TypeOf<FakeService>());
        }

        [Test]
        public void GivenScopedConfiguration_WhenCallingBeginScope_EachTimeShouldReturnNewInstance()
        {
            //arrange
            var depResolver = new NinjectResolver();
            depResolver.AddRequestScopedModules(new FakeNinjectModule());

            //act
            var instance1 = depResolver.BeginScope().GetService(typeof(IFakeService));
            var instance2 = depResolver.BeginScope().GetService(typeof(IFakeService));
            
            Assert.That(instance1, Is.Not.EqualTo(instance2));
        }

        [Test]
        public void GivenSingletonConfiguration_WhenCallingBeginScope_EachTimeShouldReturnTheSame()
        {
            //arrange
            var depResolver = new NinjectResolver(new FakeNinjectModule());
            //act
            var instance1 = depResolver.BeginScope().GetService(typeof(IFakeService));
            var instance2 = depResolver.BeginScope().GetService(typeof(IFakeService));

            Assert.That(instance1, Is.EqualTo(instance2));
        }
    }


    /// <summary>
    /// Il s'agit juste des qq services pour tester ninject dependency resolver (IoC)
    /// </summary>
    public class FakeNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IFakeService>().To<FakeService>().InSingletonScope();
        }
    }

    public class FakeService : IFakeService{ }

    public interface IFakeService
    {
    }
}
