using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Tables;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
{
    [TestFixture]
    public class GeneralCreatureGroupsTests : CreatureGroupsTableTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            AssertCreatureGroupEntriesAreComplete();
        }

        [TestCase("")]
        [TestCase(GroupConstants.RequiresSubcreature,
            CreatureDataConstants.Mephit_CR3,
            CreatureDataConstants.DominatedCreature_CR1,
            CreatureDataConstants.DominatedCreature_CR2,
            CreatureDataConstants.DominatedCreature_CR3,
            CreatureDataConstants.DominatedCreature_CR4,
            CreatureDataConstants.DominatedCreature_CR5,
            CreatureDataConstants.DominatedCreature_CR6,
            CreatureDataConstants.DominatedCreature_CR7,
            CreatureDataConstants.DominatedCreature_CR8,
            CreatureDataConstants.DominatedCreature_CR9,
            CreatureDataConstants.DominatedCreature_CR10,
            CreatureDataConstants.DominatedCreature_CR11,
            CreatureDataConstants.DominatedCreature_CR12,
            CreatureDataConstants.DominatedCreature_CR13,
            CreatureDataConstants.DominatedCreature_CR14,
            CreatureDataConstants.DominatedCreature_CR15,
            CreatureDataConstants.DominatedCreature_CR16)]
        [TestCase(GroupConstants.UseSubcreatureForTreasure,
            CreatureDataConstants.DominatedCreature_CR1,
            CreatureDataConstants.DominatedCreature_CR2,
            CreatureDataConstants.DominatedCreature_CR3,
            CreatureDataConstants.DominatedCreature_CR4,
            CreatureDataConstants.DominatedCreature_CR5,
            CreatureDataConstants.DominatedCreature_CR6,
            CreatureDataConstants.DominatedCreature_CR7,
            CreatureDataConstants.DominatedCreature_CR8,
            CreatureDataConstants.DominatedCreature_CR9,
            CreatureDataConstants.DominatedCreature_CR10,
            CreatureDataConstants.DominatedCreature_CR11,
            CreatureDataConstants.DominatedCreature_CR12,
            CreatureDataConstants.DominatedCreature_CR13,
            CreatureDataConstants.DominatedCreature_CR14,
            CreatureDataConstants.DominatedCreature_CR15,
            CreatureDataConstants.DominatedCreature_CR16)]
        public void CreatureGroup(string entry, params string[] items)
        {
            base.DistinctCollection(entry, items);
        }

        //INFO: This is a group of creatures that would not appear in a civilized environment
        [Test]
        public void WildernessCreatures()
        {
            var creatures = new[]
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
                //Animals
                CreatureDataConstants.Ape,
                CreatureDataConstants.Baboon,
                CreatureDataConstants.Badger,
                CreatureDataConstants.Bear,
                CreatureDataConstants.Bison,
                CreatureDataConstants.Boar,
                CreatureDataConstants.Cheetah,
                CreatureDataConstants.Crocodile,
                CreatureDataConstants.Deinonychus,
                CreatureDataConstants.Eagle,
                CreatureDataConstants.Elephant,
                CreatureDataConstants.Hyena,
                CreatureDataConstants.Leopard,
                CreatureDataConstants.Lion,
                CreatureDataConstants.Lizard_Monitor,
                CreatureDataConstants.Megaraptor,
                CreatureDataConstants.Monkey,
                CreatureDataConstants.Rhinoceras,
                CreatureDataConstants.Roc,
                CreatureDataConstants.Snake_Constrictor,
                CreatureDataConstants.Snake_Viper,
                CreatureDataConstants.Tiger,
                CreatureDataConstants.Triceratops,
                CreatureDataConstants.Tyrannosaurus,
                CreatureDataConstants.Weasel,
                CreatureDataConstants.Wolf,
                CreatureDataConstants.Wolverine,
                //Humanoids
                CreatureDataConstants.Bugbear,
                CreatureDataConstants.Gnoll,
                CreatureDataConstants.Goblin,
                CreatureDataConstants.Hobgoblin,
                CreatureDataConstants.Kobold,
                CreatureDataConstants.KuoToa,
                CreatureDataConstants.Lizardfolk,
                CreatureDataConstants.Orc,
                CreatureDataConstants.Troglodyte,
            };

            base.DistinctCollection(GroupConstants.Wilderness, creatures);
        }
    }
}
