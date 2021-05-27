using System.Collections.Generic;

namespace XamlResourcePreviewer.Logic
{
    public interface IXamlService
    {
        Dictionary<string, object> GetResources(string xFile);
    }
}