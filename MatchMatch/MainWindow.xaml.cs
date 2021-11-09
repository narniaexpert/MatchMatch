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
using System.Windows.Threading;

namespace MatchMatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timerTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound==8)
            {
                timer.Stop();
                timerTextBlock.Text += " - Play Again?";
            }
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
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timerTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalCharacters.Count);
                    textBlock.Text = animalCharacters[index];
                    animalCharacters.RemoveAt(index);
                }
            }
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;
            timer.Start();
        }


        TextBlock lastTextBlockClicked;
        bool findingMatch = false; 
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text) {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void timerTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound==8)
            {
                SetUpGame();
            }
        }
    }
}
