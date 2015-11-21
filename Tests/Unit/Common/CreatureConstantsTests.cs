using EncounterGen.Common;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Unit.Common
{
    [TestFixture]
    public class CreatureConstantsTests
    {
        [TestCase(CreatureConstants.AstralDeva, "Astral deva (angel)")]
        [TestCase(CreatureConstants.Centipede_Monstrous_Medium, "Medium monstrous centipede")]
        [TestCase(CreatureConstants.Character, "Character")]
        [TestCase(CreatureConstants.Darkmantle, "Darkmantle")]
        [TestCase(CreatureConstants.Dragon_Black_VeryOld, "Very old black dragon")]
        [TestCase(CreatureConstants.DwarfWarrior, "Dwarf warrior")]
        [TestCase(CreatureConstants.ElfWarrior, "Elf warrior")]
        [TestCase(CreatureConstants.FireBeetle_Giant, "Giant fire beetle")]
        [TestCase(CreatureConstants.GoblinWarrior, "Goblin warrior")]
        [TestCase(CreatureConstants.KoboldWarrior, "Kobold warrior")]
        [TestCase(CreatureConstants.Krenshar, "Krenshar")]
        [TestCase(CreatureConstants.Lemure, "Lemure (devil)")]
        [TestCase(CreatureConstants.OrcWarrior, "Orc warrior")]
        [TestCase(CreatureConstants.Planetar, "Planetar (angel)")]
        [TestCase(CreatureConstants.Rat_Dire, "Dire rat")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Small, "Small monstrous scorpion")]
        [TestCase(CreatureConstants.Skeleton_HumanWarrior, "Human warrior skeleton")]
        [TestCase(CreatureConstants.Snake_Viper_Tiny, "Tiny viper snake")]
        [TestCase(CreatureConstants.Spider_Monstrous_Small, "Small monstrous spider")]
        [TestCase(CreatureConstants.Stirge, "Stirge")]
        [TestCase(CreatureConstants.Swarm_Spider, "Spider swarm")]
        [TestCase(CreatureConstants.Zombie_HumanCommoner, "Human commoner zombie")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
