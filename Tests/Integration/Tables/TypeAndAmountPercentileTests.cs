using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace EncounterGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class TypeAndAmountPercentileTests : PercentileTests
    {
        private Regex regex;

        public TypeAndAmountPercentileTests()
        {
            regex = new Regex("^(\\d+(d?\\d+(\\+?\\d+)?)?)$");
        }

        public virtual void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            Assert.That(regex.IsMatch(amount), Is.True);

            var content = String.Format("{0}/{1}", type, amount);
            Percentile(content, lower, upper);
        }
    }
}
