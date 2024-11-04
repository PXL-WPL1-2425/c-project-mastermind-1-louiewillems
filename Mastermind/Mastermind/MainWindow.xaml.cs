using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mastermind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<(string, SolidColorBrush)> _colorOptions = new List<(string, SolidColorBrush)>();
        private List<(string, SolidColorBrush)> _generatedColors = new List<(string, SolidColorBrush)>();
        private List<(string, SolidColorBrush)> _selectedColors = new List<(string, SolidColorBrush)>();

        public MainWindow()
        {
            InitializeComponent();

            InitGame();
        }

        private void InitGame()
        {
            _colorOptions.Add(("red", new SolidColorBrush(Colors.Red)));
            _colorOptions.Add(("orange", new SolidColorBrush(Colors.Orange)));
            _colorOptions.Add(("yellow", new SolidColorBrush(Colors.Yellow)));
            _colorOptions.Add(("white", new SolidColorBrush(Colors.White)));
            _colorOptions.Add(("green", new SolidColorBrush(Colors.Green)));
            _colorOptions.Add(("blue", new SolidColorBrush(Colors.Blue)));
        }

        private void validateButton_Click(object sender, RoutedEventArgs e)
        {
            List<(string name, SolidColorBrush color)> selectedColors = GenerateRandomColorCodes();
            if (selectedColors.Any() && selectedColors.Count == 4)
            {
                string selectedColorString = string.Join(',', selectedColors.Select(x => x.name));
                mainWindow.Title = $"Mastermind ({selectedColorString})";
            }
        }

        private List<(string name, SolidColorBrush color)> GenerateRandomColorCodes()
        {
            List<(string, SolidColorBrush)> selectedOptions = new List<(string, SolidColorBrush)>();

            for (int i = 0; i < 4; i++)
            {
                (string, SolidColorBrush) keyPair = _colorOptions.ElementAt(new Random().Next(0, _colorOptions.Count()));
                if (keyPair != default)
                {
                    selectedOptions.Add(keyPair);
                }
            }

            return selectedOptions;
        }







    }
}