using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Unit
{
    internal class ConfigTests
    {
        [Test]
        public void ConfigNameIsCorrect()
        {
            var configType = typeof(Config);
            Assert.That(Config.Name, Is.EqualTo("DnDGen.EncounterGen").And.EqualTo(configType.Namespace));
        }
    }
}
