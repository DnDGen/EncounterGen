using CharacterGen.Characters;
using CharacterGen.Randomizers.Alignments;
using CharacterGen.Randomizers.CharacterClasses;
using CharacterGen.Randomizers.Races;
using CharacterGen.Randomizers.Stats;
using EncounterGen.Domain.Generators;
using EncounterGen.Domain.Selectors;
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
            var anyAlignmentRandomizer = context.Kernel.Get<IAlignmentRandomizer>(AlignmentRandomizerTypeConstants.Any);
            var anyPlayerclassNameRandomizer = context.Kernel.Get<IClassNameRandomizer>(ClassNameRandomizerTypeConstants.AnyPlayer);
            var anyNPCClassNameRandomizer = context.Kernel.Get<IClassNameRandomizer>(ClassNameRandomizerTypeConstants.AnyNPC);
            var setClassNameRandomizer = context.Kernel.Get<ISetClassNameRandomizer>();
            var setLevelRandomizer = context.Kernel.Get<ISetLevelRandomizer>();
            var anyBaseRaceRandomizer = context.Kernel.Get<RaceRandomizer>(RaceRandomizerTypeConstants.BaseRace.AnyBase);
            var anyMetaraceRandomizer = context.Kernel.Get<RaceRandomizer>(RaceRandomizerTypeConstants.Metarace.AnyMeta);
            var rawStatsRandomizer = context.Kernel.Get<IStatsRandomizer>(StatsRandomizerTypeConstants.Raw);
            var collectionSelector = context.Kernel.Get<ICollectionSelector>();
            var setMetaraceRandomizer = context.Kernel.Get<ISetMetaraceRandomizer>();
            var dice = context.Kernel.Get<Dice>();
            var encounterSelector = context.Kernel.Get<IEncounterSelector>();
            var setBaseRaceRandomizer = context.Kernel.Get<ISetBaseRaceRandomizer>();

            return new EncounterCharacterGenerator(
                characterGenerator,
                anyAlignmentRandomizer,
                anyPlayerclassNameRandomizer,
                setLevelRandomizer,
                anyBaseRaceRandomizer,
                anyMetaraceRandomizer,
                rawStatsRandomizer,
                collectionSelector,
                setMetaraceRandomizer,
                anyNPCClassNameRandomizer,
                setClassNameRandomizer,
                dice,
                encounterSelector,
                setBaseRaceRandomizer);
        }
    }
}
