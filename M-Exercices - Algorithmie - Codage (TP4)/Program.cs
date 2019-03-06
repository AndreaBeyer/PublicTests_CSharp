using System;
using System.Linq;

namespace M_Exercices___Algorithmie___Codage__TP4_
{
    class Program
    {
        /* static string[,] tAvions = new string[2, 6] {
            { "BOING747", "AIRBUSA380", "LEARJET45", "DC10", "CONCORDE", "ANTONOV32" },
            { "B0", "AB", "LJ", "DC", "CO", "AN" }
        }; */
        static string[] t1Nom = new string[] { "BOING747", "AIRBUSA380", "LEARJET45", "DC10", "CONCORDE", "ANTONOV32" };
        static string[] t2Code = new string[] { "B0", "AB", "LJ", "DC", "CO", "AN" };

        static uint[] t3Vitesse = new uint[] { 800, 950, 700, 900, 1400, 560 };

        static uint[] t4Rayon = new uint[] { 10000, 12000, 4500, 8000, 16000, 2500 };

        static string saisie;
        
        static void Main(string[] args)
        {
            ConsoleKey s1 = ConsoleKey.O;
            ConsoleKey s2 = ConsoleKey.N;

            do
            {
                // Recherche du code de l'avion dans le tableau 2:

                // Recupération saisie et gestion basique d'erreur
                do
                {
                    Console.WriteLine("Entrez le code avion : ");
                    saisie = Console.ReadLine();
                    if (!t2Code.Contains(saisie))
                    {
                        Console.WriteLine("Cet avion n'existe pas" + Environment.NewLine);
                    }
                }
                while (!t2Code.Contains(saisie));
                // Recherche et affichage des données correspondantes
                int avion = Array.IndexOf(t2Code, saisie);
                Console.WriteLine( Environment.NewLine +
                    "Avion: {0} " + Environment.NewLine +
                    "Vitesse: {1}km/h " + Environment.NewLine +
                    "Rayon: {2}km", t1Nom[avion], t3Vitesse[avion], t4Rayon[avion]);

                // Proposition d'affichage des données complémentaires
                Console.WriteLine(Environment.NewLine + 
                    "Voulez-vous éditer les statitstiques (O/N) ♪");
                s2 = Console.ReadKey().Key;
                Console.WriteLine();
                Console.WriteLine();

                if (s2 == ConsoleKey.O)
                {
                    // Recherche de l'avion le plus rapide (Recherche de la valeur la plus grande dans le tableau t3Vitesse)
                    uint vitesseMax = 0;
                    for (uint index1 = 0; index1 < t3Vitesse.Length; index1++)
                    {
                        if (t3Vitesse[index1] > t3Vitesse[vitesseMax])
                        {
                            vitesseMax = index1;
                        }
                    }
                    Console.WriteLine(
                        "L'avion qui vole le plus vite est le {0} à {1} km/h.", 
                        t1Nom[vitesseMax], t3Vitesse[vitesseMax]);

                    // Calcul de la moyenne des rayons d'action
                    double moyenneRayons = 0;
                    for (uint index2 = 0; index2 < t4Rayon.Length-1; index2++)
                    {
                        moyenneRayons += t4Rayon[index2];
                    }
                    moyenneRayons = moyenneRayons/t4Rayon.Length;

                    Console.WriteLine(
                        "La moyenne des rayons d'action est de {0} km.",
                        moyenneRayons.ToString("##,##"));
                }

                // Avez-vous terminer, ou voulez-vous recommencer
                Console.WriteLine(
                    Environment.NewLine + 
                    "\t Voulez-vous faire une autre recherche (O/N)");
                s1 = Console.ReadKey().Key;
                Console.WriteLine();
                Console.WriteLine();
                if (s1 == ConsoleKey.O)
                {
                    Console.Clear();
                }
            }
            while (s1 == ConsoleKey.O);
            Console.WriteLine("\t Au revoir et à bientôt " + Environment.NewLine + "\t (presser une touche...)");
            Console.ReadKey();
        }
    }
}
