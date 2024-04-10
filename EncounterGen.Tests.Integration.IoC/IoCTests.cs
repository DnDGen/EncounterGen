using NUnit.Framework;
using System.Diagnostics;

namespace DnDGen.EncounterGen.Tests.Integration.IoC
{
    [IoC]
    public abstract class IoCTests : IntegrationTests
    {
        protected Stopwatch stopwatch;

        [SetUp]
        public void Setup()
        {
            stopwatch = new Stopwatch();
        }

        [TearDown]
        public void IoCTeardown()
        {
            stopwatch.Reset();
        }

        protected void AssertSingleton<T>()
        {
            var first = InjectAndAssertDuration<T>();
            var second = InjectAndAssertDuration<T>();
            Assert.That(first, Is.Not.Null);
            Assert.That(second, Is.Not.Null);
            Assert.That(first, Is.EqualTo(second));
        }

        private T InjectAndAssertDuration<T>()
        {
            stopwatch.Restart();

            var instance = GetNewInstanceOf<T>();
            Assert.That(stopwatch.Elapsed.TotalMilliseconds, Is.LessThan(200));

            return instance;
        }

        protected void AssertNotSingleton<T>()
        {
            var first = InjectAndAssertDuration<T>();
            var second = InjectAndAssertDuration<T>();
            Assert.That(first, Is.Not.Null);
            Assert.That(second, Is.Not.Null);
            Assert.That(first, Is.Not.EqualTo(second));
        }

        protected void AssertInstanceOf<I, T>()
            where T : I
        {
            var instance = InjectAndAssertDuration<I>();
            Assert.That(instance, Is.Not.Null);
            Assert.That(instance, Is.InstanceOf<T>());
        }
    }
}
