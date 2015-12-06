using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class TypeAndAmountPercentileTests : PercentileTests
    {
        public virtual void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            var content = String.Format("{0}/{1}", type, amount);
            Percentile(content, lower, upper);
        }

        public virtual void Percentile(Int32 lower, Int32 upper, String firstType, String firstAmount, String secondType, String secondAmount)
        {
            var content = String.Format("{0}/{1},{2}/{3}", firstType, firstAmount, secondType, secondAmount);
            Percentile(content, lower, upper);
        }
    }
}
