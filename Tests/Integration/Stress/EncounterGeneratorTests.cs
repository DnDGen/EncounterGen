using EncounterGen.Generators;
using Ninject;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Stress
{
    [TestFixture]
    public class EncounterGeneratorTests : StressTests
    {
        [Inject]
        public IEncounterGenerator EncounterGenerator { get; set; }

        [TestCase("Encounter Generator")]
        public override void Stress(String stressSubject)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            throw new NotImplementedException();
        }
    }
}
