using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodes_Procedure_ou_Fonction_E2
{
    class Program
    {
        static double a, b, c, peri, aire;
        static void Main(string[] args)
        {
            
            Console.Title = "Enonce 2 • Calculs simples sur un triangle".ToUpper();
            Console.WriteLine();

            #region Récupération des longueurs des côtés
            // Récupération des longueurs du triangle
            Console.WriteLine("  Longueur du premier côté: ");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("  Longueur du second côté: ");
            b = double.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("  Longueur du dernier côté: ");
            c = double.Parse(Console.ReadLine());
            Console.WriteLine();
            #endregion

            // Appel de procédure
            Calculs(out peri, out aire);

            // Affichage des données traitées
            Console.WriteLine("  Le périmètre de ce triangle est de {0} cm.", peri);
            Console.WriteLine("  L'aire de ce triangle est de {0} cm².", aire.ToString("##.##"));
            Console.ReadKey();
        }

        static void Calculs(out double pe, out double ai)
        {
            // Calcul du périmètre : longueur coté A + coté B + coté C
            pe = a + b + c;

            // Calcul de l'aire : plus des trucs compliqués
            ai = Math.Sqrt( (pe/2)*(pe/2-a)*(pe/2-b)*(pe/2-c) ); // OU ai = Math.Sqrt( (pe/2-a)*(pe/2-b)*(pe/2-c) )
        }
    }
}
