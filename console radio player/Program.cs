using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace console_radio_player
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine(@"Hello
l - list stations
p - play station
q- quit");
            do
            {
                string input = Console.ReadLine();
                if (input.ToLower()=="q")
                {
                    Player.ClosePlayer();
                    break;

                }
                switch (input.ToLower())
                {
                    case "l":
                        Player.GetStations();
                        break;
                    case "p":
                        Console.WriteLine("enter the number");
                        int n;
                        int.TryParse(Console.ReadLine(), out n);
                        if (n!=0)
                        {
                            Player.PlayStation(n);
                        }
                        break;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            } while (true);

     
        }
    }
}
