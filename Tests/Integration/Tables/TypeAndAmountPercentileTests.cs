using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class TypeAndAmountPercentileTests : PercentileTests
    {
        public virtual void Percentile(Int32 lower, Int32 upper, params String[] typesAndAmounts)
        {
            if (typesAndAmounts.Length % 2 == 1 || typesAndAmounts.Length == 0)
                throw new ArgumentException("Incorrect number of arguments");

            var content = String.Format("{0}/{1}", typesAndAmounts[0], typesAndAmounts[1]);
            for (var i = 2; i < typesAndAmounts.Length; i += 2)
                content += String.Format(",{0}/{1}", typesAndAmounts[i], typesAndAmounts[i + 1]);

            Percentile(content, lower, upper);
        }
    }
}
