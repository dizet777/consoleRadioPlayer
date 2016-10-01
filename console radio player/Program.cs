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
            int count = Player.GetStations();
            Console.WriteLine("enter #");
            int n = int.Parse(Console.ReadLine());
            if (n>=count)
                Console.WriteLine("wrong choice");
            else
            {
                Player.PlayStation(n);
                Player.GetInfo(n);
            }
           
            Console.ReadLine();
            Player.ClosePlayer();
        }
    }
}
