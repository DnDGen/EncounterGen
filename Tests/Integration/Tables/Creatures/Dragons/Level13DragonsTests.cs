﻿using EncounterGen.Common;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.Dragons
{
    [TestFixture]
    public class Level13DragonsTests : PercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXDragons, 13);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(CreatureConstants.Dragon_White_Old, 1, 16)]
        [TestCase(CreatureConstants.Dragon_Black_Old, 17, 32)]
        [TestCase(CreatureConstants.Dragon_Green_MatureAdult, 33, 48)]
        [TestCase(CreatureConstants.Dragon_Blue_Adult, 49, 64)]
        [TestCase(CreatureConstants.Dragon_Red_Adult, 65, 80)]
        [TestCase(CreatureConstants.Dragon_Brass_MatureAdult, 81, 84)]
        [TestCase(CreatureConstants.Dragon_Copper_Adult, 85, 88)]
        [TestCase(CreatureConstants.Dragon_Bronze_Adult, 89, 92)]
        [TestCase(CreatureConstants.Dragon_Silver_Adult, 93, 96)]
        [TestCase(CreatureConstants.Dragon_Gold_YoungAdult, 97, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}
