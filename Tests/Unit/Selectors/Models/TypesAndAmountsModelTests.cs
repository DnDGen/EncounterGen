using EncounterGen.Selectors.Models;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Selectors.Models
{
    [TestFixture]
    public class TypesAndAmountsModelTests
    {
        private TypesAndAmountsModel model;

        [SetUp]
        public void Setup()
        {
            model = new TypesAndAmountsModel();
        }

        [Test]
        public void TypeAndAMountModelInitialized()
        {
            Assert.That(model.TypesAndAmounts, Is.Empty);
        }
    }
}
