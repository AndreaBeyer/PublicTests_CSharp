using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Exercices___Algorithmie___Codage__TP3_
{
    class Program
    {
        static string saisie;
        static void Main(string[] args)
        {
            uint depart, arrivee, pas;
            ConsoleKey s = ConsoleKey.N;

            /* Il semble y avoir une faute dans l'orthographe du mot "fareinheit" (normalement "fahrenheit"). */
            Console.Title = " 3 • Conversion de degrés celsius en degrés fareinheit".ToUpper();
            Console.WriteLine();
            
            do
            {
                do
                {
                    // Récupération de la saisie de la valeur de départ
                    Console.WriteLine("A partir de : ");
                    saisie = Console.ReadLine();
                    while (!uint.TryParse(saisie, out depart))
                    {
                        Console.WriteLine("Votre saisie n'est pas valide.");
                        Console.WriteLine("A partir de : ");
                        saisie = Console.ReadLine();
                        Console.WriteLine();
                    }

                    // Récupération de la saisie de la valeur d'arrivée
                    Console.WriteLine("Jusqu'à : ");
                    saisie = Console.ReadLine();
                    while (!uint.TryParse(saisie, out arrivee))
                    {
                        Console.WriteLine("Votre saisie n'est pas valide.");
                        Console.WriteLine("Jusqu'à : ");
                        saisie = Console.ReadLine();
                        Console.WriteLine();
                    }

                    // Récupération de la saisie du pas de décompte
                    Console.WriteLine("Par pas de : ");
                    saisie = Console.ReadLine();
                    while (!uint.TryParse(saisie, out pas))
                    {
                        Console.WriteLine("Votre saisie n'est pas valide.");
                        Console.WriteLine("Par pas de : ");
                        saisie = Console.ReadLine();
                        Console.WriteLine();
                    }

                    // Confirmation liée au contexte réel du TP
                    Console.WriteLine(Environment.NewLine + "Assurez-vous que l'imprimante est prête");
                    Console.WriteLine(Environment.NewLine + "Si vous êtes sûr des bornes tapez 'O' : ");
                    s = Console.ReadKey().Key;
                    Console.WriteLine();
                    while (s != ConsoleKey.O && s != ConsoleKey.N)
                    {
                        Console.WriteLine("Votre saisie n'est pas valide.");
                        Console.WriteLine("Si vous êtes sûr des bornes tapez 'O' : ");
                        s = Console.ReadKey().Key;
                        Console.WriteLine();
                    }
                }
                while (s != ConsoleKey.O);
                Console.WriteLine();
    
                Console.WriteLine("Table de conversion de degrés Celsius en degrés Fareinheit" + Environment.NewLine);
                Console.WriteLine("Celsius\tFarenheit" + Environment.NewLine);
                
                for (uint celsius = depart; celsius <= arrivee; celsius+=pas)
                {
                    double fahrenheit = celsius * 1.80 + 32.00;
                    Console.WriteLine(
                        celsius.ToString("#") + "\t" + fahrenheit.ToString("#.#") + 
                        Environment.NewLine);
                }

                Console.WriteLine("Souhaitez-vous éditer une autre table (O/N)");
                s = Console.ReadKey().Key;
                Console.Clear();
                while (s != ConsoleKey.O && s != ConsoleKey.N)
                {
                    Console.WriteLine("Votre saisie n'est pas valide.");
                    Console.WriteLine("Souhaitez-vous éditer une autre table (O/N)");
                    s = Console.ReadKey().Key;
                    Console.WriteLine();
                }
            }
            while (s == ConsoleKey.O);
        }
    }
}