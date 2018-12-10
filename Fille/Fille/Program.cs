using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fille
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime t = new DateTime();
            //t = DateTime.Parse("11/11/2016");
            //Console.WriteLine("{0}",t.DayOfWeek);
            //Console.ReadKey();

            acheterProduits();
            Console.ReadKey();
        }

        static void acheterProduits()
        {
            StreamReader produit = new StreamReader("C:\\data\\produit.csv");
            StreamWriter facture = new StreamWriter("C:\\data\\facture.txt");
            facture.WriteLine("Id  Nom  Prix");
            Console.WriteLine("veuillez saisir un code ");
            string code = Console.ReadLine();

            while (code != "")
            {
                bool trouve = false;
                //produit.DiscardBufferedData();
                char[] c = null;

                c = new char[5];
                produit.Read(c, 0, c.Length);
                Console.WriteLine(c);

                produit.BaseStream.Seek(0, SeekOrigin.Begin);

                Console.WriteLine("To reste {0}",produit.ReadToEnd());
                while (!produit.EndOfStream)
                {
                    string ligne = produit.ReadLine();
                    var champs = ligne.Split(';');
                    if (champs[0] == code)
                    {
                        trouve = true;
                        string lignefacture = champs[0] + "  " + champs[1] + "  " + champs[2];
                        facture.WriteLine(lignefacture);
                        break;
                    }
                }

                if (trouve == false)
                    Console.WriteLine("produit nèxiste pas");

                Console.WriteLine("veuillez saisir un code ");
                code = Console.ReadLine();
            }

            produit.Close();
            facture.Close();

            StreamReader f = new StreamReader("C:\\data\\facture.txt");
            Console.WriteLine(f.ReadToEnd());
            f.Close();
        }
    }
}
