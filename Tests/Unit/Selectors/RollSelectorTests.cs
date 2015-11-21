using EncounterGen.Selectors;
using EncounterGen.Selectors.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class RollSelectorTests
    {
        private IRollSelector rollSelector;

        [SetUp]
        public void Setup()
        {
            rollSelector = new RollSelector();
        }
    }
}
