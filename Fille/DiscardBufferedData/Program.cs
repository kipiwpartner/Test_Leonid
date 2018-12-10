using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscardBufferedData
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\data\alphabet.txt";

            using (StreamReader sr = new StreamReader(path))
            {
                char[] c = null;

                c = new char[15];
                sr.Read(c, 0, c.Length);
                Console.WriteLine("first 15 characters:");
                Console.WriteLine(c);
                // writes - "abcdefghijklmno"

                //sr.DiscardBufferedData();
                sr.BaseStream.Seek(2, SeekOrigin.Begin);
                sr.BaseStream.Seek(4, SeekOrigin.Begin);
                Console.WriteLine("\nBack to offset 2 and read to end: ");
                Console.WriteLine(sr.ReadToEnd());
                // writes - "cdefghijklmnopqrstuvwxyz"
                // without DiscardBufferedData, writes - "pqrstuvwxyzcdefghijklmnopqrstuvwxyz"
            }

            Console.ReadKey();
        }
    }
}
