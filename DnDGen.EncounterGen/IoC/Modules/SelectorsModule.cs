using DnDGen.EncounterGen.Selectors;
using DnDGen.EncounterGen.Selectors.Collections;
using Ninject.Modules;

namespace DnDGen.EncounterGen.IoC.Modules
{
    internal class SelectorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITreasureRatesSelector>().To<TreasureRatesSelector>();
            Bind<IEncounterFormatter>().To<EncounterFormatter>();
            Bind<IEncounterLevelSelector>().To<EncounterLevelSelector>();
            Bind<IItemSelector>().To<ItemSelector>();
            Bind<IChallengeRatingSelector>().To<ChallengeRatingSelector>();

            Bind<IEncounterCollectionSelector>().To<EncounterCollectionSelector>().WhenInjectedInto<EncounterCollectionSelectorCachingProxy>();
            Bind<IEncounterCollectionSelector>().To<EncounterCollectionSelectorCachingProxy>().InSingletonScope();
        }
    }
}
