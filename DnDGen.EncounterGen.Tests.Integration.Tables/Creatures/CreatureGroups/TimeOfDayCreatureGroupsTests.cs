using DnDGen.EncounterGen.Models;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
{
    [TestFixture]
    public class TimeOfDayCreatureGroupsTests : CreatureGroupsTableTests
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
                CreatureDataConstants.Types.Aberration,
                CreatureDataConstants.Types.Animal,
                CreatureDataConstants.Types.Construct,
                CreatureDataConstants.Types.Dragon,
                CreatureDataConstants.Types.Elemental,
                CreatureDataConstants.Types.Fey,
                CreatureDataConstants.Types.Giant,
                CreatureDataConstants.Types.MagicalBeast,
                CreatureDataConstants.Types.Ooze,
                CreatureDataConstants.Types.Plant,
                CreatureDataConstants.Types.Vermin,
                //Humanoid
                CreatureDataConstants.Aasimar,
                CreatureDataConstants.Bugbear,
                CreatureDataConstants.Character,
                CreatureDataConstants.Dwarf,
                CreatureDataConstants.Elf,
                CreatureDataConstants.Elf_Aquatic,
                CreatureDataConstants.Gnoll,
                CreatureDataConstants.Gnome,
                CreatureDataConstants.Goblin,
                CreatureDataConstants.Halfling,
                CreatureDataConstants.Hobgoblin,
                CreatureDataConstants.Kobold,
                CreatureDataConstants.KuoToa,
                CreatureDataConstants.Lizardfolk,
                CreatureDataConstants.Locathah,
                CreatureDataConstants.Merfolk,
                CreatureDataConstants.Orc_Half,
                CreatureDataConstants.Tiefling,
                CreatureDataConstants.Troglodyte,
                //Monstrous Humanoids
                CreatureDataConstants.Centaur,
                CreatureDataConstants.Doppelganger,
                CreatureDataConstants.Gargoyle,
                CreatureDataConstants.Gargoyle_Kapoacinth,
                CreatureDataConstants.Grimlock,
                CreatureDataConstants.Hag,
                CreatureDataConstants.Harpy,
                CreatureDataConstants.Lycanthrope,
                CreatureDataConstants.Medusa,
                CreatureDataConstants.Minotaur,
                CreatureDataConstants.Sahuagin,
                CreatureDataConstants.Scorpionfolk,
                CreatureDataConstants.YuanTi,
                //Outsider
                CreatureDataConstants.Achaierai,
                CreatureDataConstants.Angel,
                CreatureDataConstants.Archon,
                CreatureDataConstants.Arrowhawk,
                CreatureDataConstants.Avoral,
                CreatureDataConstants.Azer,
                CreatureDataConstants.Barghest,
                CreatureDataConstants.Basilisk_AbyssalGreater,
                CreatureDataConstants.Bralani,
                CreatureDataConstants.CelestialCreature,
                CreatureDataConstants.ChaosBeast,
                CreatureDataConstants.Couatl,
                CreatureDataConstants.Demon,
                CreatureDataConstants.Devil,
                CreatureDataConstants.FiendishCreature,
                CreatureDataConstants.Formian,
                CreatureDataConstants.Genie,
                CreatureDataConstants.Ghaele,
                CreatureDataConstants.Githyanki,
                CreatureDataConstants.Githzerai,
                CreatureDataConstants.HellHound,
                CreatureDataConstants.Hellwasp,
                CreatureDataConstants.Howler,
                CreatureDataConstants.Inevitable,
                CreatureDataConstants.Leonal,
                CreatureDataConstants.Lillend,
                CreatureDataConstants.Mephit,
                CreatureDataConstants.Mephit_CR3,
                CreatureDataConstants.NessianWarhound,
                CreatureDataConstants.Rakshasa,
                CreatureDataConstants.Rast,
                CreatureDataConstants.Ravid,
                CreatureDataConstants.Salamander,
                CreatureDataConstants.Slaad,
                CreatureDataConstants.Titan,
                CreatureDataConstants.Tojanida,
                CreatureDataConstants.Triton,
                CreatureDataConstants.Vargouille,
                CreatureDataConstants.Xill,
                CreatureDataConstants.Xorn,
                CreatureDataConstants.YethHound,
                //Undead
                CreatureDataConstants.Allip,
                CreatureDataConstants.Devourer,
                CreatureDataConstants.Ghost,
                CreatureDataConstants.Ghoul,
                CreatureDataConstants.Ghoul_Lacedon,
                CreatureDataConstants.Lich,
                CreatureDataConstants.Mohrg,
                CreatureDataConstants.Mummy,
                CreatureDataConstants.Skeleton,
                CreatureDataConstants.Wight,
                CreatureDataConstants.Zombie,
            };

            DistinctCollection(EnvironmentConstants.TimesOfDay.Day, creatures);
        }

        [TestCase(CreatureDataConstants.Bodak)]
        [TestCase(CreatureDataConstants.Derro)]
        [TestCase(CreatureDataConstants.Drow)]
        [TestCase(CreatureDataConstants.Duergar)]
        [TestCase(CreatureDataConstants.NightHag)]
        [TestCase(CreatureDataConstants.Nightmare)]
        [TestCase(CreatureDataConstants.Nightshade)]
        [TestCase(CreatureDataConstants.Orc)]
        [TestCase(CreatureDataConstants.Shadow)]
        [TestCase(CreatureDataConstants.ShadowMastiff)]
        [TestCase(CreatureDataConstants.Spectre)]
        [TestCase(CreatureDataConstants.Svirfneblin)]
        [TestCase(CreatureDataConstants.Vampire)]
        [TestCase(CreatureDataConstants.VampireSpawn)]
        [TestCase(CreatureDataConstants.Wraith)]
        public void CreatureSensitiveToSunlightDoesNotAppearInDay(string creature)
        {
            var dayCreatures = ExplodeCollection(EnvironmentConstants.TimesOfDay.Day);
            var sensitiveToSunlight = ExplodeCollection(creature);

            var dayCreaturesSensitiveTosunlight = dayCreatures.Intersect(sensitiveToSunlight);
            Assert.That(dayCreaturesSensitiveTosunlight, Is.Empty);
        }

        [Test]
        public void BUG_SvirfneblinDoesNotAppearInDay()
        {
            var dayCreatures = ExplodeCollection(EnvironmentConstants.TimesOfDay.Day);
            var svirfneblinCreatures = ExplodeCollection(CreatureDataConstants.Svirfneblin);

            Assert.That(svirfneblinCreatures, Is.All.Not.Null);
            Assert.That(svirfneblinCreatures, Contains.Item(CreatureDataConstants.Svirfneblin_Captain));
            Assert.That(svirfneblinCreatures, Contains.Item(CreatureDataConstants.Svirfneblin_Leader));
            Assert.That(svirfneblinCreatures, Contains.Item(CreatureDataConstants.Svirfneblin_Lieutenant_3rd));
            Assert.That(svirfneblinCreatures, Contains.Item(CreatureDataConstants.Svirfneblin_Lieutenant_5th));
            Assert.That(svirfneblinCreatures, Contains.Item(CreatureDataConstants.Svirfneblin_Sergeant));
            Assert.That(svirfneblinCreatures, Contains.Item(CreatureDataConstants.Svirfneblin_Warrior));

            var svirfneblinInDay = dayCreatures.Intersect(svirfneblinCreatures);
            Assert.That(svirfneblinInDay, Is.Empty);
        }

        [TestCase(CreatureDataConstants.Svirfneblin_Captain)]
        [TestCase(CreatureDataConstants.Svirfneblin_Lieutenant_5th)]
        [TestCase(CreatureDataConstants.Svirfneblin_Leader)]
        public void BUG_IndividualCreatureSensitiveToSunlightDoesNotAppearInDay(string creature)
        {
            var dayCreatures = ExplodeCollection(EnvironmentConstants.TimesOfDay.Day);
            Assert.That(dayCreatures, Is.All.Not.EqualTo(creature));
        }

        [Test]
        public void BUG_AllCreaturesSensitiveToSunlightDoNotAppearInDay()
        {
            var sensitiveToSunlight = new[]
            {
                CreatureDataConstants.Bodak,
                CreatureDataConstants.Derro,
                CreatureDataConstants.Drow,
                CreatureDataConstants.Duergar,
                CreatureDataConstants.NightHag,
                CreatureDataConstants.Nightmare,
                CreatureDataConstants.Nightshade,
                CreatureDataConstants.Orc,
                CreatureDataConstants.Shadow,
                CreatureDataConstants.ShadowMastiff,
                CreatureDataConstants.Spectre,
                CreatureDataConstants.Svirfneblin,
                CreatureDataConstants.Vampire,
                CreatureDataConstants.VampireSpawn,
                CreatureDataConstants.Wraith,
            };

            var explodedSensitiveToSunlight = ExplodeCollections(sensitiveToSunlight);
            var dayCreatures = ExplodeCollection(EnvironmentConstants.TimesOfDay.Day);
            var dayCreaturesSensitiveToSunlight = dayCreatures.Intersect(explodedSensitiveToSunlight);

            Assert.That(dayCreaturesSensitiveToSunlight, Is.Empty);
        }

        [Test]
        public void CreaturesNotSensitiveToSunlightAppearInDay()
        {
            var sensitiveToSunlight = new[]
            {
                CreatureDataConstants.Bodak,
                CreatureDataConstants.Derro,
                CreatureDataConstants.Drow,
                CreatureDataConstants.Duergar,
                CreatureDataConstants.NightHag,
                CreatureDataConstants.Nightmare,
                CreatureDataConstants.Nightshade,
                CreatureDataConstants.Orc,
                CreatureDataConstants.Shadow,
                CreatureDataConstants.ShadowMastiff,
                CreatureDataConstants.Spectre,
                CreatureDataConstants.Svirfneblin,
                CreatureDataConstants.Vampire,
                CreatureDataConstants.Wraith,
            };

            var explodedSensitiveToSunlight = ExplodeCollections(sensitiveToSunlight);

            var allCreatures = GetAllCreatures();
            var notSensitiveToSunlight = allCreatures.Except(explodedSensitiveToSunlight);
            var dayCreatures = ExplodeCollection(EnvironmentConstants.TimesOfDay.Day);

            AssertWholeCollection(notSensitiveToSunlight, dayCreatures);
        }

        [Test]
        public void NightCreatures()
        {
            var creatures = new[]
            {
                CreatureDataConstants.Types.Aberration,
                CreatureDataConstants.Types.Animal,
                CreatureDataConstants.Types.Construct,
                CreatureDataConstants.Types.Dragon,
                CreatureDataConstants.Types.Elemental,
                CreatureDataConstants.Types.Fey,
                CreatureDataConstants.Types.Giant,
                CreatureDataConstants.Types.Humanoid,
                CreatureDataConstants.Types.MagicalBeast,
                CreatureDataConstants.Types.MonstrousHumanoid,
                CreatureDataConstants.Types.Ooze,
                CreatureDataConstants.Types.Outsider,
                CreatureDataConstants.Types.Plant,
                CreatureDataConstants.Types.Undead,
                CreatureDataConstants.Types.Vermin,
            };

            DistinctCollection(EnvironmentConstants.TimesOfDay.Night, creatures);
        }
    }
}
