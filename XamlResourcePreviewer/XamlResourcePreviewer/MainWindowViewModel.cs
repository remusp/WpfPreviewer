using PRO.FrameworkWpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XamlResourcePreviewer.Logic;

namespace XamlResourcePreviewer
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IXamlService _xamlService;

        public MainWindowViewModel(IXamlService xamlService)
        {
            Files = new ObservableCollection<ResourceDictionaryItem>();
            _xamlService = xamlService;
        }

        public ObservableCollection<ResourceDictionaryItem> Files
        {
            get { return Get(() => Files); }
            set { Set(() => Files, value); }
        }

        public void AddFiles(string[] fileNames)
        {
            foreach (var xFile in fileNames)
            {
                var resources = _xamlService.GetResources(xFile);
                Files.Add(new ResourceDictionaryItem()
                {
                    Name = xFile,
                    Items = GetAsItems(resources)
                });
            }
        }

        private List<ResourceItem> GetAsItems(Dictionary<string, object> resources)
        {
            return resources.Select(r => new ResourceItem
            {
                Name = r.Key,
                RenderedItem = r.Value
            }).ToList();
        }
    }
}
