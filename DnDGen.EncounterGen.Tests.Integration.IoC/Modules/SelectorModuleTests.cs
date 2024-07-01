using DnDGen.EncounterGen.Selectors;
using DnDGen.EncounterGen.Selectors.Collections;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Integration.IoC.Modules
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
        public void EncounterCollectionSelectorIsNotASingleton()
        {
            AssertNotSingleton<IEncounterCollectionSelector>();
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
