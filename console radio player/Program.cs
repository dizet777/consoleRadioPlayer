using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace console_radio_player
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Console Radio Player";
            int n;
            Console.WriteLine(@"Hello
    L - list stations
    P - play station
    Q - quit");
//            Thread bgroundThread = new Thread(new ThreadStart(Player.DisplayInfoInConsoleTitle));
//            bgroundThread.IsBackground = true;
//            bgroundThread.Start();
            do
            {
                string input = Console.ReadLine();
                if (input.ToLower()=="q")
                {
                    Player.ClosePlayer();
                    break;
                }
                else if (int.TryParse(input, out n))
                {
                    Player.PlayStation(n);
                }
                else
                    switch (input.ToLower())
                {
                    case "l":
                        Player.GetStations();
                        break;
                    case "p":
                        Console.WriteLine("enter the number");
                        if(int.TryParse(Console.ReadLine(), out n))
                            Player.PlayStation(n);
                        break;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            } while (true);

        }

//        static void UpdateInfo()
//        {
//            Task.Factory.StartNew(() =>
//            {
//                Player.DisplayInfoInConsoleTitle();
//            });
//        }
    }
}
