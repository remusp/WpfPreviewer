using PRO.FrameworkWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
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
            RemoveFileCommand = new DelegateCommand<ResourceDictionaryItem>(file => RemoveFileCommandExecute(file));
            OpenWindowCommand = new DelegateCommand<ResourceItem>(item => OpenWindowCommandExecute(item));
        }

        public ICommand RemoveFileCommand { get; }
        public ICommand OpenWindowCommand { get; }

        public ObservableCollection<ResourceDictionaryItem> Files
        {
            get { return Get(() => Files); }
            set { Set(() => Files, value); }
        }

        public void AddFiles(string[] fileNames)
        {
            StringBuilder notSupported = new StringBuilder("Cannot load the following:");
            notSupported.AppendLine();
            bool hasParseErrors = false;
            foreach (var xFile in fileNames)
            {
                try
                {
                    var resources = _xamlService.GetResources(xFile);
                    Files.Add(new ResourceDictionaryItem()
                    {
                        Name = xFile,
                        Items = GetAsItems(resources)
                    });
                }
                catch 
                {
                    hasParseErrors = true;
                    notSupported.AppendLine(Path.GetFileName(xFile));
                }
            }

            if (hasParseErrors) 
            {
                MessageBox.Show(notSupported.ToString(), "WPF Previewer", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void RemoveFileCommandExecute(ResourceDictionaryItem file)
        {
            Files.Remove(file);
        }

        private void OpenWindowCommandExecute(ResourceItem item)
        {
            var window = new ImageWindow
            {
                Title = item.Name,
                DataContext = item.RenderedItem
            };

            window.Show();
        }

    }
}
