using EncounterGen.Domain.Generators;
using EncounterGen.Domain.Generators.Factories;
using EncounterGen.Domain.IoC.Providers;
using EncounterGen.Generators;
using Ninject.Modules;

namespace EncounterGen.Domain.IoC.Modules
{
    internal class GeneratorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEncounterGenerator>().To<EncounterGenerator>().WhenInjectedInto<EncounterGeneratorEventDecorator>();
            Bind<IEncounterGenerator>().To<EncounterGeneratorEventDecorator>();

            Bind<ICreatureGenerator>().To<CreatureGenerator>().WhenInjectedInto<CreatureGeneratorEventDecorator>();
            Bind<ICreatureGenerator>().To<CreatureGeneratorEventDecorator>();

            Bind<IEncounterCharacterGenerator>().To<EncounterCharacterGenerator>().WhenInjectedInto<EncounterCharacterGeneratorEventDecorator>();
            Bind<IEncounterCharacterGenerator>().To<EncounterCharacterGeneratorEventDecorator>();

            Bind<IEncounterTreasureGenerator>().To<EncounterTreasureGenerator>().WhenInjectedInto<EncounterTreasureGeneratorEventDecorator>();
            Bind<IEncounterTreasureGenerator>().To<EncounterTreasureGeneratorEventDecorator>();

            Bind<IEncounterVerifier>().To<EncounterVerifier>();

            Bind<JustInTimeFactory>().ToProvider<JustInTimeFactoryProvider>();
        }
    }
}
