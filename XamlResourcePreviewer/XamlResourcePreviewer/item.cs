using System.Collections.ObjectModel;
using System.Windows.Input;

namespace XamlResourcePreviewer
{
    public interface item
    {
        ObservableCollection<ResourceDictionaryItem> Files { get; set; }
        ICommand OpenWindowCommand { get; }
        ICommand RemoveFileCommand { get; }

        void AddFiles(string[] fileNames);
    }
}