using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
{
    [TestFixture]
    public class SpecificEncounterGroupsTests : EncounterGroupsTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            AssertEncounterGroupEntriesAreComplete();
        }

        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Dungeon)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Dungeon)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Dungeon)]
        public override void DistinctCollection(string entry, params string[] items)
        {
            base.DistinctCollection(entry, items);
        }

        [Test]
        public void TemperateMountainEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Bear_Black, RollConstants.One),
                FormatEncounter(CreatureConstants.Bear_Black, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Bugbear, RollConstants.One),
                FormatEncounter(CreatureConstants.Bugbear, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Bugbear, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.DisplacerBeast, RollConstants.One),
                FormatEncounter(CreatureConstants.DisplacerBeast, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.DisplacerBeast, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.One),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD2,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2,
                    CreatureConstants.Goblin, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2,
                    CreatureConstants.Orc, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Giant_Cloud, RollConstants.One),
                FormatEncounter(CreatureConstants.Giant_Cloud, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Giant_Cloud, RollConstants.OneD3Plus1,
                    CreatureConstants.Griffon, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Giant_Cloud, RollConstants.OneD3Plus1,
                    CreatureConstants.Lion_Dire, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Giant_Cloud, RollConstants.OneD6Plus5,
                    CreatureConstants.Griffon, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Giant_Cloud, RollConstants.OneD6Plus5,
                    CreatureConstants.Lion_Dire, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Giant_Storm, RollConstants.One),
                FormatEncounter(CreatureConstants.Giant_Storm, RollConstants.OneD3Plus1,
                    CreatureConstants.Roc, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Giant_Storm, RollConstants.OneD3Plus1,
                    CreatureConstants.Griffon, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Griffon, RollConstants.One),
                FormatEncounter(CreatureConstants.Griffon, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Griffon, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Roc, RollConstants.One),
                FormatEncounter(CreatureConstants.Roc, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Weasel, RollConstants.One),
                FormatEncounter(CreatureConstants.Weasel_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Weasel_Dire, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.One),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.OneD4Plus2),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain, encounters);
        }

        [Test]
        public void TemperateDesertEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Ant_Giant_Worker, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One,
                    CreatureConstants.Ant_Giant_Worker, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Bat, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Dragonne, RollConstants.One),
                FormatEncounter(CreatureConstants.Dragonne, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Dragonne, RollConstants.OneD6Plus5),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert, encounters);
        }

        [Test]
        public void TemperateForestEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Ankheg, RollConstants.One),
                FormatEncounter(CreatureConstants.Ankheg, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Ant_Giant_Worker, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One,
                    CreatureConstants.Ant_Giant_Worker, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Aranea, RollConstants.One),
                FormatEncounter(CreatureConstants.Aranea, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.AssassinVine, RollConstants.One),
                FormatEncounter(CreatureConstants.AssassinVine, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Badger, RollConstants.One),
                FormatEncounter(CreatureConstants.Badger, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Badger, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Badger_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Badger_Dire, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Bat, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Bear_Black, RollConstants.One),
                FormatEncounter(CreatureConstants.Bear_Black, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Boar, RollConstants.One),
                FormatEncounter(CreatureConstants.Boar, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Boar_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Boar_Dire, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Centaur, RollConstants.One),
                FormatEncounter(CreatureConstants.Centaur, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.DisplacerBeast, RollConstants.One),
                FormatEncounter(CreatureConstants.DisplacerBeast, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.DisplacerBeast, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Dryad, RollConstants.One),
                FormatEncounter(CreatureConstants.Dryad, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Ettercap, RollConstants.One),
                FormatEncounter(CreatureConstants.Ettercap, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Ettercap, RollConstants.OneD2,
                    CreatureConstants.Spider_Monstrous_Medium, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.GreenHag, RollConstants.One),
                FormatEncounter(CreatureConstants.GreenHag, RollConstants.OneD3Plus1,
                    CreatureConstants.Ogre, RollConstants.OneD4Plus2,
                    CreatureConstants.Giant_Hill, RollConstants.OneD3),
                FormatEncounter(CreatureConstants.GreenHag, RollConstants.OneD3,
                    CreatureConstants.Annis, RollConstants.One,
                    CreatureConstants.Ogre, RollConstants.OneD4Plus2,
                    CreatureConstants.Giant_Hill, RollConstants.OneD3),
                FormatEncounter(CreatureConstants.Annis, RollConstants.OneD3,
                    CreatureConstants.GreenHag, RollConstants.One,
                    CreatureConstants.Ogre, RollConstants.OneD4Plus2,
                    CreatureConstants.Giant_Hill, RollConstants.OneD3),
                FormatEncounter(CreatureConstants.Krenshar, RollConstants.One),
                FormatEncounter(CreatureConstants.Krenshar, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Krenshar, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Owlbear, RollConstants.One),
                FormatEncounter(CreatureConstants.Owlbear, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Owlbear, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Pegasus, RollConstants.One),
                FormatEncounter(CreatureConstants.Pegasus, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Pegasus, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.PrayingMantis_Giant, RollConstants.One),
                FormatEncounter(CreatureConstants.Pseudodragon, RollConstants.One),
                FormatEncounter(CreatureConstants.Pseudodragon, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Pseudodragon, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Satyr, RollConstants.One),
                FormatEncounter(CreatureConstants.Satyr, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Satyr, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Satyr, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.ShamblingMound, RollConstants.One),
                FormatEncounter(CreatureConstants.StagBeetle_Giant, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.StagBeetle_Giant, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Tendriculos, RollConstants.One),
                FormatEncounter(CreatureConstants.Unicorn, RollConstants.One),
                FormatEncounter(CreatureConstants.Unicorn, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Unicorn, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Weasel, RollConstants.One),
                FormatEncounter(CreatureConstants.Weasel_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Weasel_Dire, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wereboar, RollConstants.One),
                FormatEncounter(CreatureConstants.Wereboar, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wereboar, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Wereboar, RollConstants.OneD3Plus1,
                    CreatureConstants.Boar, RollConstants.OneD3),
                FormatEncounter(CreatureConstants.Wolverine, RollConstants.One),
                FormatEncounter(CreatureConstants.Wolverine_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Wolverine_Dire, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.One),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.OneD4Plus2),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, encounters);
        }

        [Test]
        public void TemperateMarshEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.GreenHag, RollConstants.One),
                FormatEncounter(CreatureConstants.GreenHag, RollConstants.OneD3Plus1,
                    CreatureConstants.Ogre, RollConstants.OneD4Plus2,
                    CreatureConstants.Giant_Hill, RollConstants.OneD3),
                FormatEncounter(CreatureConstants.GreenHag, RollConstants.OneD3,
                    CreatureConstants.Annis, RollConstants.One,
                    CreatureConstants.Ogre, RollConstants.OneD4Plus2,
                    CreatureConstants.Giant_Hill, RollConstants.OneD3),
                FormatEncounter(CreatureConstants.Annis, RollConstants.OneD3,
                    CreatureConstants.GreenHag, RollConstants.One,
                    CreatureConstants.Ogre, RollConstants.OneD4Plus2,
                    CreatureConstants.Giant_Hill, RollConstants.OneD3),
                FormatEncounter(CreatureConstants.Lizardfolk, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Lizardfolk, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Lizardfolk, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.PrayingMantis_Giant, RollConstants.One),
                FormatEncounter(CreatureConstants.ShamblingMound, RollConstants.One),
                FormatEncounter(CreatureConstants.Tendriculos, RollConstants.One),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh, encounters);
        }

        [Test]
        public void TemperatePlainsEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Ankheg, RollConstants.One),
                FormatEncounter(CreatureConstants.Ankheg, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Ant_Giant_Worker, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One,
                    CreatureConstants.Ant_Giant_Worker, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Badger, RollConstants.One),
                FormatEncounter(CreatureConstants.Badger, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Badger, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Badger_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Badger_Dire, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Bat, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.BlinkDog, RollConstants.One),
                FormatEncounter(CreatureConstants.BlinkDog, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.BlinkDog, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Hippogriff, RollConstants.One),
                FormatEncounter(CreatureConstants.Hippogriff, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Hippogriff, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Krenshar, RollConstants.One),
                FormatEncounter(CreatureConstants.Krenshar, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Krenshar, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.PrayingMantis_Giant, RollConstants.One),
                FormatEncounter(CreatureConstants.Weasel, RollConstants.One),
                FormatEncounter(CreatureConstants.Weasel_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Weasel_Dire, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wolverine, RollConstants.One),
                FormatEncounter(CreatureConstants.Wolverine_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Wolverine_Dire, RollConstants.OneD2),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains, encounters);
        }

        [Test]
        public void WarmPlainsEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Ankheg, RollConstants.One),
                FormatEncounter(CreatureConstants.Ankheg, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Ant_Giant_Worker, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One,
                    CreatureConstants.Ant_Giant_Worker, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Bat, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Cheetah, RollConstants.One),
                FormatEncounter(CreatureConstants.Cheetah, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Cheetah, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Deinonychus, RollConstants.One),
                FormatEncounter(CreatureConstants.Deinonychus, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Deinonychus, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Elephant, RollConstants.One),
                FormatEncounter(CreatureConstants.Hippogriff, RollConstants.One),
                FormatEncounter(CreatureConstants.Hippogriff, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Hippogriff, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Krenshar, RollConstants.One),
                FormatEncounter(CreatureConstants.Krenshar, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Krenshar, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Leopard, RollConstants.One),
                FormatEncounter(CreatureConstants.Leopard, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Megaraptor, RollConstants.One),
                FormatEncounter(CreatureConstants.Megaraptor, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Megaraptor, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.PrayingMantis_Giant, RollConstants.One),
                FormatEncounter(CreatureConstants.Rhinoceras, RollConstants.One),
                FormatEncounter(CreatureConstants.Rhinoceras, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Rhinoceras, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Triceratops, RollConstants.One),
                FormatEncounter(CreatureConstants.Triceratops, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Triceratops, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Tyrannosaurus, RollConstants.One),
                FormatEncounter(CreatureConstants.Tyrannosaurus, RollConstants.OneD2),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains, encounters);
        }

        [Test]
        public void WarmDesertEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Ant_Giant_Worker, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One,
                    CreatureConstants.Ant_Giant_Worker, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Baboon, RollConstants.One),
                FormatEncounter(CreatureConstants.Baboon, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Bat, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Camel, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Camel, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Criosphinx, RollConstants.One),
                FormatEncounter(CreatureConstants.Dragonne, RollConstants.One),
                FormatEncounter(CreatureConstants.Dragonne, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Dragonne, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Gynosphinx, RollConstants.One),
                FormatEncounter(CreatureConstants.Gynosphinx, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Hieracosphinx, RollConstants.One),
                FormatEncounter(CreatureConstants.Hieracosphinx, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Hieracosphinx, RollConstants.OneD4Plus2),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, encounters);
        }

        [Test]
        public void WarmForestEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Ant_Giant_Worker, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One,
                    CreatureConstants.Ant_Giant_Worker, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Ape, RollConstants.One),
                FormatEncounter(CreatureConstants.Ape, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Ape, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Ape_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Ape_Dire, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Aranea, RollConstants.One),
                FormatEncounter(CreatureConstants.Aranea, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.AssassinVine, RollConstants.One),
                FormatEncounter(CreatureConstants.AssassinVine, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Baboon, RollConstants.One),
                FormatEncounter(CreatureConstants.Baboon, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Bat, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Bear_Black, RollConstants.One),
                FormatEncounter(CreatureConstants.Bear_Black, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Boar, RollConstants.One),
                FormatEncounter(CreatureConstants.Boar, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Boar_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Boar_Dire, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Couatl, RollConstants.One),
                FormatEncounter(CreatureConstants.Couatl, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Couatl, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Criosphinx, RollConstants.One),
                FormatEncounter(CreatureConstants.Deinonychus, RollConstants.One),
                FormatEncounter(CreatureConstants.Deinonychus, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Deinonychus, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Dryad, RollConstants.One),
                FormatEncounter(CreatureConstants.Dryad, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Elephant, RollConstants.One),
                FormatEncounter(CreatureConstants.Ettercap, RollConstants.One),
                FormatEncounter(CreatureConstants.Ettercap, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Ettercap, RollConstants.OneD2,
                    CreatureConstants.Spider_Monstrous_Medium, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Girallon, RollConstants.One),
                FormatEncounter(CreatureConstants.Girallon, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.GreenHag, RollConstants.One),
                FormatEncounter(CreatureConstants.GreenHag, RollConstants.OneD3Plus1,
                    CreatureConstants.Ogre, RollConstants.OneD4Plus2,
                    CreatureConstants.Giant_Hill, RollConstants.OneD3),
                FormatEncounter(CreatureConstants.GreenHag, RollConstants.OneD3,
                    CreatureConstants.Annis, RollConstants.One,
                    CreatureConstants.Ogre, RollConstants.OneD4Plus2,
                    CreatureConstants.Giant_Hill, RollConstants.OneD3),
                FormatEncounter(CreatureConstants.Annis, RollConstants.OneD3,
                    CreatureConstants.GreenHag, RollConstants.One,
                    CreatureConstants.Ogre, RollConstants.OneD4Plus2,
                    CreatureConstants.Giant_Hill, RollConstants.OneD3),
                FormatEncounter(CreatureConstants.Krenshar, RollConstants.One),
                FormatEncounter(CreatureConstants.Krenshar, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Krenshar, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Leopard, RollConstants.One),
                FormatEncounter(CreatureConstants.Leopard, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Megaraptor, RollConstants.One),
                FormatEncounter(CreatureConstants.Megaraptor, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Megaraptor, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Pegasus, RollConstants.One),
                FormatEncounter(CreatureConstants.Pegasus, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Pegasus, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.PrayingMantis_Giant, RollConstants.One),
                FormatEncounter(CreatureConstants.Pseudodragon, RollConstants.One),
                FormatEncounter(CreatureConstants.Pseudodragon, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Pseudodragon, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Rakshasa, RollConstants.One),
                FormatEncounter(CreatureConstants.ShamblingMound, RollConstants.One),
                FormatEncounter(CreatureConstants.Snake_Constrictor, RollConstants.One),
                FormatEncounter(CreatureConstants.Snake_Constrictor_Giant, RollConstants.One),
                FormatEncounter(CreatureConstants.StagBeetle_Giant, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.StagBeetle_Giant, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Tendriculos, RollConstants.One),
                FormatEncounter(CreatureConstants.Wereboar, RollConstants.One),
                FormatEncounter(CreatureConstants.Wereboar, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wereboar, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Wereboar, RollConstants.OneD3Plus1,
                    CreatureConstants.Boar, RollConstants.OneD3),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.One),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.OneD4Plus2),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest, encounters);
        }

        [Test]
        public void WarmMarshEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Crocodile, RollConstants.One),
                FormatEncounter(CreatureConstants.Crocodile, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Crocodile_Giant, RollConstants.One),
                FormatEncounter(CreatureConstants.Crocodile_Giant, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Criosphinx, RollConstants.One),
                FormatEncounter(CreatureConstants.Deinonychus, RollConstants.One),
                FormatEncounter(CreatureConstants.Deinonychus, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Deinonychus, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.GreenHag, RollConstants.One),
                FormatEncounter(CreatureConstants.GreenHag, RollConstants.OneD3Plus1,
                    CreatureConstants.Ogre, RollConstants.OneD4Plus2,
                    CreatureConstants.Giant_Hill, RollConstants.OneD3),
                FormatEncounter(CreatureConstants.GreenHag, RollConstants.OneD3,
                    CreatureConstants.Annis, RollConstants.One,
                    CreatureConstants.Ogre, RollConstants.OneD4Plus2,
                    CreatureConstants.Giant_Hill, RollConstants.OneD3),
                FormatEncounter(CreatureConstants.Annis, RollConstants.OneD3,
                    CreatureConstants.GreenHag, RollConstants.One,
                    CreatureConstants.Ogre, RollConstants.OneD4Plus2,
                    CreatureConstants.Giant_Hill, RollConstants.OneD3),
                FormatEncounter(CreatureConstants.Lizardfolk, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Lizardfolk, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Lizardfolk, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Megaraptor, RollConstants.One),
                FormatEncounter(CreatureConstants.Megaraptor, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Megaraptor, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.PrayingMantis_Giant, RollConstants.One),
                FormatEncounter(CreatureConstants.Rakshasa, RollConstants.One),
                FormatEncounter(CreatureConstants.ShamblingMound, RollConstants.One),
                FormatEncounter(CreatureConstants.ShockerLizard, RollConstants.One),
                FormatEncounter(CreatureConstants.ShockerLizard, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.ShockerLizard, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.ShockerLizard, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Tendriculos, RollConstants.One),
                FormatEncounter(CreatureConstants.Tyrannosaurus, RollConstants.One),
                FormatEncounter(CreatureConstants.Tyrannosaurus, RollConstants.OneD2),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh, encounters);
        }

        [Test]
        public void ColdHillsEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Ettin, RollConstants.One),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD2,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2,
                    CreatureConstants.Goblin, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2,
                    CreatureConstants.Orc, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Wolverine, RollConstants.One),
                FormatEncounter(CreatureConstants.Wolverine_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Wolverine_Dire, RollConstants.OneD2),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, encounters);
        }

        [Test]
        public void TemperateHillsEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Ant_Giant_Worker, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One,
                    CreatureConstants.Ant_Giant_Worker, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Badger, RollConstants.One),
                FormatEncounter(CreatureConstants.Badger, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Badger, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Badger_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Badger_Dire, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Bat, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Bear_Black, RollConstants.One),
                FormatEncounter(CreatureConstants.Bear_Black, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.DisplacerBeast, RollConstants.One),
                FormatEncounter(CreatureConstants.DisplacerBeast, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.DisplacerBeast, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Dragonne, RollConstants.One),
                FormatEncounter(CreatureConstants.Dragonne, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Dragonne, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.One),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD2,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2,
                    CreatureConstants.Goblin, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2,
                    CreatureConstants.Orc, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Griffon, RollConstants.One),
                FormatEncounter(CreatureConstants.Griffon, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Griffon, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Hippogriff, RollConstants.One),
                FormatEncounter(CreatureConstants.Hippogriff, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Hippogriff, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.PrayingMantis_Giant, RollConstants.One),
                FormatEncounter(CreatureConstants.Tendriculos, RollConstants.One),
                FormatEncounter(CreatureConstants.Weasel, RollConstants.One),
                FormatEncounter(CreatureConstants.Weasel_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Weasel_Dire, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wolverine, RollConstants.One),
                FormatEncounter(CreatureConstants.Wolverine_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Wolverine_Dire, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.One),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.OneD4Plus2),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills, encounters);
        }

        [Test]
        public void WarmHillsEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Ant_Giant_Worker, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.One,
                    CreatureConstants.Ant_Giant_Worker, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Ant_Giant_Soldier, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Athach, RollConstants.One),
                FormatEncounter(CreatureConstants.Athach, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Athach, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Bat, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Bat_Dire, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Bear_Black, RollConstants.One),
                FormatEncounter(CreatureConstants.Bear_Black, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Deinonychus, RollConstants.One),
                FormatEncounter(CreatureConstants.Deinonychus, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Deinonychus, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Dragonne, RollConstants.One),
                FormatEncounter(CreatureConstants.Dragonne, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Dragonne, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Griffon, RollConstants.One),
                FormatEncounter(CreatureConstants.Griffon, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Griffon, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Hieracosphinx, RollConstants.One),
                FormatEncounter(CreatureConstants.Hieracosphinx, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Hieracosphinx, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Hippogriff, RollConstants.One),
                FormatEncounter(CreatureConstants.Hippogriff, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Hippogriff, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Megaraptor, RollConstants.One),
                FormatEncounter(CreatureConstants.Megaraptor, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Megaraptor, RollConstants.OneD4Plus2),
                FormatEncounter(CreatureConstants.Tendriculos, RollConstants.One),
                FormatEncounter(CreatureConstants.Triceratops, RollConstants.One),
                FormatEncounter(CreatureConstants.Triceratops, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Triceratops, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Tyrannosaurus, RollConstants.One),
                FormatEncounter(CreatureConstants.Tyrannosaurus, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.One),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.OneD4Plus2),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills, encounters);
        }

        [Test]
        public void ColdMountainEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Ettin, RollConstants.One),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD2,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2,
                    CreatureConstants.Goblin, RollConstants.OneD4Plus10),
                FormatEncounter(CreatureConstants.Ettin, RollConstants.OneD3Plus1,
                    CreatureConstants.Bear_Brown, RollConstants.OneD2,
                    CreatureConstants.Orc, RollConstants.OneD6Plus5),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain, encounters);
        }

        [Test]
        public void WarmMountainEncounters()
        {
            var encounters = new[]
            {
                FormatEncounter(CreatureConstants.Ape, RollConstants.One),
                FormatEncounter(CreatureConstants.Ape, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Ape, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Ape_Dire, RollConstants.One),
                FormatEncounter(CreatureConstants.Ape_Dire, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Athach, RollConstants.One),
                FormatEncounter(CreatureConstants.Athach, RollConstants.OneD3Plus1),
                FormatEncounter(CreatureConstants.Athach, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Bear_Black, RollConstants.One),
                FormatEncounter(CreatureConstants.Bear_Black, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Girallon, RollConstants.One),
                FormatEncounter(CreatureConstants.Girallon, RollConstants.OneD6Plus3),
                FormatEncounter(CreatureConstants.Griffon, RollConstants.One),
                FormatEncounter(CreatureConstants.Griffon, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Griffon, RollConstants.OneD6Plus5),
                FormatEncounter(CreatureConstants.Roc, RollConstants.One),
                FormatEncounter(CreatureConstants.Roc, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.One),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.OneD2),
                FormatEncounter(CreatureConstants.Wyvern, RollConstants.OneD4Plus2),
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain, encounters);
        }
    }
}
