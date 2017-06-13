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
        public void EncounterGeneratorIsDecorated()
        {
            AssertInstanceOf<IEncounterGenerator, EncounterGeneratorEventDecorator>();
        }

        [Test]
        public void CreatureGeneratorIsNotASingleton()
        {
            AssertNotSingleton<ICreatureGenerator>();
        }

        [Test]
        public void CreatureGeneratorIsDecorated()
        {
            AssertInstanceOf<ICreatureGenerator, CreatureGeneratorEventDecorator>();
        }

        [Test]
        public void EncounterCharacterGeneratorIsNotASingleton()
        {
            AssertNotSingleton<IEncounterCharacterGenerator>();
        }

        [Test]
        public void EncounterCharacterGeneratorIsDecorated()
        {
            AssertInstanceOf<IEncounterCharacterGenerator, EncounterCharacterGeneratorEventDecorator>();
        }

        [Test]
        public void EncounterTreasureGeneratorIsNotASingleton()
        {
            AssertNotSingleton<IEncounterTreasureGenerator>();
        }

        [Test]
        public void EncounterTreasureGeneratorIsDecorated()
        {
            AssertInstanceOf<IEncounterTreasureGenerator, EncounterTreasureGeneratorEventDecorator>();
        }

        [Test]
        public void EncounterVerifierIsNotASingleton()
        {
            AssertNotSingleton<IEncounterVerifier>();
        }
    }
}
