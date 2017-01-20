using EncounterGen.Domain.Selectors;
using NUnit.Framework;
using System;
using System.Linq;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class AmountConstantsTests
    {
        [TestCase(AmountConstants.Range0To1, 0, 1)]
        [TestCase(AmountConstants.Range0To2, 0, 2)]
        [TestCase(AmountConstants.Range0To4, 0, 4)]
        [TestCase(AmountConstants.Range0To5, 0, 5)]
        [TestCase(AmountConstants.Range1, 1, 1)]
        [TestCase(AmountConstants.Range1To2, 1, 2)]
        [TestCase(AmountConstants.Range1To3, 1, 3)]
        [TestCase(AmountConstants.Range1To4, 1, 4)]
        [TestCase(AmountConstants.Range1To5, 1, 5)]
        [TestCase(AmountConstants.Range1To6, 1, 6)]
        [TestCase(AmountConstants.Range1To8, 1, 8)]
        [TestCase(AmountConstants.Range1To10, 1, 10)]
        [TestCase(AmountConstants.Range2, 2, 2)]
        [TestCase(AmountConstants.Range2To3, 2, 3)]
        [TestCase(AmountConstants.Range2To4, 2, 4)]
        [TestCase(AmountConstants.Range2To5, 2, 5)]
        [TestCase(AmountConstants.Range2To6, 2, 6)]
        [TestCase(AmountConstants.Range2To7, 2, 7)]
        [TestCase(AmountConstants.Range2To8, 2, 8)]
        [TestCase(AmountConstants.Range2To12, 2, 12)]
        [TestCase(AmountConstants.Range2To15, 2, 15)]
        [TestCase(AmountConstants.Range2To13, 2, 13)]
        [TestCase(AmountConstants.Range2To20, 2, 20)]
        [TestCase(AmountConstants.Range3, 3, 3)]
        [TestCase(AmountConstants.Range3To4, 3, 4)]
        [TestCase(AmountConstants.Range3To5, 3, 5)]
        [TestCase(AmountConstants.Range3To6, 3, 6)]
        [TestCase(AmountConstants.Range3To8, 3, 8)]
        [TestCase(AmountConstants.Range3To9, 3, 9)]
        [TestCase(AmountConstants.Range3To10, 3, 10)]
        [TestCase(AmountConstants.Range3To13, 3, 13)]
        [TestCase(AmountConstants.Range4, 4, 4)]
        [TestCase(AmountConstants.Range4To5, 4, 5)]
        [TestCase(AmountConstants.Range4To6, 4, 6)]
        [TestCase(AmountConstants.Range4To7, 4, 7)]
        [TestCase(AmountConstants.Range4To9, 4, 9)]
        [TestCase(AmountConstants.Range4To10, 4, 10)]
        [TestCase(AmountConstants.Range4To16, 4, 16)]
        [TestCase(AmountConstants.Range4To32, 4, 32)]
        [TestCase(AmountConstants.Range5, 5, 5)]
        [TestCase(AmountConstants.Range5To8, 5, 8)]
        [TestCase(AmountConstants.Range5To9, 5, 9)]
        [TestCase(AmountConstants.Range5To10, 5, 10)]
        [TestCase(AmountConstants.Range5To12, 5, 12)]
        [TestCase(AmountConstants.Range5To13, 5, 13)]
        [TestCase(AmountConstants.Range5To14, 5, 14)]
        [TestCase(AmountConstants.Range5To16, 5, 16)]
        [TestCase(AmountConstants.Range5To20, 5, 20)]
        [TestCase(AmountConstants.Range5To30, 5, 30)]
        [TestCase(AmountConstants.Range5To50, 5, 50)]
        [TestCase(AmountConstants.Range6, 6, 6)]
        [TestCase(AmountConstants.Range6To7, 6, 7)]
        [TestCase(AmountConstants.Range6To8, 6, 8)]
        [TestCase(AmountConstants.Range6To9, 6, 9)]
        [TestCase(AmountConstants.Range6To10, 6, 10)]
        [TestCase(AmountConstants.Range6To11, 6, 11)]
        [TestCase(AmountConstants.Range6To13, 6, 13)]
        [TestCase(AmountConstants.Range6To15, 6, 15)]
        [TestCase(AmountConstants.Range6To20, 6, 20)]
        [TestCase(AmountConstants.Range6To30, 6, 30)]
        [TestCase(AmountConstants.Range6To45, 6, 45)]
        [TestCase(AmountConstants.Range7, 7, 7)]
        [TestCase(AmountConstants.Range7To10, 7, 10)]
        [TestCase(AmountConstants.Range7To11, 7, 11)]
        [TestCase(AmountConstants.Range7To12, 7, 12)]
        [TestCase(AmountConstants.Range7To16, 7, 16)]
        [TestCase(AmountConstants.Range7To18, 7, 18)]
        [TestCase(AmountConstants.Range8, 8, 8)]
        [TestCase(AmountConstants.Range8To9, 8, 9)]
        [TestCase(AmountConstants.Range8To18, 8, 18)]
        [TestCase(AmountConstants.Range8To16, 8, 16)]
        [TestCase(AmountConstants.Range9, 9, 9)]
        [TestCase(AmountConstants.Range9To14, 9, 14)]
        [TestCase(AmountConstants.Range9To16, 9, 16)]
        [TestCase(AmountConstants.Range9To30, 9, 30)]
        [TestCase(AmountConstants.Range10, 10, 10)]
        [TestCase(AmountConstants.Range10To11, 10, 11)]
        [TestCase(AmountConstants.Range10To20, 10, 20)]
        [TestCase(AmountConstants.Range10To24, 10, 24)]
        [TestCase(AmountConstants.Range10To40, 10, 40)]
        [TestCase(AmountConstants.Range10To50, 10, 50)]
        [TestCase(AmountConstants.Range10To60, 10, 60)]
        [TestCase(AmountConstants.Range10To80, 10, 80)]
        [TestCase(AmountConstants.Range10To100, 10, 100)]
        [TestCase(AmountConstants.Range11, 11, 11)]
        [TestCase(AmountConstants.Range11To20, 11, 20)]
        [TestCase(AmountConstants.Range11To40, 11, 40)]
        [TestCase(AmountConstants.Range12, 12, 12)]
        [TestCase(AmountConstants.Range12To13, 12, 13)]
        [TestCase(AmountConstants.Range12To22, 12, 22)]
        [TestCase(AmountConstants.Range12To30, 12, 30)]
        [TestCase(AmountConstants.Range13, 13, 13)]
        [TestCase(AmountConstants.Range14, 14, 14)]
        [TestCase(AmountConstants.Range14To15, 14, 15)]
        [TestCase(AmountConstants.Range15, 15, 15)]
        [TestCase(AmountConstants.Range15To30, 15, 30)]
        [TestCase(AmountConstants.Range15To50, 15, 50)]
        [TestCase(AmountConstants.Range15To150, 15, 150)]
        [TestCase(AmountConstants.Range16, 16, 16)]
        [TestCase(AmountConstants.Range16To17, 16, 17)]
        [TestCase(AmountConstants.Range17, 17, 17)]
        [TestCase(AmountConstants.Range18, 18, 18)]
        [TestCase(AmountConstants.Range18To19, 18, 19)]
        [TestCase(AmountConstants.Range18To72, 18, 72)]
        [TestCase(AmountConstants.Range19, 19, 19)]
        [TestCase(AmountConstants.Range20, 20, 20)]
        [TestCase(AmountConstants.Range20To50, 20, 50)]
        [TestCase(AmountConstants.Range20To80, 20, 80)]
        [TestCase(AmountConstants.Range20To150, 20, 150)]
        [TestCase(AmountConstants.Range20To160, 20, 160)]
        [TestCase(AmountConstants.Range20To200, 20, 200)]
        [TestCase(AmountConstants.Range21To30, 21, 30)]
        [TestCase(AmountConstants.Range21To40, 21, 40)]
        [TestCase(AmountConstants.Range30To50, 30, 50)]
        [TestCase(AmountConstants.Range30To60, 30, 60)]
        [TestCase(AmountConstants.Range30To100, 30, 100)]
        [TestCase(AmountConstants.Range30To300, 30, 300)]
        [TestCase(AmountConstants.Range40To400, 40, 400)]
        [TestCase(AmountConstants.Range45To150, 45, 150)]
        [TestCase(AmountConstants.Range100To400, 100, 400)]
        public void AmountConstant(string constant, int lower, int upper)
        {
            var bestRoll = GetBestRollFor(lower, upper);
            Assert.That(constant, Is.EqualTo(bestRoll));
        }

        private string GetBestRollFor(int lower, int upper)
        {
            if (lower == upper)
                return lower.ToString();

            var standardDie = new[] { 2, 3, 4, 6, 8, 10, 12, 20, 100 };
            var range = upper - lower;

            var possibleDieRolls = Enumerable.Range(1, range)
                .Where(f => range % f == 0) //Get factors
                .ToDictionary(f => f, f => range / f + 1) //pair quantities with die
                .Where(r => standardDie.Contains(r.Value)) //filter out non-standard die
                .ToDictionary(r => r.Key, r => r.Value);

            var quantity = possibleDieRolls.Min(r => r.Key);
            var die = possibleDieRolls[quantity];
            var adjustment = lower - quantity;

            Assert.That(quantity + adjustment, Is.EqualTo(lower));
            Assert.That(quantity * die + adjustment, Is.EqualTo(upper));

            if (adjustment == 0)
                return $"{quantity}d{die}";

            if (adjustment > 0)
                return $"{quantity}d{die}+{adjustment}";

            return $"{quantity}d{die}{adjustment}";
        }

        [TestCase(AmountConstants.Range0To1, .5, 1)]
        [TestCase(AmountConstants.Range0To2, 2 / 3d, 2)]
        [TestCase(AmountConstants.Range0To4, .8, 4)]
        [TestCase(AmountConstants.Range0To5, 5 / 6d, 5)]
        [TestCase(AmountConstants.Range10PercentTo1, .1, 1)]
        [TestCase(AmountConstants.Range17PercentTo1, 1 / 6d, 1)]
        [TestCase(AmountConstants.Range25PercentTo1, .25, 1)]
        [TestCase(AmountConstants.Range33PercentTo1, 1 / 3d, 1)]
        [TestCase(AmountConstants.Range80PercentTo8, .8, 8)]
        public void AmountConstant(string constant, double percentagePositive, int upper)
        {
            var percentageNegative = percentagePositive - 1;
            var lower = Convert.ToInt32(upper / percentagePositive * percentageNegative) + 1;

            var bestRoll = GetBestRollFor(lower, upper);
            Assert.That(constant, Is.EqualTo(bestRoll));
        }
    }
}
