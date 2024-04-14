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
                CreatureConstants.Elf_Aquatic,
                CreatureConstants.Gnoll,
                CreatureConstants.Gnome,
                CreatureConstants.Goblin,
                CreatureConstants.Halfling,
                CreatureConstants.Hobgoblin,
                CreatureConstants.Kobold,
                CreatureConstants.KuoToa,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Locathah,
                CreatureConstants.Merfolk,
                CreatureConstants.Orc_Half,
                CreatureConstants.Tiefling,
                CreatureConstants.Troglodyte,
                //Monstrous Humanoids
                CreatureConstants.Centaur,
                CreatureConstants.Doppelganger,
                CreatureConstants.Gargoyle,
                CreatureConstants.Gargoyle_Kapoacinth,
                CreatureConstants.Grimlock,
                CreatureConstants.Hag,
                CreatureConstants.Harpy,
                CreatureConstants.Lycanthrope,
                CreatureConstants.Medusa,
                CreatureConstants.Minotaur,
                CreatureConstants.Sahuagin,
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
                CreatureConstants.Githyanki,
                CreatureConstants.Githzerai,
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
                CreatureConstants.Tojanida,
                CreatureConstants.Triton,
                CreatureConstants.Vargouille,
                CreatureConstants.Xill,
                CreatureConstants.Xorn,
                CreatureConstants.YethHound,
                //Undead
                CreatureConstants.Allip,
                CreatureConstants.Devourer,
                CreatureConstants.Ghost,
                CreatureConstants.Ghoul,
                CreatureConstants.Ghoul_Lacedon,
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
        public void BUG_SvirfneblinDoesNotAppearInDay()
        {
            var dayCreatures = ExplodeCollection(EnvironmentConstants.TimesOfDay.Day);
            var svirfneblinCreatures = ExplodeCollection(CreatureConstants.Svirfneblin);

            Assert.That(svirfneblinCreatures, Is.All.Not.Null);
            Assert.That(svirfneblinCreatures, Contains.Item(CreatureConstants.Svirfneblin_Captain));
            Assert.That(svirfneblinCreatures, Contains.Item(CreatureConstants.Svirfneblin_Leader));
            Assert.That(svirfneblinCreatures, Contains.Item(CreatureConstants.Svirfneblin_Lieutenant_3rd));
            Assert.That(svirfneblinCreatures, Contains.Item(CreatureConstants.Svirfneblin_Lieutenant_5th));
            Assert.That(svirfneblinCreatures, Contains.Item(CreatureConstants.Svirfneblin_Sergeant));
            Assert.That(svirfneblinCreatures, Contains.Item(CreatureConstants.Svirfneblin_Warrior));

            var svirfneblinInDay = dayCreatures.Intersect(svirfneblinCreatures);
            Assert.That(svirfneblinInDay, Is.Empty);
        }

        [TestCase(CreatureConstants.Svirfneblin_Captain)]
        [TestCase(CreatureConstants.Svirfneblin_Lieutenant_5th)]
        [TestCase(CreatureConstants.Svirfneblin_Leader)]
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
                CreatureConstants.Wraith,
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
