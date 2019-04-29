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

namespace omniscient
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        //Closes the about window
        private void closeClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        //Dragging from anywhere on the window
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void TwitterBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/morelikesame"); //Twitter URL Here
        }

        private void DiscordBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/Er3PgfB"); //Invite URL Here
        }

        private void YouTubeBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/morelikesame"); //YouTube URL Here
        }

        private void WWWbtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://morelikesame.github.io"); //Website URL Here
        }
    }
}
