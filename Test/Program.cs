using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                var LocalTime = DateTime.Now.Ticks + 1;

                Console.WriteLine(LocalTime);

                Console.ReadKey();
            } while (true);
        }
    }
}
