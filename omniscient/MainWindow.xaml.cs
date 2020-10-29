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
using System.Diagnostics;
using omniscient.Properties;

using DiscordRPC;
using Microsoft.Win32;
using System.Security.Policy;

namespace omniscient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private DispatcherTimer TUChange; //title update timer
        public DiscordRpcClient client; //discord rpc client
        public static System.Windows.Forms.NotifyIcon notIco = new System.Windows.Forms.NotifyIcon(); //tray icon
        public static string BlockList; //list of blocked words
        private string appID = "551862655103664138"; //discord app id
        private bool bl_hidden;
        public bool bootsAtStartup;

        //Initialize the discord rpc client
        void Initialize()
        {
            client = new DiscordRpcClient(appID);
            client.Initialize();
        }

        public MainWindow()
        {
            var sP = new SetPresence();
            //Initializes the rich presence.
            sP.Initialize();

            InitializeComponent();
            
            //Loads saved stuff
            SaveSettings.FileLoader();
            TickBoxLoader();

            //Sets loaded list.
            BlockedWordsTextBox.Text = SaveSettings.LoadedList;

            //Title update check timer.
            TUChange = new DispatcherTimer();
            TUChange.Tick += new EventHandler(TUChange_Tick);
            TUChange.Interval = new TimeSpan(0, 0, 1);
            TUChange.Start();

            //Double clicking the tray icon
            notIco.DoubleClick +=
            delegate (object sender, EventArgs args)
            {
                this.Show();
                this.WindowState = WindowState.Normal;
                notIco.Visible = false;
            };

        }

        //Checks Window Title for blocked words
        public void BlockedWordCheck()
        {
            string WindowTitle = GetWindowTitle.GetCaptionOfActiveWindow();

            string blockedWordsString = BlockedWordsTextBox.Text;
            string[] blockedWords = blockedWordsString.Split(' ');

            blockedWords = Array.ConvertAll(blockedWords, d => d.ToLower());

            BlockList = blockedWordsString;

            if (blockedWordsString == "" || blockedWordsString == " ")
            {
                SetPresence.blockedWord = false;
            }
            else if (blockedWords.Any(WindowTitle.ToLower().Contains))
            {
                SetPresence.blockedWord = true;
            }
            else{
                SetPresence.blockedWord = false;
            }
        }

        private string oldTitle = string.Empty;

        //Updates the presence when it detects a title change.

        private void UpdatePresence()
        {
            string newTitle = GetWindowTitle.GetFullTitle();

            if (oldTitle != newTitle)
            {
                if (client != null) { client.Invoke(); }

                //TickBoxSaver();

                CurrentlyOpen.Content = GetWindowTitle.GetCaptionOfActiveWindow();
                CurrentProcessOpen.Content = GetWindowTitle.GetActiveProcessFileName();

                SetPresence.StatText = CustomStatusText.Text;
                SetPresence.CustAppText = CustomAppText.Text;

                CustomAppText.MaxLength = 128;
                CustomStatusText.MaxLength = 128;

                oldTitle = newTitle;

                BlockedWordCheck();
                var sP = new SetPresence();
                sP.RPCUpdate();
            }
        }

        private void ForceUpdatePresence()
        {
                if (client != null) { client.Invoke(); }

                //TickBoxSaver();

                CurrentlyOpen.Content = GetWindowTitle.GetCaptionOfActiveWindow();
                
                SetPresence.StatText = CustomStatusText.Text;
                SetPresence.CustAppText = CustomAppText.Text;

                CustomAppText.MaxLength = 128;
                CustomStatusText.MaxLength = 128;

                BlockedWordCheck();
                var sP = new SetPresence();
                sP.RPCUpdate();
        }

        //Update Window title to Omniscient
        private void TUChange_Tick(object sender, EventArgs e)
        {
            UpdatePresence();
        }

        private void TickBoxSaver()
        {
            Settings.Default.OldIcons = SetPresence.altTheme;
            Settings.Default.HideBlockList = bl_hidden;
            Settings.Default.bootsAtStartup = bootsAtStartup;

            Settings.Default.Save();
        }

        private void TickBoxLoader()
        {
            SetPresence.altTheme = Settings.Default.OldIcons;
            Theme_Check.IsChecked = Settings.Default.OldIcons;
            bl_hidden = Settings.Default.HideBlockList;
            bootsAtStartup = Settings.Default.bootsAtStartup;
            if (bootsAtStartup == true)
            {
                RoS_btn.Content = "Don't run at startup";
            } else
            {
                RoS_btn.Content = "Run at startup";
            }
            Blocklist_Check.IsChecked = Settings.Default.HideBlockList;
        }

        //Close Button
        private void CloseClick(object sender, RoutedEventArgs e)
        {
            TickBoxSaver();
            if (client != null)
            {
                client.Dispose();
            }
            notIco.Dispose();
            Close();
        }

        //Dragging from anywhere on the window
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        //Minimize to tray (hides window and Creates Tray icon)
        public void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            notIco.Icon = Properties.Resources.omni_icon_white;
            notIco.Visible = true;
            this.Hide();
            notIco.ShowBalloonTip(300, "Omniscient","Omniscient was minimized to the icon tray.",ToolTipIcon.Info);
        }
        //Info Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SetPresence.customStatus = true; //Sets the custom status option true.
            ForceUpdatePresence();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            SetPresence.customStatus = false; //Sets the custom status option false.
            ForceUpdatePresence();
        }

        private void CustomAppTextCheck_Checked(object sender, RoutedEventArgs e)
        {
            SetPresence.customApp = true; //Sets the custom app option true.
            ForceUpdatePresence();
        }

        private void CustomAppTextCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            SetPresence.customApp = false; //Sets the custom app option false.
            ForceUpdatePresence();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings.QuickAndDirtyFix();
            TickBoxSaver();
        }

        private void IncognitoCheck_Checked(object sender, RoutedEventArgs e)
        {
            TopBar_Incog.Visibility = Visibility.Visible;
            SetPresence.incognitoMode = true; //Turns incognito on.
            ForceUpdatePresence();
        }

        private void IncognitoCheck_Unchecked(object sender, RoutedEventArgs e)
        {
           TopBar_Incog.Visibility = Visibility.Hidden;
           SetPresence.incognitoMode = false; //Turns incognito off.
           ForceUpdatePresence();
        }

        private void RoS_btn_Click(object sender, RoutedEventArgs e)
        {
            if (bootsAtStartup == false)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue("Omniscient", "\"" + System.Windows.Forms.Application.ExecutablePath + "\"");
                }
                System.Windows.MessageBox.Show("Omniscient will now run on start up. (Only on this user account)", "Omniscient Registery System");
                RoS_btn.Content = "Don't run at startup";
                bootsAtStartup = true;
            } 
            else if (bootsAtStartup == true)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.DeleteValue("Omniscient", false);
                }
                System.Windows.MessageBox.Show("Omniscient will not run on start up.", "Omniscient Registery System");
                RoS_btn.Content = "Run at startup";
                bootsAtStartup = false;
            }
            TickBoxSaver();
        }

        private void Theme_Check_Checked(object sender, RoutedEventArgs e)
        {
            SetPresence.altTheme = true; //Turns the alternative icon theme off.
            ForceUpdatePresence();
        }

        private void Theme_Check_Unchecked(object sender, RoutedEventArgs e)
        {
            SetPresence.altTheme = false; //Turns the alternative icon theme on.
            ForceUpdatePresence();
        }

        private void Blocklist_Check_Unchecked(object sender, RoutedEventArgs e)
        {
            bl_hidden = false;
            BlockedWordsTextBox.Visibility = Visibility.Visible;
            bl_label.Visibility = Visibility.Visible;
        }

        private void Blocklist_Check_Checked(object sender, RoutedEventArgs e)
        {
            bl_hidden = true;
            BlockedWordsTextBox.Visibility = Visibility.Hidden;
            bl_label.Visibility = Visibility.Hidden;
        }
    }
}
