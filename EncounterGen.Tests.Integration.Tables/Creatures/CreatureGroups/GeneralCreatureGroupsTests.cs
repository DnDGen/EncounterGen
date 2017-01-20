using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
{
    [TestFixture]
    public class GeneralCreatureGroupsTests : CreatureGroupsTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            AssertCreatureGroupEntriesAreComplete();
        }

        [TestCase(GroupConstants.Magic,
            CreatureConstants.Types.Undead,
            CreatureConstants.Types.Outsider,
            CreatureConstants.Types.Construct,
            CreatureConstants.Types.Elemental)]
        [TestCase(GroupConstants.RequiresSubtype,
            CreatureConstants.Mephit_CR3,
            CreatureConstants.DominatedCreature_CR1,
            CreatureConstants.DominatedCreature_CR2,
            CreatureConstants.DominatedCreature_CR3,
            CreatureConstants.DominatedCreature_CR4,
            CreatureConstants.DominatedCreature_CR5,
            CreatureConstants.DominatedCreature_CR6,
            CreatureConstants.DominatedCreature_CR7,
            CreatureConstants.DominatedCreature_CR8,
            CreatureConstants.DominatedCreature_CR9,
            CreatureConstants.DominatedCreature_CR10,
            CreatureConstants.DominatedCreature_CR11,
            CreatureConstants.DominatedCreature_CR12,
            CreatureConstants.DominatedCreature_CR13,
            CreatureConstants.DominatedCreature_CR14,
            CreatureConstants.DominatedCreature_CR15,
            CreatureConstants.DominatedCreature_CR16)]
        [TestCase(GroupConstants.UseSubtypeForTreasure,
            CreatureConstants.DominatedCreature_CR1,
            CreatureConstants.DominatedCreature_CR2,
            CreatureConstants.DominatedCreature_CR3,
            CreatureConstants.DominatedCreature_CR4,
            CreatureConstants.DominatedCreature_CR5,
            CreatureConstants.DominatedCreature_CR6,
            CreatureConstants.DominatedCreature_CR7,
            CreatureConstants.DominatedCreature_CR8,
            CreatureConstants.DominatedCreature_CR9,
            CreatureConstants.DominatedCreature_CR10,
            CreatureConstants.DominatedCreature_CR11,
            CreatureConstants.DominatedCreature_CR12,
            CreatureConstants.DominatedCreature_CR13,
            CreatureConstants.DominatedCreature_CR14,
            CreatureConstants.DominatedCreature_CR15,
            CreatureConstants.DominatedCreature_CR16)]
        public void CreatureGroup(string entry, params string[] items)
        {
            base.DistinctCollection(entry, items);
        }

        [Test]
        public void LandCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Character_Adventurer,
                CreatureConstants.Character_Hunter,
                CreatureConstants.Commoner_Farmer,
                CreatureConstants.Commoner_Herder,
                CreatureConstants.Commoner_Pilgrim,
                CreatureConstants.Doppelganger,
                CreatureConstants.Gargoyle,
                CreatureConstants.NPC_Traveler,
                CreatureConstants.Rat,
                CreatureConstants.Tarrasque,
                CreatureConstants.Warrior_Bandit,
            };

            base.DistinctCollection(GroupConstants.Land, creatures);
        }

        //INFO: This is a group of creatures that would not appear in a civilized environment
        [Test]
        public void WildernessCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Types.Aberration,
                CreatureConstants.Types.Dragon,
                CreatureConstants.Types.Elemental,
                CreatureConstants.Types.Fey,
                CreatureConstants.Types.Giant,
                CreatureConstants.Types.MagicalBeast,
                CreatureConstants.Types.MonstrousHumanoid,
                CreatureConstants.Types.Ooze,
                CreatureConstants.Types.Outsider,
                CreatureConstants.Types.Plant,
                //Animals
                CreatureConstants.Ape,
                CreatureConstants.Baboon,
                CreatureConstants.Badger,
                CreatureConstants.Bear,
                CreatureConstants.Bison,
                CreatureConstants.Boar,
                CreatureConstants.Cheetah,
                CreatureConstants.Crocodile,
                CreatureConstants.Deinonychus,
                CreatureConstants.Eagle,
                CreatureConstants.Elephant,
                CreatureConstants.Hyena,
                CreatureConstants.Leopard,
                CreatureConstants.Lion,
                CreatureConstants.Lizard_Monitor,
                CreatureConstants.Megaraptor,
                CreatureConstants.Monkey,
                CreatureConstants.Rhinoceras,
                CreatureConstants.Roc,
                CreatureConstants.Snake_Constrictor,
                CreatureConstants.Snake_Viper,
                CreatureConstants.Tiger,
                CreatureConstants.Triceratops,
                CreatureConstants.Tyrannosaurus,
                CreatureConstants.Weasel,
                CreatureConstants.Wolf,
                CreatureConstants.Wolverine,
                //Humanoids
                CreatureConstants.Aasimar,
                CreatureConstants.Bugbear,
                CreatureConstants.Drow,
                CreatureConstants.Duergar,
                CreatureConstants.Dwarf,
                CreatureConstants.Elf,
                CreatureConstants.Gnoll,
                CreatureConstants.Gnome,
                CreatureConstants.Goblin,
                CreatureConstants.Halfling,
                CreatureConstants.Hobgoblin,
                CreatureConstants.Kobold,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Orc,
                CreatureConstants.Svirfneblin,
                CreatureConstants.Tiefling,
                CreatureConstants.Troglodyte,
            };

            base.DistinctCollection(GroupConstants.Wilderness, creatures);
        }
    }
}
