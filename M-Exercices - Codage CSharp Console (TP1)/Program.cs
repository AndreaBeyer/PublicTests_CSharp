using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Exercices___Algorithmie___Codage_TP1_
{
    class Program
    {
        static string saisie;
        static double rayon, circonference, surface;
        static void Main(string[] args)
        {
            ConsoleKey s = ConsoleKey.O;

            do
            {
                Console.Title = " 1 • Calcul d'un cercle".ToUpper();

                do
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Quel est le rayon du cercle ");
                    saisie = Console.ReadLine();
                    if (!double.TryParse(saisie, out rayon))
                    {
                        Console.WriteLine("\t\b\b Votre saisie n'est pas valide.");
                        Console.WriteLine("Quel est le rayon du cercle ");
                        saisie = Console.ReadLine();
                        Console.WriteLine(Environment.NewLine);
                    }
                }
                while (!double.TryParse(saisie, out rayon));

                // Calcul de la circonference et de la surface :
                circonference = Math.PI*(rayon*2) ;
                surface = Math.PI*Math.Pow(rayon,2);

                // Affichage du résultat : 
                    /* Limite: La valeur de la surface ne s'affiche pas jusqu'au cinquieme chiffre après la virgule ? */
                Console.WriteLine(
                    Environment.NewLine + 
                    "Sa circonference est de : " + circonference.ToString("##.#####") +
                    Environment.NewLine +
                    "Sa surface est de : " + surface.ToString("##.#####") + 
                    Environment.NewLine +
                    Environment.NewLine +
                    "\t\b\b Voulez-vous faire une autre calcul (O/N) ");
                s = Console.ReadKey().Key;
                Console.WriteLine(Environment.NewLine);
                while (s != ConsoleKey.N && s != ConsoleKey.O)
                {
                    Console.WriteLine("\t\b\b Votre saisie n'est pas valide.");
                    Console.WriteLine("\t\b\b Voulez-vous faire une autre calcul (O/N)");
                    s = Console.ReadKey().Key;
                    Console.WriteLine(Environment.NewLine);
                }
            }
            while (s != ConsoleKey.N);

            Console.WriteLine("\t\b\b Au revoir et à bientôt !");
            Console.ReadKey();
        }
    }
}
