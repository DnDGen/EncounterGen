using EncounterGen.Common;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.Dragons
{
    [TestFixture]
    public class Level4DragonsTests : PercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXDragons, 4);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(CreatureConstants.Dragon_White_Juvenile, 1, 16)]
        [TestCase(CreatureConstants.Dragon_Black_Young, 17, 32)]
        [TestCase(CreatureConstants.Dragon_Green_Young, 33, 48)]
        [TestCase(CreatureConstants.Dragon_Blue_Young, 49, 64)]
        [TestCase(CreatureConstants.Dragon_Red_VeryYoung, 65, 80)]
        [TestCase(CreatureConstants.Dragon_Brass_Young, 81, 84)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryYoung, 85, 88)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryYoung, 89, 92)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryYoung, 93, 96)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrmling, 97, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}
