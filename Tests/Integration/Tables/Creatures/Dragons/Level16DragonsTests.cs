using EncounterGen.Common;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.Dragons
{
    [TestFixture]
    public class Level16DragonsTests : PercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXDragons, 16);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(CreatureConstants.Dragon_White_VeryOld, 1, 16)]
        [TestCase(CreatureConstants.Dragon_Black_VeryOld, 17, 32)]
        [TestCase(CreatureConstants.Dragon_Green_Old, 33, 48)]
        [TestCase(CreatureConstants.Dragon_Blue_Old, 49, 64)]
        [TestCase(CreatureConstants.Dragon_Red_MatureAdult, 65, 80)]
        [TestCase(CreatureConstants.Dragon_Brass_Old, 81, 84)]
        [TestCase(CreatureConstants.Dragon_Copper_Old, 85, 88)]
        [TestCase(CreatureConstants.Dragon_Bronze_MatureAdult, 89, 92)]
        [TestCase(CreatureConstants.Dragon_Silver_MatureAdult, 93, 96)]
        [TestCase(CreatureConstants.Dragon_Gold_MatureAdult, 97, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}
