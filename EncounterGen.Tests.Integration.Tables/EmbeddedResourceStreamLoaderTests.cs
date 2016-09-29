using EncounterGen.Domain.Tables;
using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
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
            var table = Load("EncounterDifficulty.xml");

            Assert.That(table["-7"], Is.EquivalentTo(new[] { "Very Easy" }));
            Assert.That(table["-6"], Is.EquivalentTo(new[] { "Very Easy" }));
            Assert.That(table["-5"], Is.EquivalentTo(new[] { "Very Easy" }));
            Assert.That(table["-4"], Is.EquivalentTo(new[] { "Easy" }));
            Assert.That(table["-3"], Is.EquivalentTo(new[] { "Easy" }));
            Assert.That(table["-2"], Is.EquivalentTo(new[] { "Easy" }));
            Assert.That(table["-1"], Is.EquivalentTo(new[] { "Easy" }));
            Assert.That(table["0"], Is.EquivalentTo(new[] { "Challenging" }));
            Assert.That(table["1"], Is.EquivalentTo(new[] { "Very Difficult" }));
            Assert.That(table["2"], Is.EquivalentTo(new[] { "Very Difficult" }));
            Assert.That(table["3"], Is.EquivalentTo(new[] { "Very Difficult" }));
            Assert.That(table["4"], Is.EquivalentTo(new[] { "Very Difficult" }));
            Assert.That(table["5"], Is.EquivalentTo(new[] { "Overpowering" }));
            Assert.That(table["6"], Is.EquivalentTo(new[] { "Overpowering" }));

            Assert.That(table.Count, Is.EqualTo(14));
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
            Assert.That(() => StreamLoader.LoadFor("EncounterDifficulty"), Throws.ArgumentException.With.Message.EqualTo("\"EncounterDifficulty\" is not a valid file"));
        }

        [Test]
        public void ThrowErrorIfFileIsNotAnEmbeddedResource()
        {
            Assert.That(() => StreamLoader.LoadFor("invalid filename.xml"), Throws.InstanceOf<FileNotFoundException>().With.Message.EqualTo("invalid filename.xml"));
        }

        [Test]
        public void MatchWholeFileName()
        {
            Assert.That(() => StreamLoader.LoadFor("Difficulty.xml"), Throws.InstanceOf<FileNotFoundException>().With.Message.EqualTo("Difficulty.xml"));
        }
    }
}
