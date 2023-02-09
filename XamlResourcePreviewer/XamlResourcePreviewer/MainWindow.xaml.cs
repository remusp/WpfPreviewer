using Microsoft.Win32;
using System.Windows;
using XamlResourcePreviewer.Logic;

namespace XamlResourcePreviewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddFilesClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Xaml files (*.xaml)|*.xaml"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _viewModel.AddFiles(openFileDialog.FileNames);
            }
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel = new MainWindowViewModel(new XamlService());
        }

        private void ListBox_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            MainScroll.ScrollToVerticalOffset(MainScroll.VerticalOffset - e.Delta);
        }
    }
}
