using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //var myTxtPath = @"C:\Users\ofrometa\source\repos\DS2\ConsoleApp4\students.txt";
            var myTxtPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) +"\\students.txt";
            string line = "";

            using (StreamReader file = new StreamReader(myTxtPath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            Console.ReadLine();
        }
    }
}
