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
using System.Windows.Forms;
using System.Drawing;
using DiscordRPC;

namespace omniscient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer;
        public DiscordRpcClient client;
        private DispatcherTimer rpcupdateTimer;
        public static System.Windows.Forms.NotifyIcon notIco = new System.Windows.Forms.NotifyIcon();

        void Initialize()
        {
            client = new DiscordRpcClient("551862655103664138");
            client.Initialize();
        }

        public MainWindow()
        {
            var sP = new SetPresence();
            sP.Initialize();
            InitializeComponent();

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimer.Start();

            rpcupdateTimer = new DispatcherTimer();
            rpcupdateTimer.Tick += new EventHandler(rpcupdateTimer_Tick);
            rpcupdateTimer.Interval = new TimeSpan(0, 0, 2);
            rpcupdateTimer.Start();

            notIco.DoubleClick +=
            delegate (object sender, EventArgs args)
            {
                this.Show();
                this.WindowState = WindowState.Normal;
                notIco.Visible = false;
            };

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (client != null) { client.Invoke(); }
            CurrentlyOpen.Content = GetWindowTitle.GetCaptionOfActiveWindow();

        }

        private void rpcupdateTimer_Tick(object sender, EventArgs e)
        {
            var sP = new SetPresence();
            sP.RPCUpdate();
        }

        private void closeClick(object sender, RoutedEventArgs e)
        {
            if (client != null)
            {
                client.Dispose();
            }
            notIco.Dispose();
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        public void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            notIco.Icon = Properties.Resources.omni_icon_white;
            notIco.Visible = true;
            this.Hide();
            notIco.ShowBalloonTip(300, "Omniscient","Omniscient was minimized to the icon tray.",ToolTipIcon.Info);
        }

    }
}
