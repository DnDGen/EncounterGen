using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EncounterGen.Tables.Domain
{
    public class EmbeddedResourceStreamLoader : StreamLoader
    {
        public Stream LoadFor(String filename)
        {
            if (filename.Contains('.') == false)
            {
                var message = String.Format("\"{0}\" is not a valid file", filename);
                throw new ArgumentException(message);
            }

            var assembly = Assembly.GetExecutingAssembly();
            var resources = assembly.GetManifestResourceNames();
            var fileNames = resources.Select(r => GetFileName(r));

            if (fileNames.Contains(filename) == false)
                throw new FileNotFoundException(filename);

            var streamSource = resources.Single(r => r.EndsWith("." + filename));
            return assembly.GetManifestResourceStream(streamSource);
        }

        private String GetFileName(String resource)
        {
            var segments = resource.Split('.');
            var fileName = segments[segments.Length - 2];
            var extension = segments[segments.Length - 1];

            return String.Format("{0}.{1}", fileName, extension);
        }
    }
}
