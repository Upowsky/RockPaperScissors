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

namespace RockPaperScizors
{
    public partial class MainWindow : Window
    {
        int userPoints = 0;
        int computerPoints = 0;

        void LoadImage(Image img, string path)
        {
            img.Source = new BitmapImage(new Uri(path, UriKind.Relative));
        }
        public MainWindow()
        {
            InitializeComponent();

            LoadImage(imgRock, "images/Rock.png");
            LoadImage(imgPaper, "images/Paper.png");
            LoadImage(imgScissors, "images/Scissors.png");
        }

        private void Play(int choise)
        {
            int userChoise = choise;

            Random rnd = new Random();
            int computerChoise = rnd.Next(0, 3);

                switch (computerChoise)
                {
                    case 0:
                        LoadImage(imgComputer, "images/Rock.png");
                        labelComputer.Content = "ROCK";
                        labelComputer.Foreground = Brushes.Red;
                    break;

                    case 1:
                        LoadImage(imgComputer, "images/Paper.png");
                        labelComputer.Content = "PAPER";
                        labelComputer.Foreground = Brushes.Gold;
                    break;

                    case 2:
                        LoadImage(imgComputer, "images/Scissors.png");
                        labelComputer.Content = "SCISSORS";
                        labelComputer.Foreground = Brushes.DarkTurquoise;
                    break;
                }

            if (userChoise == computerChoise)
            {
                labelResult.Content = "DRAW";
                labelResult.Foreground = Brushes.Black;
            }

            else if (userChoise == 0 && computerChoise == 1)            //Rock - Paper
                ComputerWin();

            else if (userChoise == 0 && computerChoise == 2)            //Rock - scissors
                UserWin();

            else if (userChoise == 1 && computerChoise == 0)            //Paper - Rock
                UserWin();

            else if (userChoise == 1 && computerChoise == 2)            //Paper - Scissors
                ComputerWin();

            else if (userChoise == 2 && computerChoise == 0)            //Scissors - Rock
                ComputerWin();

            else if (userChoise == 2 && computerChoise == 1)            //Scissors - Paper
                UserWin();

            labelUserPoints.Content = userPoints.ToString();
            labelComputerPoints.Content = computerPoints.ToString();
        }

        private void UserWin()
        {
            labelResult.Foreground = Brushes.Green;
            userPoints++;

            labelResult.Content = "YOU WIN!";
        }

        private void ComputerWin()
        {
            labelResult.Foreground = Brushes.Red;
            computerPoints++;

            labelResult.Content = "YOU LOSE!";
        }
        private void ImgRock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            labelUser.Content = "ROCK";
            labelUser.Foreground = Brushes.Red;

            Play(0);
        }

        private void ImgPaper_MouseUp(object sender, MouseButtonEventArgs e)
        {
            labelUser.Content = "PAPER";
            labelUser.Foreground = Brushes.Gold;

            Play(1);
        }

        private void ImgScissors_MouseUp(object sender, MouseButtonEventArgs e)
        {
            labelUser.Content = "SCISSORS";
            labelUser.Foreground = Brushes.DarkTurquoise;

            Play(2);
        }
    }
}
