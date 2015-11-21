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
                Assert.That(table[i], Is.EqualTo("Reroll/2"));

            for (var i = 90; i > 85; i--)
                Assert.That(table[i], Is.EqualTo("Spider swarm/1"));

            for (var i = 85; i > 80; i--)
                Assert.That(table[i], Is.EqualTo("Stirge/1d3"));

            for (var i = 80; i > 71; i--)
                Assert.That(table[i], Is.EqualTo("Orc warrior/1d3"));

            for (var i = 71; i > 62; i--)
                Assert.That(table[i], Is.EqualTo("Tiny viper snake/1d4+1"));

            for (var i = 62; i > 56; i--)
                Assert.That(table[i], Is.EqualTo("Human commoner zombie/1d3"));

            for (var i = 56; i > 50; i--)
                Assert.That(table[i], Is.EqualTo("Human warrior skeleton/1d4"));

            for (var i = 50; i > 40; i--)
                Assert.That(table[i], Is.EqualTo("Kobold warrior/1d4+2"));

            for (var i = 40; i > 30; i--)
                Assert.That(table[i], Is.EqualTo("Goblin warrior/1d3+1"));

            for (var i = 30; i > 28; i--)
                Assert.That(table[i], Is.EqualTo("Lemure (devil)/1"));

            for (var i = 28; i > 25; i--)
                Assert.That(table[i], Is.EqualTo("Krenshar/1"));

            for (var i = 25; i > 22; i--)
                Assert.That(table[i], Is.EqualTo("Darkmantle/1"));

            for (var i = 22; i > 20; i--)
                Assert.That(table[i], Is.EqualTo("Elf warrior/1d3"));

            for (var i = 20; i > 16; i--)
                Assert.That(table[i], Is.EqualTo("Dwarf warrior/1d3"));

            for (var i = 16; i > 13; i--)
                Assert.That(table[i], Is.EqualTo("Small monstrous spider/1d3"));

            for (var i = 13; i > 10; i--)
                Assert.That(table[i], Is.EqualTo("Small monstrous scorpion/1d3"));

            for (var i = 10; i > 8; i--)
                Assert.That(table[i], Is.EqualTo("Giant fire beetle/1d4"));

            for (var i = 8; i > 3; i--)
                Assert.That(table[i], Is.EqualTo("Dire rat/1d4"));

            for (var i = 3; i > 0; i--)
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
                    table.Add(i, content);
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
