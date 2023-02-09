using PRO.FrameworkWpf;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace XamlResourcePreviewer
{
    /// <summary>
    /// Interaction logic for ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        private bool _nightMode;
        private Brush _darkBrush = new SolidColorBrush(Color.FromRgb(42, 39, 39));

        public ImageWindow()
        {
            InitializeComponent();
            ToggleBackgroundCommand = new DelegateCommand(ToggleBackgroundCommandExecute);
        }

        public ICommand ToggleBackgroundCommand { get; }

        private void ToggleBackgroundCommandExecute()
        {
            
            _nightMode = !_nightMode;
            Cacanvas.Background = _nightMode ? _darkBrush : Brushes.White;
        }
    }
}
