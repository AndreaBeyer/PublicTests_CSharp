using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodes_Procedure_ou_Fonction_E1
{
    class Program
    {
        static string sA, sB = "";
        static void Main(string[] args)
        {
            // ~ • ~ //
            Console.Title = "Enoncé 1".ToUpper();
            // ~ • ~ //
            Console.WriteLine(" Veuillez entrer la valeur de a :");
            sA = Console.ReadLine();
            Console.WriteLine("\n Veuillez entrer la valeur de b :");
            sB = Console.ReadLine();
            // ~ • ~ //
            Inverser();
            // ~ • ~ //
            Console.WriteLine("\n \t Désormais a vaut {0} et b vaut {1}.", sA, sB);
            Console.WriteLine("\t (presser une touche pour quitter)");
            Console.ReadKey();
        }
        static void Inverser()
        {
            // ~ • ~ //
            string temp;
            temp = sB;
            sB = sA;
            sA = temp;
        }
    }
}