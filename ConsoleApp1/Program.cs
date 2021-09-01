using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BIENVENIDO A DESARROLLO DE SOFTWARE II");
            Console.WriteLine("");

            Console.WriteLine("DIGITA EL PRIMER NUMERO"); 
            string line1 = Console.ReadLine();

            Console.WriteLine("DIGITA EL SEGUNDO NUMERO");
            string line2 = Console.ReadLine();

            Console.WriteLine($"EL RESULTADO ES: {(Convert.ToInt32(line1) + Convert.ToInt32(line2))}");

            Console.ReadLine();
        }
    }
}
