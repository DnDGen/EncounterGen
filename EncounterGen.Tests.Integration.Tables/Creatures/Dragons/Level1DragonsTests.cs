using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.Dragons
{
    [TestFixture]
    public class Level1DragonsTests : PercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXDragons, 1);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(CreatureConstants.Dragon_White_Wyrmling, 1, 16)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrmling, 17, 32)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrmling, 33, 48)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrmling, 49, 64)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrmling, 65, 80)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrmling, 81, 84)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrmling, 85, 88)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrmling, 89, 92)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrmling, 93, 96)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrmling, 97, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}
