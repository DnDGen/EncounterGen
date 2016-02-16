using EncounterGen.Common;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.Dragons
{
    [TestFixture]
    public class Level18DragonsTests : PercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXDragons, 18);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(CreatureConstants.Dragon_White_Wyrm, 1, 16)]
        [TestCase(CreatureConstants.Dragon_Black_Ancient, 17, 32)]
        [TestCase(CreatureConstants.Dragon_Green_VeryOld, 33, 48)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryOld, 49, 64)]
        [TestCase(CreatureConstants.Dragon_Red_Old, 65, 80)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryOld, 81, 84)]
        [TestCase(CreatureConstants.Dragon_Copper_Old, 85, 88)]
        [TestCase(CreatureConstants.Dragon_Bronze_Old, 89, 92)]
        [TestCase(CreatureConstants.Dragon_Silver_Old, 93, 96)]
        [TestCase(CreatureConstants.Dragon_Gold_MatureAdult, 97, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}
