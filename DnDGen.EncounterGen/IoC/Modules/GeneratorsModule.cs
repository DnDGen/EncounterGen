using DnDGen.EncounterGen.Generators;
using Ninject.Modules;

namespace DnDGen.EncounterGen.IoC.Modules
{
    internal class GeneratorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEncounterGenerator>().To<EncounterGenerator>();
            Bind<ICreatureGenerator>().To<CreatureGenerator>();
            Bind<IEncounterCharacterGenerator>().To<EncounterCharacterGenerator>();
            Bind<IEncounterTreasureGenerator>().To<EncounterTreasureGenerator>();

            Bind<IEncounterVerifier>().To<EncounterVerifier>();
        }
    }
}
