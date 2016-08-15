using EncounterGen.Domain.Tables;
using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace EncounterGen.Tests.Integration.Tables
{
    [TestFixture]
    public class EmbeddedResourceStreamLoaderTests : IntegrationTests
    {
        [Inject]
        internal StreamLoader StreamLoader { get; set; }

        [Test]
        public void GetsFileIfItIsAnEmbeddedResource()
        {
            var table = Load("RollOrder.xml");

            var rolls = new[] { "1", "1", "1", "1d2", "1d3", "1d3+1", "1d4+2", "1d6+3", "1d6+5", "1d4+10" };
            Assert.That(table["All"], Is.EquivalentTo(rolls));

            var challengeRatings = new[] { "1/10", "1/8", "1/6", "1/4", "1/3", "1/2" };
            var levels = Enumerable.Range(1, 30).Select(l => l.ToString());
            Assert.That(table["CR"], Is.EquivalentTo(challengeRatings.Union(levels)));
        }

        private Dictionary<string, List<string>> Load(string filename)
        {
            var table = new Dictionary<string, List<string>>();
            var xmlDocument = new XmlDocument();

            using (var stream = StreamLoader.LoadFor(filename))
                xmlDocument.Load(stream);

            foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
            {
                var items = new List<string>();
                var itemNodes = node.SelectNodes("item");

                foreach (XmlNode itemNode in itemNodes)
                    items.Add(itemNode.InnerText);

                var name = node.SelectSingleNode("entry").InnerText;
                table.Add(name, items);
            }

            return table;
        }

        [Test]
        public void ThrowErrorIfFileIsNotFormattedCorrectly()
        {
            Assert.That(() => StreamLoader.LoadFor("RollOrder"), Throws.ArgumentException.With.Message.EqualTo("\"RollOrder\" is not a valid file"));
        }

        [Test]
        public void ThrowErrorIfFileIsNotAnEmbeddedResource()
        {
            Assert.That(() => StreamLoader.LoadFor("invalid filename.xml"), Throws.InstanceOf<FileNotFoundException>().With.Message.EqualTo("invalid filename.xml"));
        }

        [Test]
        public void MatchWholeFileName()
        {
            Assert.That(() => StreamLoader.LoadFor("Order.xml"), Throws.InstanceOf<FileNotFoundException>().With.Message.EqualTo("Order.xml"));
        }
    }
}
