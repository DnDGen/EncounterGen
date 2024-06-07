using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Tables;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
{
    [TestFixture]
    public class EncounterGroupsTests : EncounterGroupsTableTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            AssertEncounterGroupNamesAreComplete();
        }

        [Test]
        public void EmptyEncounterGroupIsEmpty()
        {
            AssertDistinctCollection(string.Empty);
        }

        [Test]
        public void AllGroupHasAllEncounters()
        {
            var allEncounters = EncounterConstants.GetAll().ToArray();
            AssertDistinctCollection(GroupConstants.All, allEncounters);
        }

        [Test]
        public void WildernessEncounterGroup()
        {
            var wildernessTypes = new[]
            {
                CreatureDataConstants.Types.Aberration,
                CreatureDataConstants.Types.Dragon,
                CreatureDataConstants.Types.Elemental,
                CreatureDataConstants.Types.Fey,
                CreatureDataConstants.Types.Giant,
                CreatureDataConstants.Types.MagicalBeast,
                CreatureDataConstants.Types.MonstrousHumanoid,
                CreatureDataConstants.Types.Ooze,
                CreatureDataConstants.Types.Outsider,
                CreatureDataConstants.Types.Plant,
            };

            var creaturesOfWildernessTypes = new List<string>();

            foreach(var creatureType in wildernessTypes)
            {
                var creaturesOfType = collectionSelector.Explode(TableNameConstants.CreatureGroups, creatureType);
                creaturesOfWildernessTypes.AddRange(creaturesOfType);
            }

            var encounters = EncounterConstants.GetAll();
            var wildernessEncounters = new List<string>();

            foreach (var encounter in encounters)
            {
                var encounterCreatures = GetCreaturesInEncounter(encounter);
                if (encounterCreatures.Intersect(creaturesOfWildernessTypes).Any())
                    wildernessEncounters.Add(encounter);
            }

            var creatureEncounters = new[]
            {
                //Animals
                EncounterConstants.Ape_Company,
                EncounterConstants.Ape_Dire_Company,
                EncounterConstants.Ape_Dire_Solitary,
                EncounterConstants.Ape_Pair,
                EncounterConstants.Ape_Solitary,
                EncounterConstants.Baboon_Solitary,
                EncounterConstants.Baboon_Troop,
                EncounterConstants.Badger_Cete,
                EncounterConstants.Badger_Dire_Cete,
                EncounterConstants.Badger_Dire_Solitary,
                EncounterConstants.Badger_Pair,
                EncounterConstants.Badger_Solitary,
                EncounterConstants.Bear_Black_Pair,
                EncounterConstants.Bear_Black_Solitary,
                EncounterConstants.Bear_Brown_Pair,
                EncounterConstants.Bear_Brown_Solitary,
                EncounterConstants.Bear_Dire_Pair,
                EncounterConstants.Bear_Dire_Solitary,
                EncounterConstants.Bear_Polar_Pair,
                EncounterConstants.Bear_Polar_Solitary,
                EncounterConstants.Bison_Herd,
                EncounterConstants.Bison_Solitary,
                EncounterConstants.Boar_Dire_Herd,
                EncounterConstants.Boar_Dire_Solitary,
                EncounterConstants.Boar_Herd,
                EncounterConstants.Boar_Solitary,
                EncounterConstants.Cheetah_Family,
                EncounterConstants.Cheetah_Pair,
                EncounterConstants.Cheetah_Solitary,
                EncounterConstants.Crocodile_Colony,
                EncounterConstants.Crocodile_Giant_Colony,
                EncounterConstants.Crocodile_Giant_Solitary,
                EncounterConstants.Crocodile_Solitary,
                EncounterConstants.Deinonychus_Pack,
                EncounterConstants.Deinonychus_Pair,
                EncounterConstants.Deinonychus_Solitary,
                EncounterConstants.Eagle_Giant_Eyrie,
                EncounterConstants.Eagle_Giant_Pair,
                EncounterConstants.Eagle_Giant_Solitary,
                EncounterConstants.Eagle_Pair,
                EncounterConstants.Eagle_Solitary,
                EncounterConstants.Elephant_Herd,
                EncounterConstants.Elephant_Solitary,
                EncounterConstants.Hyena_Pack,
                EncounterConstants.Hyena_Pair,
                EncounterConstants.Hyena_Solitary,
                EncounterConstants.Leopard_Pair,
                EncounterConstants.Leopard_Solitary,
                EncounterConstants.Lion_Dire_Pair,
                EncounterConstants.Lion_Dire_Pride,
                EncounterConstants.Lion_Dire_Solitary,
                EncounterConstants.Lion_Pair,
                EncounterConstants.Lion_Pride,
                EncounterConstants.Lion_Solitary,
                EncounterConstants.Lizard_Monitor_Solitary,
                EncounterConstants.Megaraptor_Pack,
                EncounterConstants.Megaraptor_Pair,
                EncounterConstants.Megaraptor_Solitary,
                EncounterConstants.Monkey_Troop,
                EncounterConstants.Rhinoceras_Herd,
                EncounterConstants.Rhinoceras_Solitary,
                EncounterConstants.Roc_Pair,
                EncounterConstants.Roc_Solitary,
                EncounterConstants.Snake_Constrictor_Giant_Solitary,
                EncounterConstants.Snake_Constrictor_Solitary,
                EncounterConstants.Snake_Viper_Huge_Solitary,
                EncounterConstants.Snake_Viper_Large_Solitary,
                EncounterConstants.Snake_Viper_Medium_Solitary,
                EncounterConstants.Snake_Viper_Small_Solitary,
                EncounterConstants.Snake_Viper_Tiny_Solitary,
                EncounterConstants.Tiger_Dire_Pair,
                EncounterConstants.Tiger_Dire_Solitary,
                EncounterConstants.Tiger_Solitary,
                EncounterConstants.Triceratops_Herd,
                EncounterConstants.Triceratops_Pair,
                EncounterConstants.Triceratops_Solitary,
                EncounterConstants.Tyrannosaurus_Pair,
                EncounterConstants.Tyrannosaurus_Solitary,
                EncounterConstants.Weasel_Dire_Pair,
                EncounterConstants.Weasel_Dire_Solitary,
                EncounterConstants.Weasel_Solitary,
                EncounterConstants.Wolf_Dire_Pack,
                EncounterConstants.Wolf_Dire_Pair,
                EncounterConstants.Wolf_Dire_Solitary,
                EncounterConstants.Wolf_Pack,
                EncounterConstants.Wolf_Pair,
                EncounterConstants.Wolf_Solitary,
                EncounterConstants.Wolverine_Dire_Pair,
                EncounterConstants.Wolverine_Dire_Solitary,
                EncounterConstants.Wolverine_Solitary,
                //Humanoids
                EncounterConstants.Bugbear_Gang,
                EncounterConstants.Bugbear_Solitary,
                EncounterConstants.Bugbear_Tribe,
                EncounterConstants.Gnoll_Band,
                EncounterConstants.Gnoll_HuntingParty,
                EncounterConstants.Gnoll_Pair,
                EncounterConstants.Gnoll_Solitary,
                EncounterConstants.Gnoll_Tribe,
                EncounterConstants.Gnoll_Tribe_WithTrolls,
                EncounterConstants.Goblin_Band,
                EncounterConstants.Goblin_Gang,
                EncounterConstants.Goblin_Tribe,
                EncounterConstants.Goblin_Warband,
                EncounterConstants.Hobgoblin_Band,
                EncounterConstants.Hobgoblin_Gang,
                EncounterConstants.Hobgoblin_Tribe_WithOgres,
                EncounterConstants.Hobgoblin_Tribe_WithTrolls,
                EncounterConstants.Hobgoblin_Warband,
                EncounterConstants.Kobold_Band,
                EncounterConstants.Kobold_Gang,
                EncounterConstants.Kobold_Tribe,
                EncounterConstants.Kobold_Warband,
                EncounterConstants.KuoToa_Band,
                EncounterConstants.KuoToa_Patrol,
                EncounterConstants.KuoToa_Squad,
                EncounterConstants.KuoToa_Tribe,
                EncounterConstants.Lizardfolk_Band,
                EncounterConstants.Lizardfolk_Gang,
                EncounterConstants.Lizardfolk_Tribe,
                EncounterConstants.Orc_Band,
                EncounterConstants.Orc_Gang,
                EncounterConstants.Orc_Squad,
                EncounterConstants.Troglodyte_Band,
                EncounterConstants.Troglodyte_Clutch,
                EncounterConstants.Troglodyte_Squad,
            };

            wildernessEncounters.AddRange(creatureEncounters);

            AssertDistinctCollection(GroupConstants.Wilderness, wildernessEncounters.Distinct().ToArray());
        }

        private IEnumerable<string> GetCreaturesInEncounter(string encounter)
        {
            var encounterCreatures = collectionSelector.SelectFrom(TableNameConstants.EncounterCreatures, encounter);
            var creatures = encounterFormatter.SelectCreaturesAndAmountsFrom(encounterCreatures).Keys;

            return creatures;
        }
    }
}
