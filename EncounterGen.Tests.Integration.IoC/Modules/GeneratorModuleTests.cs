using EncounterGen.Domain.Generators;
using EncounterGen.Generators;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.IoC.Modules
{
    [TestFixture]
    public class GeneratorModuleTests : IoCTests
    {
        [Test]
        public void EncounterGeneratorIsNotASingleton()
        {
            AssertNotSingleton<IEncounterGenerator>();
        }

        [Test]
        public void EncounterCharacterGeneratorIsNotASingleton()
        {
            AssertNotSingleton<IEncounterCharacterGenerator>();
        }

        [Test]
        public void EncounterTreasureGeneratorIsNotASingleton()
        {
            AssertNotSingleton<IEncounterTreasureGenerator>();
        }

        [Test]
        public void FilterVerifierIsNotASingleton()
        {
            AssertNotSingleton<IEncounterVerifier>();
        }
    }
}
