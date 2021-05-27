using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Markup;

namespace XamlResourcePreviewer.Logic
{
    public class XamlService : IXamlService
    {
        public Dictionary<string, object> GetResources(string xFile)
        {
            Dictionary<string, object> results = new Dictionary<string, object>();

            using (FileStream xFileStream = new FileStream(xFile, FileMode.Open))
            {
                var content = XamlReader.Load(xFileStream);
                if (content is ResourceDictionary resourceDictionary)
                {
                    foreach (DictionaryEntry resource in resourceDictionary)
                    {
                        results[resource.Key as string] = resource.Value;
                    }
                }
            }

            return results;
        }
    }
}
