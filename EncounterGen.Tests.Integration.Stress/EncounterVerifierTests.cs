using EncounterGen.Generators;
using Ninject;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Stress
{
    [TestFixture]
    public class EncounterVerifierTests : StressTests
    {
        [Inject]
        public IEncounterVerifier EncounterVerifier { get; set; }

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
            var isValid = EncounterVerifier.ValidEncounterExistsAtLevel(specifications);
            Assert.That(isValid, Is.True.Or.False);
        }
    }
}
