using CharacterGen;
using CharacterGen.Randomizers.Alignments;
using CharacterGen.Randomizers.CharacterClasses;
using CharacterGen.Randomizers.Races;
using CharacterGen.Randomizers.Stats;
using EncounterGen.Domain.Generators;
using EncounterGen.Domain.Selectors.Collections;
using Ninject;
using Ninject.Activation;
using RollGen;

namespace EncounterGen.Domain.IoC.Providers
{
    class EncounterCharacterGeneratorProvider : Provider<IEncounterCharacterGenerator>
    {
        protected override IEncounterCharacterGenerator CreateInstance(IContext context)
        {
            var characterGenerator = context.Kernel.Get<ICharacterGenerator>();
            var alignmentRandomizer = context.Kernel.Get<IAlignmentRandomizer>(AlignmentRandomizerTypeConstants.Any);
            var anyPlayerclassNameRandomizer = context.Kernel.Get<IClassNameRandomizer>(ClassNameRandomizerTypeConstants.AnyPlayer);
            var anyNPCClassNameRandomizer = context.Kernel.Get<IClassNameRandomizer>(ClassNameRandomizerTypeConstants.AnyNPC);
            var setClassNameRandomizer = context.Kernel.Get<ISetClassNameRandomizer>();
            var setLevelRandomizer = context.Kernel.Get<ISetLevelRandomizer>();
            var baseRaceRandomizer = context.Kernel.Get<RaceRandomizer>(RaceRandomizerTypeConstants.BaseRace.AnyBase);
            var metaraceRandomizer = context.Kernel.Get<RaceRandomizer>(RaceRandomizerTypeConstants.Metarace.AnyMeta);
            var statsRandomizer = context.Kernel.Get<IStatsRandomizer>(StatsRandomizerTypeConstants.Raw);
            var collectionSelector = context.Kernel.Get<ICollectionSelector>();
            var setMetaraceRandomizer = context.Kernel.Get<ISetMetaraceRandomizer>();
            var dice = context.Kernel.Get<Dice>();

            return new EncounterCharacterGenerator(
                characterGenerator,
                alignmentRandomizer,
                anyPlayerclassNameRandomizer,
                setLevelRandomizer,
                baseRaceRandomizer,
                metaraceRandomizer,
                statsRandomizer,
                collectionSelector,
                setMetaraceRandomizer,
                anyNPCClassNameRandomizer,
                setClassNameRandomizer,
                dice);
        }
    }
}
