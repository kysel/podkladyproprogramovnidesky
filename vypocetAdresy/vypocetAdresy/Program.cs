using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vypocetAdresy
{
    class Program
    {
        static void Main(string[] args)
        {
            long o=0;
            while (true)
            {
                /*int adresa;
                byte data;
                
                string troll;
                troll = Console.ReadLine();
                adresa = Convert.ToInt32(troll);
                troll = Console.ReadLine();
                data = Convert.ToByte(troll);
                if (data == 0)
                    o = 0;

                o |= (long)data << (adresa % 8);

                Console.WriteLine(Convert.ToString(o,2));*/

                int adresa = 0;
                string troll;
                troll = Console.ReadLine();
                adresa = Convert.ToInt32(troll);
                Console.WriteLine(((adresa % 8) << 2 | (adresa / 8) << 5) & 0xfc);
                Console.Write("přepočet pro 8: ");
                Console.WriteLine((7 - (adresa % 8)) + (adresa / 8) * 8);
                Console.Write("přepočet pro 4: ");
                Console.WriteLine((3 - (adresa % 4)) + (adresa / 4) * 4);

            }

            
        }
    }
}

