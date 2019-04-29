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

        public static bool customStatus;
        public static bool customApp;

        public static string StatText;
        public static string CustAppText;

        public static string det;
        public static string lik;
        public static string lit;
        public static string app;

        string curOp = GetWindowTitle.GetFullTitle();

        //Updates the RPC
        public void RPCUpdate()
        {
            lit = "Omniscient 1.3";
            //Browsers
            if (curOp.Contains("Mozilla Firefox")) { det = "Surfing the internet:"; lik = "firefox"; }
            else if (curOp.Contains("Firefox Developer Edition")) { det = "Surfing the internet:"; lik = "ffdev"; }
            else if (curOp.Contains("Firefox Nightly")) { det = "Surfing the internet:"; lik = "ffnightly"; }
            else if (curOp.Contains("Google Chrome")) { det = "Surfing the internet:"; lik = "chrome"; }
            else if (curOp.Contains("Internet Explorer")) { det = "Getting viruses:"; lik = "iexplore"; }
            else if (curOp.Contains("Microsoft Edge")) { det = "Surfing the internet:"; lik = "edge"; }
            else if (curOp.Contains("Opera")) { det = "Surfing the web:"; lik = "opera"; }
            //Chat
            else if (curOp.Contains("Discord")) { det = "Chatting on:"; lik = "discord"; }
            else if (curOp.Contains("Skype")) { det = "It wasnt time to ditch:"; lik = "skype"; }
            else if (curOp.Contains("WhatsApp")) { det = "Chatting on:"; lik = "whatsapp"; }
            else if (curOp.Contains("Telegram")) { det = "Chatting on:"; lik = "telegram"; }
            //Artistic
            else if (curOp.Contains(" - Paint")) { det = "Painting a masterpiece:"; lik = "paint"; }
            else if (curOp.Contains("paint.net")) { det = "Paint.neting a masterpiece:"; lik = "pdn"; }
            else if (curOp.Contains("GIMP")) { det = "Making a masterpiece:"; lik = "gimp"; }
            else if (curOp.Contains("Inkscape")) { det = "Making vector art:"; lik = "inkscape"; }
            else if (curOp.Contains("Adobe Premiere Pro")) { det = "Editing a video:"; lik = "prpro"; }
            else if (curOp.Contains("Adobe After Effects")) { det = "Creating Effects:"; lik = "aae"; }
            else if (curOp.Contains("VEGAS Pro")) { det = "Editing a video:"; lik = "vegas"; }
            //Gaming
            else if (curOp.Contains("Steam")) { det = "Browsing:"; lik = "steam"; }
            //Coding
            else if (curOp.Contains("Notepad++")) { det = "Writing:"; lik = "nplusplus"; }
            else if (curOp.Contains("Unity 20")) { det = "Making a game:"; lik = "unity"; }
            else if (curOp.Contains("Microsoft Visual Studio")) { det = "Coding:"; lik = "visualstudio"; }
            //Media Players
            else if (curOp.Contains("VLC")) { det = "Media playback:"; lik = "VLC"; }
            //Misc.
            else if (curOp == "") { det = "Idle"; lik = "desk"; }
            else if (curOp == "Program Manager") { det = "Idle"; lik = "desk"; }
            else if (curOp == lit ) { det = "looking into the void:"; lik = "omni_12"; }
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
                client.SetPresence(new RichPresence()
                {
                    Details = det,
                    State = app,
                    Assets = new Assets()
                    {
                        LargeImageKey = lik,
                        LargeImageText = lit,
                        SmallImageKey = "app_icon_w"
                    }
                });            
        }
    }
}
