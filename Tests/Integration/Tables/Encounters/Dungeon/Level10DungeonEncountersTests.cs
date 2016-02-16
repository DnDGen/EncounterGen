using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level10DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 10, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, CreatureConstants.Bear_Dire, RollConstants.OneD3Plus1)]
        [TestCase(6, 15, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(16, 17, CreatureConstants.Aboleth, RollConstants.OneD3Plus1)]
        [TestCase(18, 19, CreatureConstants.Athach, RollConstants.OneD3Plus1)]
        [TestCase(20, 21, CreatureConstants.FormianMyrmarch, RollConstants.One)]
        [TestCase(22, 24, CreatureConstants.Medusa, RollConstants.OneD3Plus1)]
        [TestCase(25, 26, CreatureConstants.Naga_Water, RollConstants.OneD3Plus1)]
        [TestCase(27, 28, CreatureConstants.NightHag, RollConstants.One,
            CreatureConstants.Nightmare, RollConstants.One)]
        [TestCase(29, 30, CreatureConstants.Salamander_Noble, RollConstants.One,
            CreatureConstants.Salamander_Flamebrother, RollConstants.OneD3)]
        [TestCase(31, 32, CreatureConstants.YuanTi_Abomination, RollConstants.OneD3Plus1)]
        [TestCase(33, 37, CreatureConstants.Lillend, RollConstants.OneD3Plus1)]
        [TestCase(38, 47, CreatureConstants.Character + "[7]", RollConstants.OneD3Plus1)]
        [TestCase(48, 49, CreatureConstants.ChaosBeast, RollConstants.OneD3Plus1)]
        [TestCase(50, 51, CreatureConstants.Chimera, RollConstants.OneD3Plus1)]
        [TestCase(52, 53, CreatureConstants.Chuul, RollConstants.OneD3Plus1)]
        [TestCase(54, 54, CreatureConstants.Cryohydra + " (1d4+4 heads)", RollConstants.One)]
        [TestCase(55, 56, CreatureConstants.Dragonne, RollConstants.OneD3Plus1)]
        [TestCase(57, 58, CreatureConstants.Hellcat, RollConstants.OneD3Plus1)]
        [TestCase(59, 59, CreatureConstants.Hydra + " (1d3+9 heads)", RollConstants.One)]
        [TestCase(60, 60, CreatureConstants.Phasm, RollConstants.One)]
        [TestCase(61, 61, CreatureConstants.Pyrohydra + " (1d4+4 heads)", RollConstants.One)]
        [TestCase(62, 63, CreatureConstants.Retriever, RollConstants.One)]
        [TestCase(64, 65, CreatureConstants.Slaad_Red, RollConstants.OneD3Plus1)]
        [TestCase(66, 67, CreatureConstants.UmberHulk, RollConstants.OneD3Plus1)]
        [TestCase(68, 71, CreatureConstants.Barbazu, RollConstants.OneD3Plus1)]
        [TestCase(72, 75, CreatureConstants.Drider, RollConstants.OneD3Plus1)]
        [TestCase(76, 79, CreatureConstants.Giant_Frost, RollConstants.One,
            CreatureConstants.WinterWolf, RollConstants.OneD3)]
        [TestCase(80, 83, CreatureConstants.Giant_Stone, RollConstants.One,
            CreatureConstants.Bear_Dire, RollConstants.OneD2)]
        [TestCase(84, 87, CreatureConstants.Giant_Hill, RollConstants.OneD3Plus1)]
        [TestCase(88, 90, CreatureConstants.Hamatula, RollConstants.One,
            CreatureConstants.Barbazu, RollConstants.OneD2)]
        [TestCase(91, 100, CreatureConstants.Ghost + "[1d3+6]", RollConstants.One)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
