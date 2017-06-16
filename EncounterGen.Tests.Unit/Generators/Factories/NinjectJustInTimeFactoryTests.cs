using CharacterGen.Characters;
using EncounterGen.Domain.Generators.Factories;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Generators.Factories
{
    [TestFixture]
    public class NinjectJustInTimeFactoryTests
    {
        private JustInTimeFactory factory;
        private MoqMockingKernel mockKernel;

        [SetUp]
        public void Setup()
        {
            mockKernel = new MoqMockingKernel();
            factory = new NinjectJustInTimeFactory(mockKernel);
        }

        [Test]
        public void Build()
        {
            mockKernel.Bind<ICharacterGenerator>().ToMock().InSingletonScope();
            var mockGenerator = mockKernel.GetMock<ICharacterGenerator>();

            var generator = factory.Build<ICharacterGenerator>();
            Assert.That(generator, Is.Not.Null);
            Assert.That(generator, Is.EqualTo(mockGenerator.Object));
        }

        [Test]
        public void BuildWithName()
        {
            mockKernel.Bind<ICharacterGenerator>().ToMock().InSingletonScope().Named("name");
            var mockGenerator = mockKernel.GetMock<ICharacterGenerator>();

            var generator = factory.Build<ICharacterGenerator>("name");
            Assert.That(generator, Is.Not.Null);
            Assert.That(generator, Is.EqualTo(mockGenerator.Object));
        }
    }
}
