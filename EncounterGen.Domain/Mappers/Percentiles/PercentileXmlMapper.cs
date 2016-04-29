using EncounterGen.Domain.Tables;
using System;
using System.Collections.Generic;
using System.Xml;

namespace EncounterGen.Domain.Mappers.Percentiles
{
    internal class PercentileXmlMapper : PercentileMapper
    {
        private StreamLoader streamLoader;

        public PercentileXmlMapper(StreamLoader streamLoader)
        {
            this.streamLoader = streamLoader;
        }

        public Dictionary<int, string> Map(string tableName)
        {
            var filename = $"{tableName}.xml";
            var results = new Dictionary<int, string>();
            var xmlDocument = new XmlDocument();

            using (var stream = streamLoader.LoadFor(filename))
                xmlDocument.Load(stream);

            var objects = xmlDocument.DocumentElement.ChildNodes;
            foreach (XmlNode node in objects)
            {
                var lowerLimit = Convert.ToInt32(node.SelectSingleNode("lower").InnerText);
                var content = node.SelectSingleNode("content").InnerText;
                var upperLimit = Convert.ToInt32(node.SelectSingleNode("upper").InnerText);

                for (var roll = lowerLimit; roll <= upperLimit; roll++)
                    results[roll] = content;
            }

            return results;
        }
    }
}
