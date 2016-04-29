using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.Dragons
{
    [TestFixture]
    public class Level20DragonsTests : PercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXDragons, 20);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(CreatureConstants.Dragon_White_GreatWyrm, 1, 16)]
        [TestCase(CreatureConstants.Dragon_Black_GreatWyrm, 17, 32)]
        [TestCase(CreatureConstants.Dragon_Green_Ancient, 33, 48)]
        [TestCase(CreatureConstants.Dragon_Blue_Ancient, 49, 64)]
        [TestCase(CreatureConstants.Dragon_Red_VeryOld, 65, 80)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrm, 81, 84)]
        [TestCase(CreatureConstants.Dragon_Copper_Ancient, 85, 88)]
        [TestCase(CreatureConstants.Dragon_Bronze_Ancient, 89, 92)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryOld, 93, 96)]
        [TestCase(CreatureConstants.Dragon_Gold_Old, 97, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}
