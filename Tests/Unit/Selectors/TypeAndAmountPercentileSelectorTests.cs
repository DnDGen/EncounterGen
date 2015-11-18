using EncounterGen.Selectors;
using EncounterGen.Selectors.Domain;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class TypeAndAmountPercentileSelectorTests
    {
        private ITypeAndAmountPercentileSelector selector;

        [SetUp]
        public void Setup()
        {
            selector = new TypeAndAmountPercentileSelector();
        }

        [Test]
        public void SelectTypeAndAmount()
        {
            var typeAndAmount = selector.SelectFrom("table name");
            Assert.That(typeAndAmount, Is.Not.Null);
        }
    }
}
