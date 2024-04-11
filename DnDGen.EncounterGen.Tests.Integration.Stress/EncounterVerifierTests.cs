using DnDGen.EncounterGen.Generators;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Integration.Stress
{
    [TestFixture]
    public class EncounterVerifierTests : StressTests
    {
        private IEncounterVerifier encounterVerifier;

        [SetUp]
        public void Setup()
        {
            encounterVerifier = GetNewInstanceOf<IEncounterVerifier>();
        }

        [Test]
        public void StressEncounterVerification()
        {
            stressor.Stress(() => VerifyRandomEncounter(false));
        }

        [Test]
        public void StressEncounterVerificationWithFilter()
        {
            stressor.Stress(() => VerifyRandomEncounter(true));
        }

        private void VerifyRandomEncounter(bool withFilter)
        {
            var specifications = RandomizeSpecifications(useFilter: withFilter);
            var isValid = encounterVerifier.ValidEncounterExistsAtLevel(specifications);
            Assert.That(isValid, Is.True.Or.False);
        }
    }
}
