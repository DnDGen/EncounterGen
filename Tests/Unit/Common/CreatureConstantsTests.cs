using EncounterGen.Common;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Unit.Common
{
    [TestFixture]
    public class CreatureConstantsTests
    {
        [TestCase(CreatureConstants.Ant_Giant, "Giant ant")]
        [TestCase(CreatureConstants.AstralDeva, "Astral deva (angel)")]
        [TestCase(CreatureConstants.Balor, "Balor (demon)")]
        [TestCase(CreatureConstants.Centipede_Monstrous_Large, "Large monstrous centipede")]
        [TestCase(CreatureConstants.Centipede_Monstrous_Medium, "Medium monstrous centipede")]
        [TestCase(CreatureConstants.Character, "Character")]
        [TestCase(CreatureConstants.Choker, "Choker")]
        [TestCase(CreatureConstants.Darkmantle, "Darkmantle")]
        [TestCase(CreatureConstants.Dragon, "Dragon")]
        [TestCase(CreatureConstants.Dragon_Black_VeryOld, "Very old black dragon")]
        [TestCase(CreatureConstants.DwarfWarrior, "Dwarf warrior")]
        [TestCase(CreatureConstants.ElfWarrior, "Elf warrior")]
        [TestCase(CreatureConstants.EtherealMarauder, "Ethereal marauder")]
        [TestCase(CreatureConstants.FireBeetle_Giant, "Giant fire beetle")]
        [TestCase(CreatureConstants.FormianWorker, "Formian worker")]
        [TestCase(CreatureConstants.Gelugon, "Gelugon (devil)")]
        [TestCase(CreatureConstants.Ghoul, "Ghoul")]
        [TestCase(CreatureConstants.Glabrezu, "Glabrezu (demon)")]
        [TestCase(CreatureConstants.Goblin, "Goblin")]
        [TestCase(CreatureConstants.Hobgoblin, "Hobgoblin")]
        [TestCase(CreatureConstants.Kobold, "Kobold")]
        [TestCase(CreatureConstants.Krenshar, "Krenshar")]
        [TestCase(CreatureConstants.Lemure, "Lemure (devil)")]
        [TestCase(CreatureConstants.Lizardfolk, "Lizardfolk")]
        [TestCase(CreatureConstants.Nightwalker, "Nightwalker (nightshade)")]
        [TestCase(CreatureConstants.Orc, "Orc")]
        [TestCase(CreatureConstants.PitFiend, "Pit fiend (devil)")]
        [TestCase(CreatureConstants.Planetar, "Planetar (angel)")]
        [TestCase(CreatureConstants.Rat_Dire, "Dire rat")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Medium, "Medium monstrous scorpion")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Small, "Small monstrous scorpion")]
        [TestCase(CreatureConstants.Shrieker, "Shrieker")]
        [TestCase(CreatureConstants.Skeleton_HumanWarrior, "Human warrior skeleton")]
        [TestCase(CreatureConstants.Snake_Viper_Tiny, "Tiny viper snake")]
        [TestCase(CreatureConstants.Spider_Monstrous_Medium, "Medium monstrous spider")]
        [TestCase(CreatureConstants.Spider_Monstrous_Small, "Small monstrous spider")]
        [TestCase(CreatureConstants.Stirge, "Stirge")]
        [TestCase(CreatureConstants.Vampire, "Vampire")]
        [TestCase(CreatureConstants.Zombie_HumanCommoner, "Human commoner zombie")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
