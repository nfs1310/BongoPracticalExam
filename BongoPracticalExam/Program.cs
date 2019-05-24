using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BongoPracticalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem1 p1 = new Problem1();
            p1.Start();

            Console.WriteLine("\n*********************************************End of Problem 1**************************************************");

            Problem2 p2 = new Problem2();
            p2.Start();

            Console.WriteLine("\n*********************************************End of Problem 2**************************************************");

            Problem3 p3 = new Problem3();
            p3.Start();

            Console.WriteLine("\n*********************************************End of Problem 3**************************************************");

            Console.Read();
        }
    }
}
