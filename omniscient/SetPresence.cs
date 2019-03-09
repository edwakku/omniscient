using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;

namespace omniscient
{
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
        string curOp = GetWindowTitle.GetCaptionOfActiveWindow();

        public void RPCUpdate()
        {   
            //Browsers
            if (curOp.Contains("Mozilla Firefox")) { det = "Surfing on the internet:"; lik = "firefox"; lit = "Omniscient 1.1b"; }
            else if (curOp.Contains(" - Google Chrome")) { det = "Surfing on the internet:"; lik = "chrome"; lit = "Omniscient 1.1b"; }
            else if (curOp.Contains(" - Internet Explorer")) { det = "Seriously using:"; lik = "iexplore"; lit = "Omniscient 1.1b"; }
            else if (curOp.Contains("Microsoft Edge")) { det = "Surfing on the internet:"; lik = "edge"; lit = "Omniscient 1.1b"; }
            else if (curOp.Contains("Discord")) { det = "Chatting on:"; lik = "discord"; lit = "Omniscient 1.1b"; }
            //Misc.
            else { det = "Currently in app:"; lik = "all_seeing_eye"; lit = "Omniscient 1.1b";  }

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
