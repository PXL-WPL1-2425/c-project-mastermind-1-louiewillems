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

        private List<(string name, SolidColorBrush color)> _colorOptions = new List<(string, SolidColorBrush)>();
        private List<Label> _labels = new List<Label>();
        private List<ComboBox> comboBoxes = new List<ComboBox>();

        public MainWindow()
        {
            InitializeComponent();
            InitGame();
        }

        private void InitGame()
        {
            _colorOptions.Add(("Red", new SolidColorBrush(Colors.Red)));
            _colorOptions.Add(("Orange", new SolidColorBrush(Colors.Orange)));
            _colorOptions.Add(("Yellow", new SolidColorBrush(Colors.Yellow)));
            _colorOptions.Add(("White", new SolidColorBrush(Colors.White)));
            _colorOptions.Add(("Green", new SolidColorBrush(Colors.Green)));
            _colorOptions.Add(("Blue", new SolidColorBrush(Colors.Blue)));

            comboBoxes.Add(chooseCombobox1);
            comboBoxes.Add(chooseCombobox2);
            comboBoxes.Add(chooseCombobox3);
            comboBoxes.Add(chooseCombobox4);

            _labels.Add(chooseLabel1);
            _labels.Add(chooseLabel2);
            _labels.Add(chooseLabel3);
            _labels.Add(chooseLabel4);

            for (int i = 0; i < comboBoxes.Count(); i++)
            {
                for (int j = 0; j < _colorOptions.Count; j++)
                {
                    comboBoxes[i].Items.Add(_colorOptions[j].name);
                }

                comboBoxes[i].SelectionChanged += (obj, args) => { OnDropdownSelection(obj, args); };
            }

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

        private void OnDropdownSelection(object sender, SelectionChangedEventArgs e)
        {
            ComboBox? comboBox = sender as ComboBox;
            if (comboBox == null || string.IsNullOrEmpty(comboBox.Name))
                return; 

            Label? foundLabel = _labels.FirstOrDefault(x => x.Name.EndsWith(comboBox.Name.Last()));
            if (foundLabel != null)
            {
                (string name, SolidColorBrush color) foundColor = 
                    _colorOptions.FirstOrDefault(x => x.name == comboBox.SelectedValue.ToString());
                if (foundColor != default)
                {
                    foundLabel.Background = foundColor.color;
                }
            }

        }


    }
}