using PRO.FrameworkWpf;

namespace XamlResourcePreviewer
{
    public class ResourceItem : ViewModelBase
    {
        public string Name
        {
            get { return Get(() => Name); }
            set { Set(() => Name, value); }
        }

        public object RenderedItem
        {
            get { return Get(() => RenderedItem); }
            set { Set(() => RenderedItem, value); }
        }
    }
}
