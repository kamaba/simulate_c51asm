using SimpleAsm.Parse;
using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var fp = new FileParse("1.txt");

            fp.StructParse();
        }
    }
}
