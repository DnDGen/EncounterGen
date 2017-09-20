using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using Ninject.Modules;

namespace EncounterGen.Domain.IoC.Modules
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

            Bind<IEncounterCollectionSelector>().To<EncounterCollectionSelector>().WhenInjectedInto<EncounterCollectionSelectorEventDecorator>();
            Bind<IEncounterCollectionSelector>().To<EncounterCollectionSelectorEventDecorator>().WhenInjectedInto<EncounterCollectionSelectorCachingProxy>();
            Bind<IEncounterCollectionSelector>().To<EncounterCollectionSelectorCachingProxy>().InSingletonScope();
        }
    }
}
