using NUnit.Framework;

namespace EncounterGen.Tests.Integration.IoC
{
    [Bootstrap]
    public abstract class BootstrapTests : IntegrationTests
    {
        protected void AssertSingleton<T>()
        {
            var first = GetNewInstanceOf<T>();
            var second = GetNewInstanceOf<T>();
            Assert.That(first, Is.EqualTo(second));
        }

        protected void AssertNotSingleton<T>()
        {
            var first = GetNewInstanceOf<T>();
            var second = GetNewInstanceOf<T>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        protected void AssertInstanceOf<I, T>()
        {
            var instance = GetNewInstanceOf<I>();
            Assert.That(instance, Is.InstanceOf<T>());
        }
    }
}
