using EncounterGen.Common;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Common
{
    [TestFixture]
    public class ChallengeRatingConstantsTests
    {
        [TestCase(ChallengeRatingConstants.Zero, "0")]
        [TestCase(ChallengeRatingConstants.OneTenth, "1/10")]
        [TestCase(ChallengeRatingConstants.OneEighth, "1/8")]
        [TestCase(ChallengeRatingConstants.OneSixth, "1/6")]
        [TestCase(ChallengeRatingConstants.OneFourth, "1/4")]
        [TestCase(ChallengeRatingConstants.OneThird, "1/3")]
        [TestCase(ChallengeRatingConstants.OneHalf, "1/2")]
        [TestCase(ChallengeRatingConstants.One, "1")]
        [TestCase(ChallengeRatingConstants.Two, "2")]
        [TestCase(ChallengeRatingConstants.Three, "3")]
        [TestCase(ChallengeRatingConstants.Four, "4")]
        [TestCase(ChallengeRatingConstants.Five, "5")]
        [TestCase(ChallengeRatingConstants.Six, "6")]
        [TestCase(ChallengeRatingConstants.Seven, "7")]
        [TestCase(ChallengeRatingConstants.Eight, "8")]
        [TestCase(ChallengeRatingConstants.Nine, "9")]
        [TestCase(ChallengeRatingConstants.Ten, "10")]
        [TestCase(ChallengeRatingConstants.Eleven, "11")]
        [TestCase(ChallengeRatingConstants.Twelve, "12")]
        [TestCase(ChallengeRatingConstants.Thirteen, "13")]
        [TestCase(ChallengeRatingConstants.Fourteen, "14")]
        [TestCase(ChallengeRatingConstants.Fifteen, "15")]
        [TestCase(ChallengeRatingConstants.Sixteen, "16")]
        [TestCase(ChallengeRatingConstants.Seventeen, "17")]
        [TestCase(ChallengeRatingConstants.Eighteen, "18")]
        [TestCase(ChallengeRatingConstants.Nineteen, "19")]
        [TestCase(ChallengeRatingConstants.Twenty, "20")]
        [TestCase(ChallengeRatingConstants.TwentyOne, "21")]
        [TestCase(ChallengeRatingConstants.TwentyTwo, "22")]
        [TestCase(ChallengeRatingConstants.TwentyThree, "23")]
        [TestCase(ChallengeRatingConstants.TwentyFour, "24")]
        [TestCase(ChallengeRatingConstants.TwentyFive, "25")]
        [TestCase(ChallengeRatingConstants.TwentySix, "26")]
        [TestCase(ChallengeRatingConstants.TwentySeven, "27")]
        [TestCase(ChallengeRatingConstants.TwentyEight, "28")]
        [TestCase(ChallengeRatingConstants.TwentyNine, "29")]
        [TestCase(ChallengeRatingConstants.Thirty, "30")]
        public void ChallengeRatingConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
