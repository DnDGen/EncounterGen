using DnDGen.EncounterGen.IoC;
using DnDGen.EncounterGen.Models;
using Ninject;
using NUnit.Framework;
using System;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration
{
    [TestFixture]
    public abstract class IntegrationTests
    {
        protected IKernel kernel;
        protected const double encounterLevelDivisor = 50;

        [OneTimeSetUp]
        public void IntegrationTestsFixtureSetup()
        {
            kernel = new StandardKernel(new NinjectSettings() { InjectNonPublic = true });

            var encounterGenLoader = new EncounterGenModuleLoader();
            encounterGenLoader.LoadModules(kernel);
        }

        [SetUp]
        public void IntegrationTestsSetup()
        {
            kernel.Inject(this);
        }

        protected T GetNewInstanceOf<T>()
        {
            return kernel.Get<T>();
        }

        protected double GetTimeLimitInSeconds(Encounter encounter)
        {
            //INFO: Since the limit in CharacterGen is 1 second per character, we will use that summation as our limit as well
            var limit = Math.Max(1, encounter.Characters.Count());

            //INFO: Higher-level encounters may take longer to generate (even for non-characters) due to increased treasure amounts
            var delta = Math.Max(0.1, encounter.ActualEncounterLevel / encounterLevelDivisor);

            return limit + delta;
        }
    }
}
