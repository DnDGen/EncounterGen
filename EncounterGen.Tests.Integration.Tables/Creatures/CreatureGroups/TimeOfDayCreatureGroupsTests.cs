using EncounterGen.Common;
using NUnit.Framework;
using System.Linq;

namespace EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
{
    [TestFixture]
    public class TimeOfDayCreatureGroupsTests : CreatureGroupsTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            AssertCreatureGroupEntriesAreComplete();
        }

        [Test]
        public void DayCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Types.Aberration,
                CreatureConstants.Types.Animal,
                CreatureConstants.Types.Construct,
                CreatureConstants.Types.Dragon,
                CreatureConstants.Types.Elemental,
                CreatureConstants.Types.Fey,
                CreatureConstants.Types.Giant,
                CreatureConstants.Types.MagicalBeast,
                CreatureConstants.Types.Ooze,
                CreatureConstants.Types.Plant,
                CreatureConstants.Types.Vermin,
                //Humanoid
                CreatureConstants.Aasimar,
                CreatureConstants.Bugbear,
                CreatureConstants.Character,
                CreatureConstants.Dwarf,
                CreatureConstants.Elf,
                CreatureConstants.Gnoll,
                CreatureConstants.Gnome,
                CreatureConstants.Goblin,
                CreatureConstants.Halfling,
                CreatureConstants.Hobgoblin,
                CreatureConstants.Kobold,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Tiefling,
                CreatureConstants.Troglodyte,
                //Monstrous Humanoids
                CreatureConstants.Centaur,
                CreatureConstants.Doppelganger,
                CreatureConstants.Gargoyle,
                CreatureConstants.Grimlock,
                CreatureConstants.Hag,
                CreatureConstants.Harpy,
                CreatureConstants.Lycanthrope,
                CreatureConstants.Medusa,
                CreatureConstants.Minotaur,
                CreatureConstants.Scorpionfolk,
                CreatureConstants.YuanTi,
                //Outsider
                CreatureConstants.Achaierai,
                CreatureConstants.Angel,
                CreatureConstants.Archon,
                CreatureConstants.Arrowhawk,
                CreatureConstants.Avoral,
                CreatureConstants.Azer,
                CreatureConstants.Barghest,
                CreatureConstants.Basilisk_AbyssalGreater,
                CreatureConstants.Bralani,
                CreatureConstants.CelestialCreature,
                CreatureConstants.ChaosBeast,
                CreatureConstants.Couatl,
                CreatureConstants.Demon,
                CreatureConstants.Devil,
                CreatureConstants.FiendishCreature,
                CreatureConstants.Formian,
                CreatureConstants.Genie,
                CreatureConstants.Ghaele,
                CreatureConstants.HellHound,
                CreatureConstants.Hellwasp,
                CreatureConstants.Howler,
                CreatureConstants.Inevitable,
                CreatureConstants.Leonal,
                CreatureConstants.Lillend,
                CreatureConstants.Mephit,
                CreatureConstants.Mephit_CR3,
                CreatureConstants.NessianWarhound,
                CreatureConstants.Rakshasa,
                CreatureConstants.Rast,
                CreatureConstants.Ravid,
                CreatureConstants.Salamander,
                CreatureConstants.Slaad,
                CreatureConstants.Titan,
                CreatureConstants.Vargouille,
                CreatureConstants.Xill,
                CreatureConstants.Xorn,
                CreatureConstants.YethHound,
                //Undead
                CreatureConstants.Allip,
                CreatureConstants.Devourer,
                CreatureConstants.Ghast,
                CreatureConstants.Ghost,
                CreatureConstants.Ghoul,
                CreatureConstants.Lich,
                CreatureConstants.Mohrg,
                CreatureConstants.Mummy,
                CreatureConstants.Skeleton,
                CreatureConstants.Wight,
                CreatureConstants.Zombie,
            };

            DistinctCollection(EnvironmentConstants.TimesOfDay.Day, creatures);
        }

        [TestCase(CreatureConstants.Bodak)]
        [TestCase(CreatureConstants.Derro)]
        [TestCase(CreatureConstants.Drow)]
        [TestCase(CreatureConstants.Duergar)]
        [TestCase(CreatureConstants.NightHag)]
        [TestCase(CreatureConstants.Nightmare)]
        [TestCase(CreatureConstants.Nightshade)]
        [TestCase(CreatureConstants.Orc)]
        [TestCase(CreatureConstants.Shadow)]
        [TestCase(CreatureConstants.ShadowMastiff)]
        [TestCase(CreatureConstants.Spectre)]
        [TestCase(CreatureConstants.Svirfneblin)]
        [TestCase(CreatureConstants.Vampire)]
        [TestCase(CreatureConstants.VampireSpawn)]
        [TestCase(CreatureConstants.Wraith)]
        public void CreatureSensitiveToSunlightDoesNotAppearInDay(string creature)
        {
            var dayCreatures = ExplodeCollection(EnvironmentConstants.TimesOfDay.Day);
            var sensitiveToSunlight = ExplodeCollection(creature);

            var dayCreaturesSensitiveTosunlight = dayCreatures.Intersect(sensitiveToSunlight);
            Assert.That(dayCreaturesSensitiveTosunlight, Is.Empty);
        }

        [Test]
        public void CreaturesNotSensitiveToSunlightAppearInDay()
        {
            var sensitiveToSunlight = new[]
            {
                CreatureConstants.Bodak,
                CreatureConstants.Derro,
                CreatureConstants.Drow,
                CreatureConstants.Duergar,
                CreatureConstants.NightHag,
                CreatureConstants.Nightmare,
                CreatureConstants.Nightshade,
                CreatureConstants.Orc,
                CreatureConstants.Shadow,
                CreatureConstants.ShadowMastiff,
                CreatureConstants.Spectre,
                CreatureConstants.Svirfneblin,
                CreatureConstants.Vampire,
                CreatureConstants.VampireSpawn,
                CreatureConstants.Wraith,
            };

            sensitiveToSunlight = sensitiveToSunlight.SelectMany(c => ExplodeCollection(c)).ToArray();

            var allCreatures = GetAllCreaturesFromEncounters();
            allCreatures = allCreatures.Except(new[]
            {
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
                CreatureConstants.DominatedCreature_CR16,
            });

            var notSensitiveToSunlight = allCreatures.Except(sensitiveToSunlight);
            var dayCreatures = ExplodeCollection(EnvironmentConstants.TimesOfDay.Day);

            AssertWholeCollection(notSensitiveToSunlight, dayCreatures);
        }

        [Test]
        public void NightCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Types.Aberration,
                CreatureConstants.Types.Animal,
                CreatureConstants.Types.Construct,
                CreatureConstants.Types.Dragon,
                CreatureConstants.Types.Elemental,
                CreatureConstants.Types.Fey,
                CreatureConstants.Types.Giant,
                CreatureConstants.Types.Humanoid,
                CreatureConstants.Types.MagicalBeast,
                CreatureConstants.Types.MonstrousHumanoid,
                CreatureConstants.Types.Ooze,
                CreatureConstants.Types.Outsider,
                CreatureConstants.Types.Plant,
                CreatureConstants.Types.Undead,
                CreatureConstants.Types.Vermin,
            };

            DistinctCollection(EnvironmentConstants.TimesOfDay.Night, creatures);
        }
    }
}
