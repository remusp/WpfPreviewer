using PRO.FrameworkWpf;
using System.Collections.Generic;

namespace XamlResourcePreviewer
{
    public class ResourceDictionaryItem : ViewModelBase
    {
        public string Name
        {
            get { return Get(() => Name); }
            set { Set(() => Name, value); }
        }

        public List<ResourceItem> Items
        {
            get { return Get(() => Items); }
            set { Set(() => Items, value); }
        }
    }
}
