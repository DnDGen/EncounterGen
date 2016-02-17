using EncounterGen.Common;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.Dragons
{
    [TestFixture]
    public class Level7DragonsTests : PercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXDragons, 7);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(CreatureConstants.Dragon_White_YoungAdult, 1, 16)]
        [TestCase(CreatureConstants.Dragon_Black_YoungAdult, 17, 32)]
        [TestCase(CreatureConstants.Dragon_Green_Juvenile, 33, 48)]
        [TestCase(CreatureConstants.Dragon_Blue_Juvenile, 49, 64)]
        [TestCase(CreatureConstants.Dragon_Red_Juvenile, 65, 80)]
        [TestCase(CreatureConstants.Dragon_Brass_Juvenile, 81, 84)]
        [TestCase(CreatureConstants.Dragon_Copper_Juvenile, 85, 88)]
        [TestCase(CreatureConstants.Dragon_Bronze_Juvenile, 89, 92)]
        [TestCase(CreatureConstants.Dragon_Silver_Juvenile, 93, 96)]
        [TestCase(CreatureConstants.Dragon_Gold_Young, 97, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}
