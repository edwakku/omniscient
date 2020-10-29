using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;

namespace omniscient
{
    //Sets the Rich Presence
    class SetPresence
    {
        public static DiscordRpcClient client;

        public void Initialize()
        {
            client = new DiscordRpcClient("551862655103664138");
            client.Initialize();
        }

        public static bool blockedWord;
        public static bool incognitoMode;

        public static bool customStatus;
        public static bool customApp;

        public static bool altTheme;

        public static string StatText;
        public static string CustAppText;

        public static string det;
        public static string lik;
        public static string lit;
        public static string app;

        string curOp = GetWindowTitle.GetActiveProcessFileName();
        string curTit = GetWindowTitle.GetFullTitle();

        //Updates the RPC
        public void RPCUpdate()
        {
            lit = "1.5";
            //Browsers
            if (curOp.Contains("firefox")) { det = "Mozilla Firefox"; lik = "firefox"; }
            else if (curOp.Contains("chrome")) { det = "Google Chrome"; lik = "chrome"; }
            else if (curOp.Contains("brave")) { det = "Brave"; lik = "chrome"; }
            else if (curOp.Contains("iexplore")) { det = "Internet Explorer"; lik = "iexplore"; }
            else if (curOp.Contains("msedge")) { det = "Microsoft Edge"; lik = "edge"; }
            else if (curOp.Contains("opera")) { det = "Opera"; lik = "opera"; }
            //Chat
            else if (curOp.Contains("Discord")) { det = "Discord"; lik = "discord"; }
            else if (curOp.Contains("WhatsApp")) { det = "WhatsApp"; lik = "whatsapp"; }
            else if (curOp.Contains("Telegram")) { det = "Telegram"; lik = "telegram"; }
            //Artistic
            else if (curOp.Contains("mspaint")) { det = "Microsoft Paint"; lik = "paint"; }
            else if (curOp.Contains("PaintDotNet")) { det = "paint.net"; lik = "pdn"; }
            else if (curOp.Contains("gimp")) { det = "GIMP"; lik = "gimp"; }
            else if (curOp.Contains("inkscape")) { det = "Inkscape"; lik = "inkscape"; }
            else if (curOp.Contains("Adobe Premiere Pro")) { det = "Adobe Premiere Pro"; lik = "prpro"; }
            else if (curOp.Contains("AfterFX")) { det = "Adobe After Effects"; lik = "aae"; }
            else if (curOp.Contains("Photoshop")) { det = "Adobe Photoshop"; lik = "aps"; }
            else if (curTit.Contains("VEGAS Pro")) { det = "Vegas Pro"; lik = "vegas"; }
            //Gaming
            else if (curOp.Contains("steam")) { det = "Steam"; lik = "steam"; }
            else if (curOp.Contains("Minecraft") || curTit.Contains("Minecraft")) { det = "Playing:"; lik = "minecraft"; }
            //Coding
            else if (curOp.Contains("notepad++")) { det = "Notepad++"; lik = "nplusplus"; }
            else if (curOp.Contains("Unity") || curOp.Contains("Unity Hub")) { det = "Unity"; lik = "unity"; }
            else if (curOp.Contains("devenv")) { det = "Microsoft Visual Studio"; lik = "visualstudio"; }
            //Media Players
            else if (curOp.Contains("vlc")) { det = "VLC Media Player"; lik = "VLC"; }
            else if (curOp.Contains("mpc-hc64")) { det = "Media Player Classic"; lik = "MPC"; }
            else if (curOp.Contains("AIMP")) { det = "AIMP"; lik = "AIMP"; }
            //Misc.
            else if (curOp == "") { det = "Idle"; lik = "desk"; }
            else if (curOp == "explorer" || curOp == "ShellExperienceHost" || curOp == "SearchApp") { det = "Explorer"; lik = "desk"; }
            else if (curOp == "Omniscient") { det = "looking into the void:"; lik = "omni_12"; }
            //Default
            else { det = "Currently in app:"; lik = "no_icon"; }

            app = GetWindowTitle.GetCaptionOfActiveWindow();

            if (customStatus==true)
            {
                det = StatText;
            }
            if (customApp==true)
            {
                app = CustAppText;
            }
            if (blockedWord == true)
            {
                det = "Incognito";
                app = "Version " + lit;
                lik = "blocked";
            }
            if (incognitoMode == true)
            {
                det = "Incognito";
                app = "Version " + lit;
                lik = "blocked";
            }
            if (altTheme != true)
            {
                lik = lik + "_alt";
            }
            
            client.SetPresence(new RichPresence()
                {
                    Details = det,
                    State = app,
                    Assets = new Assets()
                    {
                        LargeImageKey = lik,
                        LargeImageText = "Omniscient " + lit,
                        SmallImageKey = "app_icon_w"
                    }
                });            
        }
    }
}
