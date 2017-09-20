using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.IoC.Modules
{
    [TestFixture]
    public class SelectorModuleTests : IoCTests
    {
        [Test]
        public void EncounterLevelSelectorIsNotASingleton()
        {
            AssertNotSingleton<IEncounterLevelSelector>();
        }

        [Test]
        public void TreasureAdjustmentSelectorIsNotASingleton()
        {
            AssertNotSingleton<ITreasureRatesSelector>();
        }

        [Test]
        public void EncounterCollectionSelectorIsASingleton()
        {
            AssertSingleton<IEncounterCollectionSelector>();
        }

        [Test]
        public void EncounterCollectionSelectorIsDecorated()
        {
            AssertInstanceOf<IEncounterCollectionSelector, EncounterCollectionSelectorCachingProxy>();
        }

        [Test]
        public void EncounterFormatterIsNotASingleton()
        {
            AssertNotSingleton<IEncounterFormatter>();
        }

        [Test]
        public void ItemSelectorIsNotASingleton()
        {
            AssertNotSingleton<IItemSelector>();
        }

        [Test]
        public void ChallengeRatingSelectorIsNotASingleton()
        {
            AssertNotSingleton<IChallengeRatingSelector>();
        }
    }
}
