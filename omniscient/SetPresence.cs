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
            if (curOp.Contains("firefox")) { det = "Firefox"; lik = "firefox"; }
            else if (curOp.Contains("chrome")) { det = "Chrome"; lik = "chrome"; }
            else if (curOp.Contains("brave")) { det = "Brave"; lik = "brave"; }
            else if (curOp.Contains("iexplore")) { det = "Internet Explorer"; lik = "iexplore"; }
            else if (curOp.Contains("msedge")) { det = "Microsoft Edge"; lik = "edge"; }
            else if (curOp.Contains("opera")) { det = "Opera"; lik = "opera"; }
            //Chat
            else if (curOp.Contains("Discord")) { det = "Discord"; lik = "discord"; }
            else if (curOp.Contains("WhatsApp")) { det = "WhatsApp"; lik = "whatsapp"; }
            else if (curOp.Contains("Telegram")) { det = "Telegram"; lik = "telegram"; }
            else if (curOp.Contains("Zoom")) { det = "Zoom"; lik = "zoom"; }
            else if (curOp.Contains("Teams")) { det = "Microsoft Teams"; lik = "msteams"; }
            //Artistic
            else if (curOp.Contains("mspaint")) { det = "Microsoft Paint"; lik = "paint"; }
            else if (curOp.Contains("PaintDotNet")) { det = "paint.net"; lik = "pdn"; }
            else if (curOp.Contains("gimp")) { det = "GIMP"; lik = "gimp"; }
            else if (curOp.Contains("inkscape")) { det = "Inkscape"; lik = "inkscape"; }
            else if (curOp.Contains("Adobe Premiere Pro")) { det = "Adobe Premiere Pro"; lik = "prpro"; }
            else if (curOp.Contains("AfterFX")) { det = "Adobe After Effects"; lik = "aae"; }
            else if (curOp.Contains("VideoEditor") || curTit.Contains("VSDC")) { det = "VSDC Video Editor"; lik = "vsdc"; }
            else if (curOp.Contains("Photoshop")) { det = "Adobe Photoshop"; lik = "aps"; }
            else if (curTit.Contains("VEGAS Pro")) { det = "Vegas Pro"; lik = "vegas"; }
            //Gaming
            else if (curOp.Contains("steam")) { det = "Steam"; lik = "steam"; }
            else if (curOp.Contains("Minecraft") || curTit.Contains("Minecraft")) { det = "Playing:"; lik = "minecraft"; }
            //Coding
            else if (curOp.Contains("notepad++")) { det = "Notepad++"; lik = "nplusplus"; }
            else if (curOp.Contains("Unity") || curOp.Contains("Unity Hub")) { det = "Unity"; lik = "unity"; }
            else if (curOp.Contains("devenv")) { det = "Microsoft Visual Studio"; lik = "visualstudio"; }
            else if (curOp.Contains("Code") && curTit.Contains("Visual Studio Code")) { det = "Visual Studio Code"; lik = "vscode"; }
            //Media Players
            else if (curOp.Contains("vlc")) { det = "VLC Media Player"; lik = "vlc"; }
            else if (curOp.Contains("mpc-hc64")) { det = "Media Player Classic"; lik = "mpc"; }
            else if (curOp.Contains("AIMP")) { det = "AIMP"; lik = "AIMP"; }
            //Misc.
            else if (curOp == "") { det = "Idle"; lik = "desk"; }
            else if (curOp == "explorer" || curOp == "ShellExperienceHost" || curOp == "SearchApp") { det = "Explorer"; lik = "explorer"; }
            else if (curTit == "Calculator" && curOp == "ApplicationFrameHost") { det = "Calculator"; lik = "calc"; }
            else if (curTit == "Groove Music" && curOp == "ApplicationFrameHost") { det = "Grooving to some music:"; lik = "groove"; }
            else if (curOp == "Omniscient") { det = "looking into the void:"; lik = "omni_icon"; }
            //Default
            else { det = "Currently in app:"; lik = "no_icon"; }

            app = GetWindowTitle.GetCaptionOfActiveWindow();
            if (det == app)
            {
                app = "";
            }
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
                app = "";
                lik = "blocked";
            }
            if (incognitoMode == true)
            {
                det = "Incognito";
                app = "";
                lik = "blocked";
            }
            if (altTheme == true)
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
