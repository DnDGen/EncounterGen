using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Tables;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
{
    [TestFixture]
    public class EncounterGroupsTests : EncounterGroupsTableTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            AssertEncounterGroupEntriesAreComplete();
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

            Assert.Fail("need to update");
            AssertDistinctCollection(GroupConstants.Wilderness, creatures);
        }
    }
}
