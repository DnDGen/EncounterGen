using EncounterGen.Tables;
using EncounterGen.Tests.Integration.Common;
using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace EncounterGen.Tests.Integration.Tables
{
    [TestFixture]
    public class EmbeddedResourceStreamLoaderTests : IntegrationTests
    {
        [Inject]
        public StreamLoader StreamLoader { get; set; }

        [Test]
        public void GetsFileIfItIsAnEmbeddedResource()
        {
            var table = Load("Level1DungeonEncounters.xml");

            for (var i = 100; i > 90; i--)
                Assert.That(table[i], Is.EqualTo("Human commoner zombie/1d3"));

            for (var i = 90; i > 80; i--)
                Assert.That(table[i], Is.EqualTo("Human warrior skeleton/1d3+1"));

            for (var i = 80; i > 70; i--)
                Assert.That(table[i], Is.EqualTo("Kobold/1d6+3"));

            for (var i = 70; i > 65; i--)
                Assert.That(table[i], Is.EqualTo("Hobgoblin/1,Goblin/1d3"));

            for (var i = 65; i > 60; i--)
                Assert.That(table[i], Is.EqualTo("Goblin/1d4+2"));

            for (var i = 60; i > 55; i--)
                Assert.That(table[i], Is.EqualTo("Lemure (devil)/1"));

            for (var i = 55; i > 45; i--)
                Assert.That(table[i], Is.EqualTo("Krenshar/1"));

            for (var i = 45; i > 40; i--)
                Assert.That(table[i], Is.EqualTo("Darkmantle/1"));

            for (var i = 40; i > 35; i--)
                Assert.That(table[i], Is.EqualTo("Character1/1"));

            for (var i = 35; i > 30; i--)
                Assert.That(table[i], Is.EqualTo("Elf warrior/1d3"));

            for (var i = 30; i > 25; i--)
                Assert.That(table[i], Is.EqualTo("Dwarf warrior/1d3"));

            for (var i = 25; i > 20; i--)
                Assert.That(table[i], Is.EqualTo("Dragon/1"));

            for (var i = 20; i > 17; i--)
                Assert.That(table[i], Is.EqualTo("Small monstrous spider/1d3"));

            for (var i = 17; i > 14; i--)
                Assert.That(table[i], Is.EqualTo("Small monstrous scorpion/1d3"));

            for (var i = 14; i > 9; i--)
                Assert.That(table[i], Is.EqualTo("Giant fire beetle/1d3+1"));

            for (var i = 9; i > 4; i--)
                Assert.That(table[i], Is.EqualTo("Dire rat/1d3+1"));

            for (var i = 4; i > 0; i--)
                Assert.That(table[i], Is.EqualTo("Medium monstrous centipede/1d3"));
        }

        private Dictionary<Int32, String> Load(String filename)
        {
            var table = new Dictionary<Int32, String>();
            var xmlDocument = new XmlDocument();

            using (var stream = StreamLoader.LoadFor(filename))
                xmlDocument.Load(stream);

            var objects = xmlDocument.DocumentElement.ChildNodes;
            foreach (XmlNode node in objects)
            {
                var lower = Convert.ToInt32(node.SelectSingleNode("lower").InnerText);
                var upper = Convert.ToInt32(node.SelectSingleNode("upper").InnerText);
                var content = node.SelectSingleNode("content").InnerText;

                for (var i = lower; i <= upper; i++)
                    table[i] = content;
            }

            return table;
        }

        [Test]
        public void ThrowErrorIfFileIsNotFormattedCorrectly()
        {
            Assert.That(() => StreamLoader.LoadFor("Level1DungeonEncounters"), Throws.ArgumentException.With.Message.EqualTo("\"Level1DungeonEncounters\" is not a valid file"));
        }

        [Test]
        public void ThrowErrorIfFileIsNotAnEmbeddedResource()
        {
            Assert.That(() => StreamLoader.LoadFor("invalid filename.xml"), Throws.InstanceOf<FileNotFoundException>().With.Message.EqualTo("invalid filename.xml"));
        }

        [Test]
        public void MatchWholeFileName()
        {
            Assert.That(() => StreamLoader.LoadFor("Encounters.xml"), Throws.InstanceOf<FileNotFoundException>().With.Message.EqualTo("Encounters.xml"));
        }
    }
}
