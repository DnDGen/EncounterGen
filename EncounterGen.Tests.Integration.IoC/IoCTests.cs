using NUnit.Framework;

namespace EncounterGen.Tests.Integration.IoC
{
    [IoC]
    public abstract class IoCTests : IntegrationTests
    {
        protected void AssertSingleton<T>()
        {
            var first = GetNewInstanceOf<T>();
            var second = GetNewInstanceOf<T>();
            Assert.That(first, Is.Not.Null);
            Assert.That(second, Is.Not.Null);
            Assert.That(first, Is.EqualTo(second));
        }

        protected void AssertNotSingleton<T>()
        {
            var first = GetNewInstanceOf<T>();
            var second = GetNewInstanceOf<T>();
            Assert.That(first, Is.Not.Null);
            Assert.That(second, Is.Not.Null);
            Assert.That(first, Is.Not.EqualTo(second));
        }

        protected void AssertInstanceOf<I, T>()
            where T : I
        {
            var instance = GetNewInstanceOf<I>();
            Assert.That(instance, Is.Not.Null);
            Assert.That(instance, Is.InstanceOf<T>());
        }
    }
}
