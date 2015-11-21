using EncounterGen.Tables;
using System;
using System.Collections.Generic;
using System.Xml;

namespace EncounterGen.Mappers.Domain.Percentiles
{
    public class PercentileXmlMapper : PercentileMapper
    {
        private StreamLoader streamLoader;

        public PercentileXmlMapper(StreamLoader streamLoader)
        {
            this.streamLoader = streamLoader;
        }

        public Dictionary<Int32, String> Map(String tableName)
        {
            var filename = String.Format("{0}.xml", tableName);
            var results = new Dictionary<Int32, String>();
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
