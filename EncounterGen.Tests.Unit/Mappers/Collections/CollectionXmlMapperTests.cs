using EncounterGen.Domain.Mappers.Collections;
using EncounterGen.Domain.Tables;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace EncounterGen.Tests.Unit.Mappers.Collections
{
    [TestFixture]
    public class CollectionXmlMapperTests
    {
        private const string tableName = "CollectionXmlMapperTests";

        private string fileName;
        private CollectionMapper mapper;
        private Mock<StreamLoader> mockStreamLoader;
        private string contents;

        [SetUp]
        public void Setup()
        {
            fileName = tableName + ".xml";
            contents = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                         <collections>
                             <object>
                                 <entry>first name</entry>
                                 <item>first item</item>
                                 <item>second item</item>
                             </object>
                             <object>
                                 <entry>second name</entry>
                                 <item>third item</item>
                             </object>
                             <object>
                                 <entry>empty name</entry>
                             </object>
                         </collections>";

            mockStreamLoader = new Mock<StreamLoader>();
            mockStreamLoader.Setup(l => l.LoadFor(fileName)).Returns(() => GetStream());

            mapper = new CollectionXmlMapper(mockStreamLoader.Object);
        }

        [Test]
        public void AppendXmlFileExtensionToTableName()
        {
            mapper.Map(tableName);
            mockStreamLoader.Verify(l => l.LoadFor(fileName), Times.Once);
        }

        [Test]
        public void LoadXmlFromStream()
        {
            var table = mapper.Map(tableName);

            var items = table["first name"];
            Assert.That(items, Contains.Item("first item"));
            Assert.That(items, Contains.Item("second item"));
            Assert.That(items.Count(), Is.EqualTo(2));

            items = table["second name"];
            Assert.That(items, Contains.Item("third item"));
            Assert.That(items.Count(), Is.EqualTo(1));

            items = table["empty name"];
            Assert.That(items, Is.Empty);
        }

        [Test]
        public void EmptyFileReturnsEmptyMapping()
        {
            contents = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                         <collections>
                         </collections>";

            var table = mapper.Map(tableName);
            Assert.That(table, Is.Empty);
        }

        private Stream GetStream()
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(contents);
            writer.Flush();
            stream.Position = 0;

            return stream;
        }

        [Test]
        public void DuplicateNamesThrowError()
        {
            contents = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                         <collections>
                             <object>
                                 <entry>first name</entry>
                                 <item>first item</item>
                                 <item>second item</item>
                             </object>
                             <object>
                                 <entry>first name</entry>
                                 <item>other item</item>
                             </object>
                             <object>
                                 <entry>second name</entry>
                                 <item>third item</item>
                             </object>
                             <object>
                                 <entry>empty name</entry>
                             </object>
                         </collections>";

            Assert.That(() => mapper.Map(tableName), Throws.ArgumentException.With.Message.EqualTo($"Cannot insert first name more than once into table {tableName}"));
        }
    }
}
