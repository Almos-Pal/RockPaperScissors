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
using System.Windows.Shapes;
using System.Text.Json;
using System.Net.Http;

namespace RockPaperScissors
{
    /// <summary>
    /// Interaction logic for StatsWindow.xaml
    /// </summary>
    public partial class StatsWindow : Window
    {
        public StatsWindow()
        {
            InitializeComponent();
            LoadData();

        }



        async void LoadData()
        {
            string url = "https://rockpaperscissors-a0322-default-rtdb.europe-west1.firebasedatabase.app/.json";

            using (HttpClient client = new HttpClient())
            {

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(json);
                    Dictionary<string, JsonData> data = JsonSerializer.Deserialize<Dictionary<string, JsonData>>(json);
                    string statsText = "";
                    foreach (var item in data.Values)
                    {
                        statsText += $"My points: {item.MyPoints} Enemy points: {item.EnemyPoints}\n";
                    }
                    Stats.Text = statsText;
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }






        private void MainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
