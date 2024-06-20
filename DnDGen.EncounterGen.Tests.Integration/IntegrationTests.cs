using DnDGen.EncounterGen.IoC;
using Ninject;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Integration
{
    [TestFixture]
    public abstract class IntegrationTests
    {
        protected IKernel kernel;
        //We should be able to generate at least 2 characters per second, on average
        protected const double characterDivisor = 2;
        //A CR 1 encounter should only need a delta of 0.1 (min value)
        //A CR 10 encounter should only need a delta of 0.2
        //A CR 20 encounter should only need a delta of 0.4
        //A CR 30 encounter should only need a delta of 0.6
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
    }
}
