﻿using System;
using System.Collections.Generic;
using System.Linq;
using Un4seen.Bass;

namespace console_radio_player
{
    internal static class Player
    {
        private static BASS_CHANNELINFO _channelinfo;
        private static int _stream;
        private static Dictionary<string, string> _stationsLibrary = new Dictionary<string, string>
        {
            {"Radio Roks: Live", @"http://www.radioroks.ua/RadioROKS.m3u"},
            {@"Radio Roks: Hard'n'Heavy", @"http://www.radioroks.ua/RadioROKS_HardnHeavy.m3u" },
            {"Radio Rols: Ballads", "http://www.radioroks.ua/RadioROKS_Ballads.m3u" },
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

        public static int GetStations()
        {
            int i=0;
            Console.WriteLine("\t\t\t\t\t\tLIST OF STATIONS:");
            foreach (var key in _stationsLibrary.Keys)
            {
                i++;
                Console.WriteLine($"\t{i}: \t{key}\n"); 
            }
            return _stationsLibrary.Count;
        }

        public static void PlayStation(int number)
        {

            _stream = Bass.BASS_StreamCreateURL(_stationsLibrary[_stationsLibrary.Keys.ElementAt(number-1)], 0, BASSFlag.BASS_DEFAULT, null,
                IntPtr.Zero);
            if (_stream == 0)
                Console.WriteLine("ERROR: Bad URL or something like that. Can't create stream");
            else
                if (Bass.BASS_ChannelPlay(_stream, false))
                    Console.WriteLine($"Playing {_stationsLibrary.Keys.ElementAt(number - 1)}...");
                else
                    Console.WriteLine("SORRY: Can't play stream");
                
                

        }
        static Player()
        {
            Console.WriteLine(Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero)
                ? "Output device initialized"
                : "OOPS xDDDDD");
            _channelinfo = new BASS_CHANNELINFO();
            _stream = 0;
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_NET_PLAYLIST, 1);

        }

        public  static void ClosePlayer()
        {
            Bass.BASS_Free();
            Console.WriteLine("Resources released");
        }

        public static void GetInfo(int stream)
        {
            Console.WriteLine($"stream handler = {stream}");
            Bass.BASS_ChannelGetInfo(stream, _channelinfo);
            Console.WriteLine($"stream info:\n" +
                              $"sample = {_channelinfo.sample}\n" +
                              $"ctype = {_channelinfo.ctype}\n" +
                              $"channels = {_channelinfo.chans}\n" +
                              $"freq = {_channelinfo.freq}\n" +
                              $"filename = {_channelinfo.filename}\n" +
                              $"flags = {_channelinfo.flags}\n" +
                              $"original resolution = {_channelinfo.origres}\n" +
                              $"plugin = {_channelinfo.plugin}\n");
        }
    }
}
