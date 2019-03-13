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

        public static string det;
        public static string lik;
        public static string lit;
        string curOp = GetWindowTitle.GetFullTitle();

        //Updates the RPC
        public void RPCUpdate()
        {
            //Browsers
            if (curOp.Contains("Mozilla Firefox")) { det = "Surfing the internet:"; lik = "firefox"; lit = "Omniscient 1.1"; }
            else if (curOp.Contains(" - Google Chrome")) { det = "Surfing the internet:"; lik = "chrome"; lit = "Omniscient 1.1"; }
            else if (curOp.Contains(" - Internet Explorer")) { det = "Getting viruses:"; lik = "iexplore"; lit = "Omniscient 1.1"; }
            else if (curOp.Contains("Microsoft Edge")) { det = "Surfing the internet:"; lik = "edge"; lit = "Omniscient 1.1"; }
            else if (curOp.Contains("Opera")) { det = "Surfing the web:"; lik = "opera"; lit = "Omniscient 1.1"; }
            //Chat
            else if (curOp.Contains("Discord")) { det = "Chatting on:"; lik = "discord"; lit = "Omniscient 1.1"; }
            else if (curOp.Contains("Skype")) { det = "It wasnt time to ditch:"; lik = "skype"; lit = "Omniscient 1.1"; }
            //Artistic
            else if (curOp.Contains(" - Paint")) { det = "Painting a masterpiece:"; lik = "paint"; lit = "Omniscient 1.1"; }
            else if (curOp.Contains("paint.net")) { det = "Paint.neting a masterpiece:"; lik = "pdn"; lit = "Omniscient 1.1"; }
            else if (curOp.Contains("Inkscape")) { det = "Making vector art:"; lik = "inkscape"; lit = "Omniscient 1.1"; }
            else if (curOp.Contains("Adobe Premiere Pro")) { det = "Editing a video:"; lik = "prpro"; lit = "Omniscient 1.1"; }
            else if (curOp.Contains("Adobe After Effects")) { det = "Creating Effects:"; lik = "aae"; lit = "Omniscient 1.1"; }
            else if (curOp.Contains("VEGAS Pro")) { det = "Editing a video:"; lik = "vegas"; lit = "Omniscient 1.1"; }
            //Coding
            else if (curOp.Contains("Unity 20")) { det = "Making a game:"; lik = "unity"; lit = "Omniscient 1.1"; }
            else if (curOp.Contains("Microsoft Visual Studio")) { det = "Coding:"; lik = "visualstudio"; lit = "Omniscient 1.1"; }
            //Media Players
            else if (curOp.Contains("VLC")) { det = "Media playback:"; lik = "VLC"; lit = "Omniscient 1.1"; }
            //Default
            else { det = "Currently in app:"; lik = "all_seeing_eye"; lit = "Omniscient 1.1";  }

            client.SetPresence(new RichPresence()
            {
                Details = det,
                State = GetWindowTitle.GetCaptionOfActiveWindow(),
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
