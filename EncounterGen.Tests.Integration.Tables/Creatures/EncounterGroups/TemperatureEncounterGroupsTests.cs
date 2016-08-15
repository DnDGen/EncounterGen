using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;
using System.Linq;

namespace EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
{
    [TestFixture]
    public class TemperatureEncounterGroupsTests : EncounterGroupsTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            var entries = new[]
            {
                string.Empty,
                EnvironmentConstants.Civilized,
                EnvironmentConstants.Desert,
                EnvironmentConstants.Dungeon,
                EnvironmentConstants.Forest,
                EnvironmentConstants.Hills,
                EnvironmentConstants.Marsh,
                EnvironmentConstants.Mountain,
                EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Cold,
                EnvironmentConstants.Temperatures.Temperate,
                EnvironmentConstants.Temperatures.Warm,
                EnvironmentConstants.TimesOfDay.Day,
                EnvironmentConstants.TimesOfDay.Night,
                GroupConstants.Magic,
                GroupConstants.Land,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Dungeon,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Dungeon,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Dungeon,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains,
            };

            var levels = Enumerable.Range(1, 24).Select(lvl => lvl.ToString());
            var allEntries = entries.Union(levels);

            AssertEntriesAreComplete(allEntries);
        }

        [Test]
        public void ColdEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Giant_Frost, RollConstants.One),
                FormatEncounter(CreatureConstants.Giant_Frost, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Giant_Frost, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Giant_Frost, RollConstants.OneD6Plus3,
                    CreatureConstants.WinterWolf, RollConstants.OneD3Plus1,
                    CreatureConstants.Ogre, RollConstants.OneD3),
                FormatEncounter(CreatureConstants.Giant_Frost, RollConstants.OneD4Plus10,
                    CreatureConstants.WinterWolf, RollConstants.OneD4Plus10,
                    CreatureConstants.Ogre, RollConstants.OneD4Plus10,
                    CreatureConstants.Dragon_White_Young, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Giant_Frost, RollConstants.OneD4Plus10,
                    CreatureConstants.WinterWolf, RollConstants.OneD4Plus10,
                    CreatureConstants.Ogre, RollConstants.OneD4Plus10,
                    CreatureConstants.Dragon_White_Young, RollConstants.OneD2,
                    CreatureConstants.Giant_Frost_Jarl, RollConstants.One),
                FormatEncounter(CreatureConstants.Giant_Frost_Jarl, RollConstants.One),
                FormatEncounter(CreatureConstants.FrostWorm, RollConstants.One),
                FormatEncounter(CreatureConstants.Remorhaz, RollConstants.One),
                FormatEncounter(CreatureConstants.WinterWolf, RollConstants.One),
                FormatEncounter(CreatureConstants.WinterWolf, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.WinterWolf, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Bear_Polar, RollConstants.One),
                FormatEncounter(CreatureConstants.Bear_Polar, RollConstants.OneD2),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Cold, encounters);
        }

        [Test]
        public void WarmEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Bee_Giant, RollConstants.One),
                FormatEncounter(CreatureConstants.Bee_Giant, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Bee_Giant, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.BombardierBeetle_Giant, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.BombardierBeetle_Giant, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Bulette, RollConstants.One),
                FormatEncounter(CreatureConstants.Bulette, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Colossal, RollConstants.One), //9
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Gargantuan, RollConstants.One), //6
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Huge, RollConstants.One), //2
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Huge, RollConstants.OneD3Plus1), //5
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Large, RollConstants.One), //1
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Large, RollConstants.OneD3Plus1), //3
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Medium, RollConstants.One), //1
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Medium, RollConstants.OneD3Plus1), //2
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Small, RollConstants.OneD3Plus1), //1
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Small, RollConstants.OneD6Plus5), //2
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Tiny, RollConstants.OneD4Plus10), //2
                FormatEncounter(CreatureConstants.Cockatrice, RollConstants.One),
                FormatEncounter(CreatureConstants.Cockatrice, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Cockatrice, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Cockatrice, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Digester, RollConstants.One),
                FormatEncounter(CreatureConstants.Digester, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.FireBeetle_Giant, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.FireBeetle_Giant, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Gnoll, RollConstants.One),
                FormatEncounter(CreatureConstants.Gnoll, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Gnoll, RollConstants.OneD3Plus1,
                    CreatureConstants.Dog_Hyena, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Goblin, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Goblin, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Goblin, RollConstants.OneD4Plus10,
                    CreatureConstants.Worg, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Goblin, RollConstants.OneD4Plus10,
                    CreatureConstants.Worg, RollConstants.OneD4Plus10,
                    CreatureConstants.Wolf_Dire, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Gorgon, RollConstants.One),
                FormatEncounter(CreatureConstants.Gorgon, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Gorgon, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Gorgon, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Harpy, RollConstants.One),
                FormatEncounter(CreatureConstants.Harpy, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Harpy, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Hobgoblin, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Hobgoblin, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Hobgoblin, RollConstants.OneD4Plus10,
                    CreatureConstants.Ogre, RollConstants.OneD3,
                    CreatureConstants.Wolf_Dire, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Hobgoblin, RollConstants.OneD4Plus10,
                    CreatureConstants.Troll, RollConstants.OneD3,
                    CreatureConstants.Wolf_Dire, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Lammasu, RollConstants.One),
                FormatEncounter(CreatureConstants.Lizard_Monitor, RollConstants.One),
                FormatEncounter(CreatureConstants.Manticore, RollConstants.One),
                FormatEncounter(CreatureConstants.Manticore, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Manticore, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Naga_Dark, RollConstants.One),
                FormatEncounter(CreatureConstants.Naga_Dark, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Naga_Guardian, RollConstants.One),
                FormatEncounter(CreatureConstants.Naga_Guardian, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Naga_Spirit, RollConstants.One),
                FormatEncounter(CreatureConstants.Naga_Spirit, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Colossal, RollConstants.One), //12
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Gargantuan, RollConstants.One), //10
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Huge, RollConstants.One), //7
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Huge, RollConstants.OneD3Plus1), //10
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Large, RollConstants.One), //3
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Large, RollConstants.OneD3Plus1), //6
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Medium, RollConstants.One), //1
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Medium, RollConstants.OneD3Plus1), //3
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Small, RollConstants.OneD3Plus1), //2
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Small, RollConstants.OneD6Plus5), //4
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Tiny, RollConstants.OneD4Plus10), //3
                FormatEncounter(CreatureConstants.Snake_Viper_Huge, RollConstants.One), //3
                FormatEncounter(CreatureConstants.Snake_Viper_Large, RollConstants.One), //2
                FormatEncounter(CreatureConstants.Snake_Viper_Medium, RollConstants.One), //1
                FormatEncounter(CreatureConstants.Snake_Viper_Small, RollConstants.One), //1
                FormatEncounter(CreatureConstants.Snake_Viper_Tiny, RollConstants.One), //1
                FormatEncounter(CreatureConstants.Spider_Monstrous_Colossal, RollConstants.One), //11
                FormatEncounter(CreatureConstants.Spider_Monstrous_Gargantuan, RollConstants.One), //8
                FormatEncounter(CreatureConstants.Spider_Monstrous_Huge, RollConstants.One), //5
                FormatEncounter(CreatureConstants.Spider_Monstrous_Huge, RollConstants.OneD3Plus1), //8
                FormatEncounter(CreatureConstants.Spider_Monstrous_Large, RollConstants.One), //2
                FormatEncounter(CreatureConstants.Spider_Monstrous_Large, RollConstants.OneD3Plus1), //5
                FormatEncounter(CreatureConstants.Spider_Monstrous_Medium, RollConstants.One), //1
                FormatEncounter(CreatureConstants.Spider_Monstrous_Medium, RollConstants.OneD3Plus1), //3
                FormatEncounter(CreatureConstants.Spider_Monstrous_Small, RollConstants.OneD3Plus1), //2
                FormatEncounter(CreatureConstants.Spider_Monstrous_Small, RollConstants.OneD6Plus5), //4
                FormatEncounter(CreatureConstants.Spider_Monstrous_Tiny, RollConstants.OneD4Plus10), //3
                FormatEncounter(CreatureConstants.SpiderEater, RollConstants.One),
                FormatEncounter(CreatureConstants.Wasp_Giant, RollConstants.One),
                FormatEncounter(CreatureConstants.Wasp_Giant, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Wasp_Giant, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.YuanTi_Halfblood, RollConstants.One),
                FormatEncounter(CreatureConstants.YuanTi_Halfblood, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.YuanTi_Halfblood, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.YuanTi_Pureblood, RollConstants.One),
                FormatEncounter(CreatureConstants.YuanTi_Pureblood, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.YuanTi_Pureblood, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.YuanTi_Abomination, RollConstants.One),
                FormatEncounter(CreatureConstants.YuanTi_Abomination, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.YuanTi_Abomination, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.YuanTi_Abomination, RollConstants.OneD3Plus1,
                    CreatureConstants.YuanTi_Halfblood, RollConstants.OneD4Plus2,
                    CreatureConstants.YuanTi_Pureblood, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.YuanTi_Abomination, RollConstants.OneD6Plus3,
                    CreatureConstants.YuanTi_Halfblood, RollConstants.OneD6Plus5,
                    CreatureConstants.YuanTi_Pureblood, RollConstants.OneD4Plus10),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm, encounters);
        }

        [Test]
        public void TemperateEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Athach, RollConstants.One),
                FormatEncounter(CreatureConstants.Athach, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Athach, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Bee_Giant, RollConstants.One),
                FormatEncounter(CreatureConstants.Bee_Giant, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Bee_Giant, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.BombardierBeetle_Giant, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.BombardierBeetle_Giant, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Bulette, RollConstants.One),
                FormatEncounter(CreatureConstants.Bulette, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Colossal, RollConstants.One), //9
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Gargantuan, RollConstants.One), //6
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Huge, RollConstants.One), //2
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Huge, RollConstants.OneD3Plus1), //5
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Large, RollConstants.One), //1
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Large, RollConstants.OneD3Plus1), //3
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Medium, RollConstants.One), //1
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Medium, RollConstants.OneD3Plus1), //2
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Small, RollConstants.OneD3Plus1), //1
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Small, RollConstants.OneD6Plus5), //2
                FormatEncounter(CreatureConstants.Centipede_Monstrous_Tiny, RollConstants.OneD4Plus10), //2
                FormatEncounter(CreatureConstants.Cockatrice, RollConstants.One),
                FormatEncounter(CreatureConstants.Cockatrice, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Cockatrice, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Cockatrice, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Digester, RollConstants.One),
                FormatEncounter(CreatureConstants.Digester, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.FireBeetle_Giant, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.FireBeetle_Giant, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Gnoll, RollConstants.One),
                FormatEncounter(CreatureConstants.Gnoll, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Gnoll, RollConstants.OneD3Plus1,
                    CreatureConstants.Dog_Hyena, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Goblin, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Goblin, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Goblin, RollConstants.OneD4Plus10,
                    CreatureConstants.Worg, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Goblin, RollConstants.OneD4Plus10,
                    CreatureConstants.Worg, RollConstants.OneD4Plus10,
                    CreatureConstants.Wolf_Dire, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Gorgon, RollConstants.One),
                FormatEncounter(CreatureConstants.Gorgon, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Gorgon, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Gorgon, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Harpy, RollConstants.One),
                FormatEncounter(CreatureConstants.Harpy, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Harpy, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Hobgoblin, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Hobgoblin, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Hobgoblin, RollConstants.OneD4Plus10,
                    CreatureConstants.Ogre, RollConstants.OneD3,
                    CreatureConstants.Wolf_Dire, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Hobgoblin, RollConstants.OneD4Plus10,
                    CreatureConstants.Troll, RollConstants.OneD3,
                    CreatureConstants.Wolf_Dire, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Lammasu, RollConstants.One),
                FormatEncounter(CreatureConstants.Manticore, RollConstants.One),
                FormatEncounter(CreatureConstants.Manticore, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Manticore, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Naga_Dark, RollConstants.One),
                FormatEncounter(CreatureConstants.Naga_Dark, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Naga_Guardian, RollConstants.One),
                FormatEncounter(CreatureConstants.Naga_Guardian, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Naga_Spirit, RollConstants.One),
                FormatEncounter(CreatureConstants.Naga_Spirit, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Colossal, RollConstants.One), //12
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Gargantuan, RollConstants.One), //10
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Huge, RollConstants.One), //7
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Huge, RollConstants.OneD3Plus1), //10
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Large, RollConstants.One), //3
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Large, RollConstants.OneD3Plus1), //6
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Medium, RollConstants.One), //1
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Medium, RollConstants.OneD3Plus1), //3
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Small, RollConstants.OneD3Plus1), //2
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Small, RollConstants.OneD6Plus5), //4
                FormatEncounter(CreatureConstants.Scorpion_Monstrous_Tiny, RollConstants.OneD4Plus10), //3
                FormatEncounter(CreatureConstants.Snake_Viper_Huge, RollConstants.One), //3
                FormatEncounter(CreatureConstants.Snake_Viper_Large, RollConstants.One), //2
                FormatEncounter(CreatureConstants.Snake_Viper_Medium, RollConstants.One), //1
                FormatEncounter(CreatureConstants.Snake_Viper_Small, RollConstants.One), //1
                FormatEncounter(CreatureConstants.Snake_Viper_Tiny, RollConstants.One), //1
                FormatEncounter(CreatureConstants.Spider_Monstrous_Colossal, RollConstants.One), //11
                FormatEncounter(CreatureConstants.Spider_Monstrous_Gargantuan, RollConstants.One), //8
                FormatEncounter(CreatureConstants.Spider_Monstrous_Huge, RollConstants.One), //5
                FormatEncounter(CreatureConstants.Spider_Monstrous_Huge, RollConstants.OneD3Plus1), //8
                FormatEncounter(CreatureConstants.Spider_Monstrous_Large, RollConstants.One), //2
                FormatEncounter(CreatureConstants.Spider_Monstrous_Large, RollConstants.OneD3Plus1), //5
                FormatEncounter(CreatureConstants.Spider_Monstrous_Medium, RollConstants.One), //1
                FormatEncounter(CreatureConstants.Spider_Monstrous_Medium, RollConstants.OneD3Plus1), //3
                FormatEncounter(CreatureConstants.Spider_Monstrous_Small, RollConstants.OneD3Plus1), //2
                FormatEncounter(CreatureConstants.Spider_Monstrous_Small, RollConstants.OneD6Plus5), //4
                FormatEncounter(CreatureConstants.Spider_Monstrous_Tiny, RollConstants.OneD4Plus10), //3
                FormatEncounter(CreatureConstants.SpiderEater, RollConstants.One),
                FormatEncounter(CreatureConstants.Wasp_Giant, RollConstants.One),
                FormatEncounter(CreatureConstants.Wasp_Giant, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Wasp_Giant, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.YuanTi_Halfblood, RollConstants.One),
                FormatEncounter(CreatureConstants.YuanTi_Halfblood, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.YuanTi_Halfblood, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.YuanTi_Pureblood, RollConstants.One),
                FormatEncounter(CreatureConstants.YuanTi_Pureblood, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.YuanTi_Pureblood, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.YuanTi_Abomination, RollConstants.One),
                FormatEncounter(CreatureConstants.YuanTi_Abomination, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.YuanTi_Abomination, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.YuanTi_Abomination, RollConstants.OneD3Plus1,
                    CreatureConstants.YuanTi_Halfblood, RollConstants.OneD4Plus2,
                    CreatureConstants.YuanTi_Pureblood, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.YuanTi_Abomination, RollConstants.OneD6Plus3,
                    CreatureConstants.YuanTi_Halfblood, RollConstants.OneD6Plus5,
                    CreatureConstants.YuanTi_Pureblood, RollConstants.OneD4Plus10),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate, encounters);
        }
    }
}
