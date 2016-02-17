using EncounterGen.Common;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.Dragons
{
    [TestFixture]
    public class Level3DragonsTests : PercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXDragons, 3);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(CreatureConstants.Dragon_White_Young, 1, 16)]
        [TestCase(CreatureConstants.Dragon_Black_VeryYoung, 17, 32)]
        [TestCase(CreatureConstants.Dragon_Green_VeryYoung, 33, 48)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryYoung, 49, 64)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrmling, 65, 80)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryYoung, 81, 84)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryYoung, 85, 88)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryYoung, 89, 92)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrmling, 93, 96)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrmling, 97, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}
