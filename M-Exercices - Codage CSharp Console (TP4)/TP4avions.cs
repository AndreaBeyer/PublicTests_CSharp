using System;

namespace M_Exercices___Algorithmie___Codage__TP4_
{
    class Program
    {

        /*
         BUG ligne 46 (index hors des limites du tableau)
         */

        // Déclarations publiques
        static string saisie;
        static int iAvion;
        static object[,] tAvions = new object[4, 6] {
        { "BOING747", "AIRBUSA380", "LEARJET45", "DC10", "CONCORDE", "ANTONOV32" },
        { "B0", "AB", "LJ", "DC", "CO", "AN" },
        { 800, 950, 700, 900, 1400, 560 },
        { 10000, 12000, 4500, 8000, 16000, 2500 }
        };

        static void Main(string[] args)
        {
            ConsoleKey s1 = ConsoleKey.O;
            ConsoleKey s2 = ConsoleKey.N;
            bool numAvionValide = false;

            // Faire ce qui suit
            do
            {
                do
                {
                    // Recupération saisie = Gestion basique d'erreur
                    Console.WriteLine("Entrez le code avion : ");
                    saisie = Console.ReadLine();

                    // Recherche du code de l'avion dans le tableau
                    int i = 0;
                    // Tant que l'index qui parcourt le tableau n'excède pas les limites du tableau 
                    // et que dans sa deuxième colonne on ne trouve pas de champs correspondant à la saisie utilisateur,
                    while (i < tAvions.GetLength(1) && (tAvions[1, i].ToString()) != saisie)
                    {
                        i++;
                    }
                    // Si on est sorti de la boucle parce qu'on a trouvé un champs correspondant à la saisie utilisateur,
                    if (i >= tAvions.GetLength(1))
                    {
                        // Récupérer la position de l'index dans une varaible statique "iAvion"
                        iAvion = i;
                        numAvionValide = true;
                    }
                    // Si on est sorti de la boucle parce que l'index à fini de parcourir toutes les lignes du tableau
                    else
                    {
                        // En informer l'utilisateur
                        Console.WriteLine("Cet avion n'existe pas" + Environment.NewLine);
                    }
                    // Tant que rien n'a été récupéré dans la varaible statique "iAvion"
                } while (!numAvionValide); // Sécurité douteuse.

                // Recherche et affichage des données correspondantes
                Console.WriteLine( Environment.NewLine +
                    "Avion: {0} " + Environment.NewLine +
                    "Vitesse: {1}km/h " + Environment.NewLine +
                    "Rayon: {2}km", tAvions[0,iAvion], tAvions[2,iAvion], tAvions[3,iAvion]);
                  
                // Proposition d'affichage des données complémentaires
                Console.WriteLine(Environment.NewLine + 
                    "Voulez-vous éditer les statitstiques (O/N) ♪");
                s2 = Console.ReadKey().Key;
                Console.WriteLine();
                Console.WriteLine();

                if (s2 == ConsoleKey.O)
                {
                    // Recherche de l'avion le plus rapide (Recherche de la valeur la plus grande dans le tableau tAvions)
                    uint vitesseMax = 0;
                    for (uint index1 = 0; index1 < tAvions.GetLength(2); index1++)
                    {
                        if ((uint)tAvions[2,index1] > (uint)tAvions[2,vitesseMax])
                        {
                            vitesseMax = index1;
                        }
                    }
                    Console.WriteLine(
                        "L'avion qui vole le plus vite est le {0} à {1} km/h.", 
                        tAvions[0,vitesseMax], tAvions[2,vitesseMax]);

                    // Calcul de la moyenne des rayons d'action
                    double moyenneRayons = 0;
                    for (uint index2 = 0; index2 < tAvions.GetLength(3)-1; index2++)
                    {
                        moyenneRayons += (double)tAvions[3,index2];
                    }
                    moyenneRayons = moyenneRayons/tAvions.GetLength(3);

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
