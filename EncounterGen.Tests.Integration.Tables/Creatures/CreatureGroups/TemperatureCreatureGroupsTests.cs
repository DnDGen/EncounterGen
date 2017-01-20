using EncounterGen.Common;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
{
    [TestFixture]
    public class TemperatureCreatureGroupsTests : CreatureGroupsTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            AssertCreatureGroupEntriesAreComplete();
        }

        [Test]
        public void ColdCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Giant_Frost,
                CreatureConstants.FrostWorm,
                CreatureConstants.Remorhaz,
                CreatureConstants.WinterWolf,
                CreatureConstants.Bear_Polar,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Cold, creatures);
        }

        [Test]
        public void WarmCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Bee_Giant,
                CreatureConstants.BombardierBeetle_Giant,
                CreatureConstants.Bulette,
                CreatureConstants.Centipede_Monstrous,
                CreatureConstants.Centipede_Swarm,
                CreatureConstants.Cockatrice,
                CreatureConstants.Digester,
                CreatureConstants.FireBeetle_Giant,
                CreatureConstants.Gnoll,
                CreatureConstants.Goblin,
                CreatureConstants.Gorgon,
                CreatureConstants.Harpy,
                CreatureConstants.Hobgoblin,
                CreatureConstants.Lammasu,
                CreatureConstants.Manticore,
                CreatureConstants.Naga,
                CreatureConstants.Scorpion_Monstrous,
                CreatureConstants.Snake_Viper,
                CreatureConstants.Spider_Monstrous,
                CreatureConstants.Spider_Swarm,
                CreatureConstants.SpiderEater,
                CreatureConstants.Wasp_Giant,
                CreatureConstants.YuanTi,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm, creatures);
        }

        [Test]
        public void TemperateCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Athach,
                CreatureConstants.Bee_Giant,
                CreatureConstants.BombardierBeetle_Giant,
                CreatureConstants.Bulette,
                CreatureConstants.Centipede_Monstrous,
                CreatureConstants.Cockatrice,
                CreatureConstants.Digester,
                CreatureConstants.FireBeetle_Giant,
                CreatureConstants.Gnoll,
                CreatureConstants.Goblin,
                CreatureConstants.Gorgon,
                CreatureConstants.Harpy,
                CreatureConstants.Hobgoblin,
                CreatureConstants.Lammasu,
                CreatureConstants.Manticore,
                CreatureConstants.Naga,
                CreatureConstants.Scorpion_Monstrous,
                CreatureConstants.Snake_Viper,
                CreatureConstants.Spider_Monstrous,
                CreatureConstants.SpiderEater,
                CreatureConstants.Wasp_Giant,
                CreatureConstants.YuanTi,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate, creatures);
        }
    }
}
