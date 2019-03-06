using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Exercices___Algorithmie___Codage_TP2_
{
    class Program
    {
        // Déclaration globales
        static readonly double PI = Math.PI;
        static string saisie;
        static double a, b, c, d, x1, x2;
        static void Main(string[] args)
        {
            // Déclaration locales
            ConsoleKey s = ConsoleKey.O;

            // Configuration de la console
            Console.Title = "Racine de l'équation du 2ème degré".ToUpper();
            Console.WriteLine("y = ax² + bx + c" + Environment.NewLine);
            
            do
            {
                do
                {
                    Console.Clear();

                    // Récupération des données de l'utilisateur
                    Console.WriteLine("Quel est la valeur de a ");
                    saisie = Console.ReadLine();
                    while (!double.TryParse(saisie, out a))
                    {
                        Console.WriteLine("Votre saisie n'est pas valide.");
                        Console.WriteLine(Environment.NewLine + "Quel est la valeur de a ");
                        saisie = Console.ReadLine();
                    }
                    Console.WriteLine("Quel est la valeur de b ");
                    saisie = Console.ReadLine();
                    while (!double.TryParse(saisie, out b))
                    {
                        Console.WriteLine("Votre saisie n'est pas valide.");
                        Console.WriteLine(Environment.NewLine + "Quel est la valeur de b ");
                        saisie = Console.ReadLine();
                    }
                    Console.WriteLine("Quel est la valeur de c ");
                    saisie = Console.ReadLine();
                    while (!double.TryParse(saisie, out c))
                    {
                        Console.WriteLine("Votre saisie n'est pas valide.");
                        Console.WriteLine(Environment.NewLine + "Quel est la valeur de c ");
                        saisie = Console.ReadLine();
                    }

                    if (a == 1 && b == 1 && c == 1)
                    {
                        Console.WriteLine("L'équation n'en est pas une !!!");
                    }
                }
                while (Math.Abs(a) < 1 && Math.Abs(b) < 1 && Math.Abs(c) < 1);

                // Calcul du déterminant de l'équation y = ax² + bx + c:
                d = b*2-4*a*c;
                if (d<0)
                {
                    // Aucune solution possible
                    Console.WriteLine("L'équation ne possède pas de racine réelle : d = " + d.ToString("##.##") + Environment.NewLine);
                }
                else if (d==0)
                {
                    // Calcul des solution possibles x1 et x2: 
                    x1 = x2 = -(b / 2 * a);
                    Console.WriteLine("L'équation possède une racine double : d = " + d.ToString("##.##") + Environment.NewLine +
                    "L'équation s'annule pour x1 = x2 = " + x1 + Environment.NewLine);
                }
                else if (d>0)
                {
                    // Calcul des solution possibles x1 et x2: 
                    x1 = (-b + Math.Sqrt(d)) / 2 * a;
                    x2 = (-b - Math.Sqrt(d)) / 2 * a;
                    Console.WriteLine(
                        "L'équation possède deux racines distinctes : d = " + d.ToString("##.##") + Environment.NewLine + 
                        "L'équation s'annule pour : x1 = " + x1.ToString("##.##") + Environment.NewLine + 
                        "et : x2 = " + x2.ToString("##.##") + Environment.NewLine );
                }
                // Petite décharge quant aux résultats des calculs:
                Console.WriteLine("NB: Calculs effectués selon les formules donnée dans l'énoncé: " + 
                    "\r\n delta=b2-4ac" +
                    "\r\n Si delta=0,     x1=x2=-(b/2a)" +
                    "\r\n Si delta>0,     x1=(-b+racine de delda)/2a \t x2=(-b-racine de delta)/2a)\r\n");

                Console.WriteLine("Voulez-vous faire une autre calcul (O/N) ");
                s = Console.ReadKey().Key;
                Console.WriteLine(Environment.NewLine);
                while (s != ConsoleKey.N && s != ConsoleKey.O)
                {
                    Console.WriteLine("Votre saisie n'est pas valide.");
                    Console.WriteLine(Environment.NewLine + "Voulez-vous faire une autre calcul (O/N)");
                    s = Console.ReadKey().Key;
                    Console.WriteLine(Environment.NewLine);
                }
            }
            while (s != ConsoleKey.N);
            Console.WriteLine("Au revoir et à bientôt !");
            Console.ReadKey();
        }
    }
}
