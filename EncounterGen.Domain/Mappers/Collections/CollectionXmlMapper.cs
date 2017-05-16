using EncounterGen.Domain.Tables;
using System;
using System.Collections.Generic;
using System.Xml;

namespace EncounterGen.Domain.Mappers.Collections
{
    internal class CollectionXmlMapper : CollectionMapper
    {
        private StreamLoader streamLoader;

        public CollectionXmlMapper(StreamLoader streamLoader)
        {
            this.streamLoader = streamLoader;
        }

        public Dictionary<string, IEnumerable<string>> Map(string tableName)
        {
            var filename = tableName + ".xml";
            var results = new Dictionary<string, IEnumerable<string>>();
            var xmlDocument = new XmlDocument();

            using (var stream = streamLoader.LoadFor(filename))
                xmlDocument.Load(stream);

            foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
            {
                var items = new List<string>();
                var itemNodes = node.SelectNodes("item");

                foreach (XmlNode itemNode in itemNodes)
                    items.Add(itemNode.InnerText);

                var name = node.SelectSingleNode("entry").InnerText;

                if (results.ContainsKey(name))
                    throw new ArgumentException($"Cannot insert {name} more than once into table {tableName}");

                results.Add(name, items);
            }

            return results;
        }
    }
}
