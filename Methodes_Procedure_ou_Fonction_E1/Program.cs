using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodes_Procedure_ou_Fonction_E1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inverser deux variables par une procédure ayant des paramètres sortants (passage de valeur par référence) //
            Console.Title = "Enoncé 1".ToUpper();
            // ~ • ~ //
            Console.WriteLine(" Veuillez entrer la valeur de a :");
            string sA = Console.ReadLine();
            Console.WriteLine("\n Veuillez entrer la valeur de b :");
            string sB = Console.ReadLine();
            // ~ • ~ //
            Inverser(ref sA, ref sB);
            // ~ • ~ //
            Console.WriteLine("\n \t Désormais a vaut {0} et b vaut {1}.", sA, sB);
            Console.WriteLine("\t (presser une touche pour quitter)");
            Console.ReadKey();
        }
        static void Inverser(ref string a, ref string b)
        {
            // ~ • ~ //
            string temp;
            temp = b;
            b = a;
            a = temp;
        }
    }
}