using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchMatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalCharacters = new List<string>()
            {
                "鱼","鱼",
                "象","象",
                "鲸","鲸",
                "骆","骆",
                "龙","龙",
                "鼠","鼠",
                "猬","猬",
                "猴","猴",
            };
            Random random = new Random();
            foreach(TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalCharacters.Count);
                textBlock.Text = animalCharacters[index];
                animalCharacters.RemoveAt(index);
            }
        }
    }
}
