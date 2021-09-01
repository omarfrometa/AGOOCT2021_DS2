using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var startDate = DateTime.Now;
            var finishDate = DateTime.Now;
            Console.WriteLine($"INICIO: {startDate.ToString("F")}");

            DS2Entities db = new DS2Entities();
            var students = db.Student.ToList();
            foreach (Student student in students)
            {
                Console.WriteLine($"Matricula: {student.Enrollment} | Nombre: {student.FirstName} {student.LastName} | Email: {student.Email}");
            }
            finishDate = DateTime.Now;

            Console.WriteLine($"FINAL: {finishDate.ToString("F")}");
            Console.WriteLine($"DIFERENCIA: {(finishDate - startDate).Milliseconds}");

            Console.ReadLine();
        }
    }
}