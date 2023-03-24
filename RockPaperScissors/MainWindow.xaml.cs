using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
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
using System.Xml.Linq;
using System.Text.Json;

namespace RockPaperScissors
{
    public partial class MainWindow : Window
    {
        private readonly Random _random;
        private int sum;
        private int enemy_sum;

        public MainWindow()
        {
            InitializeComponent();
            _random = new Random();
            sum = 0;
            enemy_sum = 0;
        }

        



        public class Product
        {
            public string Name { get; set; }
            public int Size { get; set; }
            // Add other properties as needed
        }





        private async void PostData(string data1, string data2)
        {
            using (HttpClient client = new HttpClient())
            {
                var a = await client.GetStringAsync("https://rockpaperscissors-a0322-default-rtdb.europe-west1.firebasedatabase.app/.json");
                Console.WriteLine();
                var values = new Dictionary<string, string>
        {
            { "MyPoints", data1 },
            { "EnemyPoints", data2 }
        };

                var json = JsonSerializer.Serialize(values);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://rockpaperscissors-a0322-default-rtdb.europe-west1.firebasedatabase.app/.json", content);

                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
            }
        }

        private void StatsWindow(object sender, RoutedEventArgs e)
        {
            StatsWindow statsWindow = new StatsWindow();
            statsWindow.Show();
            this.Close();
        }
        private void GameoverWindow()
        {
            RockPaperScissors.Gameover g = new RockPaperScissors.Gameover();
            g.Show();
        }

        private void RockButton_Click(object sender, RoutedEventArgs e)
        {
            Play("rock");
        }

        private void PaperButton_Click(object sender, RoutedEventArgs e)
        {
            Play("paper");
        }

        private void ScissorsButton_Click(object sender, RoutedEventArgs e)
        {
            Play("scissors");
        }
        private bool Gameover()
        {
            if(sum == 10 ||enemy_sum == 10)
            {
                return true;
            }
            return false;
        }
        private void Play(string playerMove)
        {
            string[] moves = { "rock", "paper", "scissors" };
            string computerMove = moves[_random.Next(moves.Length)];
            computerMoveText.Text = computerMove;

            if (playerMove == computerMove)
            {
                resultText.Text = "Tie!";
            }
            else if (playerMove == "rock" && computerMove == "scissors" ||
                     playerMove == "paper" && computerMove == "rock" ||
                     playerMove == "scissors" && computerMove == "paper")
            {
                resultText.Text = "You Win!";
                sum += 1;
            }
            else
            {
                resultText.Text = "You Lose!";
                enemy_sum += 1;
            }

            Points.Text = $"{sum.ToString()}:{enemy_sum.ToString()}";



            if (Gameover())
            {
                GameoverWindow();
                PostData(sum.ToString(), enemy_sum.ToString());
                this.Close();
            }
        }


    }
}
