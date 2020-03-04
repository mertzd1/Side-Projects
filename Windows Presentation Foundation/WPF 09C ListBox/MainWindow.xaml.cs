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


namespace ListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Match> matches = new List<Match>();
            matches.Add(new Match() { Team1 = "Detroit Lions", Team2 = "Tampa Bay Bucaneers", Score1 = 35, Score2 = 21, Completion = 49 });
            matches.Add(new Match() { Team1 = "Denver Brocos", Team2 = "New England Patriots", Score1 = 18, Score2 = 14, Completion = 26 });
            matches.Add(new Match() { Team1 = "Washington Redskins", Team2 = "Green Bay Packers", Score1 = 18, Score2 = 0, Completion = 55 });

            lbMatches.ItemsSource = matches;
        }
        public class Match
        {
            public int Score1 { get; set; }
            public int Score2 { get; set; }
            public string Team1 { get; set; }
            public string Team2 { get; set; }
            public int Completion { get; set; }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(lbMatches.SelectedItem!=null)
            {
                MessageBox.Show("Selected Match: "
                    + (lbMatches.SelectedItem as Match).Team1 + " " +
                    (lbMatches.SelectedItem as Match).Score1 + " " +
                    (lbMatches.SelectedItem as Match).Team2 + " " +
                    (lbMatches.SelectedItem as Match).Score2);                    
            }
        }
    }
}
