using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass;

namespace console_radio_player
{
    internal static class Player
    {
        private static BASS_CHANNELINFO _channelinfo = new BASS_CHANNELINFO();

        private static Dictionary<string, string> _stationsLibrary = new Dictionary<string, string>
        {
            {"Radio Roks: Live", @"http://www.radioroks.ua/RadioROKS.m3u"},
            {@"Radio Roks: Hard'n'Heavy", @"http://www.radioroks.ua/RadioROKS_HardnHeavy.m3u" },
            {"Radio Rols: Ballads", @"http://www.radioroks.ua/RadioROKS_Ballads.m3u" },
            {"Radio Roks: Concert", @"http://www.radioroks.ua/RadioROKS_Concert.m3u" },
            {"Radio Roks: ComeTogether [talk show]", @"http://www.radioroks.ua/RadioROKS_KAMTUGEZA.m3u" },
            {"Radio Roks: New Rock" ,@"http://www.radioroks.ua/RadioROKS_NewRock.m3u" },
            {"Radio Roks: Ukrainian Rock", @"http://www.radioroks.ua/RadioROKS_Ukr.m3u" },
            {"Radio Roks: AC/DC", @"http://www.radioroks.ua/RadioROKS_ACDC.m3u" },
            {"Radio Roks: Beatles", @"http://www.radioroks.ua/RadioROKS_Beatles.m3u" },
            {"Radio Roks: Queen" , @"http://online-radioroks2.tavrmedia.ua/RadioROKS_Queen.m3u" },
            {"Radio Roks: Scorpions", @"http://www.radioroks.ua/RadioROKS_Scorpions.m3u" },
            {"Radio Roks: Okean Elzy", @"http://www.radioroks.ua/RadioROKS_Scorpions.m3u" }
            
        };

        public static void GetStations()
        {
            int i=0;
            Console.WriteLine("\t\t\t\t\t\tLIST OF STATIONS:");
            foreach (var key in _stationsLibrary.Keys)
            {
                i++;
                Console.WriteLine($"\t{i}: \t\t{key}"); 
            }
        }
        static Player()
        {
            Console.WriteLine(Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero)
                ? "Output device initialized"
                : "OOPS xDDDDD");
        }
    }
}
