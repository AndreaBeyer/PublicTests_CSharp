using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodes_Procedure_ou_Fonction_E3
{
    class Program
    {
        // Declarations
        static double nb1, nb2, moy;

        // Procédure principale
        static void Main(string[] args)
        {
            // Mise en forme
            Console.Title = "Enoncé 3 • Calcul d'une moyenne de deux nombres".ToUpper();
            Console.WriteLine();

            // Récupération des deux nombres
            #region Récupération des deux nombres
            Console.WriteLine("  Nombre 1: ");
            nb1 = double.Parse(Console.ReadLine()); // PEUT ETRE DEVELOPPE
            Console.WriteLine();
            Console.WriteLine("  Nombre 2: ");
            nb2 = double.Parse(Console.ReadLine()); // PEUT ETRE DEVELOPPE
            Console.WriteLine();
            #endregion
            
            // Affichage des données traitées
            Console.WriteLine("  La moyenne de {0} et {1} est {2}.", nb1, nb2, Moyenne(nb1, nb2));
            Console.ReadKey();
        }
        static double Moyenne(double n1, double n2)
        {
            return (n1+n2)/2;
        }
    }
}
