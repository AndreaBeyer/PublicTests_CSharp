using System;

namespace M_Exercices___Algorithmie___Codage__TP4_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Déclarations dont les valeurs seront accessibles dans toute la fonction principale
            object[,] tAvions = new object[4, 6] {
                { "BOING747", "AIRBUSA380", "LEARJET45", "DC10", "CONCORDE", "ANTONOV32" },
                { "B0", "AB", "LJ", "DC", "CO", "AN" },
                { 800d, 950d, 700d, 900d, 1400d, 560d },
                { 10000d, 12000d, 4500d, 8000d, 16000d, 2500d }
                };
            // attention au typage 
            // ne pas essayer de gerer les exceptions (ne pas faire d'exception!) cela ralenti le traitement
            // le break ralenti énormément le traitement
            int iAvion = 0;
            string saisie = "";

            ConsoleKey s1, s2;

            s1 = ConsoleKey.O;

            Console.Title = " 4 • Statistiques Avions".ToUpper();

            // Faire ce qui suit au moins une fois
            do
            {
                bool numAvionValide = false;
                // Faire ce qui suit au moins une fois
                do
                {
                    // Récupération de la saisie utilisateur
                    Console.WriteLine("Entrez le code avion : ");
                    saisie = Console.ReadLine();

                    // Tant que l'index qui parcourt le tableau n'excède pas les limites du tableau,
                    int i = 0;
                    while (i < tAvions.GetLength(1) && tAvions[1, i].ToString() != saisie)
                    {
                        // Si on trouve une cellule dont le contenu correspond exactement à la saisie utilisateur,
                        i++;
                    }
                    if (i != tAvions.GetLength(1))
                    {
                        // Récupérer la position de l'index dans une varaible statique "iAvion"
                        iAvion = i;
                        // Indiquer qu'on a trouvé une cellule de contenu similaire
                        numAvionValide = true;
                    }

                    // Maintenant que le tableau a été parcouru en entier, si on n'a pas trouvé de cellule au contenu similaire,
                    if (!numAvionValide)
                    {
                        // En informer l'utilisateur
                        Console.WriteLine("Cet avion n'existe pas" + Environment.NewLine);
                    }
                }
                // Tant qu'on n'a pas trouvé de cellule dont le contenu correspond à la saisie utilisateur, 
                // Recommencer tout ceci
                while (!numAvionValide);

                // Recherche et affichage des données correspondantes
                Console.WriteLine(Environment.NewLine +
                    "Avion: {0} " + Environment.NewLine +
                    "Vitesse: {1} km/h " + Environment.NewLine +
                    "Rayon: {2} km", tAvions[0, iAvion], tAvions[2, iAvion], tAvions[3, iAvion]);

                // Proposition d'affichage des données complémentaires
                Console.WriteLine(Environment.NewLine +
                    "Voulez-vous éditer les statitstiques (O/N) ♪");

                // Récupération de la saisie utilisateur
                s2 = Console.ReadKey().Key;
                Console.WriteLine();
                Console.WriteLine();

                // Si saisie <=> OUI
                if (s2 == ConsoleKey.O)
                {
                    // Recherche de l'avion le plus rapide (Recherche de la valeur la plus grande dans le tableau tAvions)
                    int indexVitesseMax = 0;
                    for (int index1 = 0; index1 < tAvions.GetLength(1); index1++)
                    {
                        if ((double)tAvions[2, index1] > (double)tAvions[2, indexVitesseMax])
                        {
                            indexVitesseMax = index1;
                        }
                    }
                    Console.WriteLine(
                        "L'avion qui vole le plus vite est le {0} à {1} km/h.",
                        tAvions[0, indexVitesseMax], tAvions[2, indexVitesseMax]);

                    // Calcul de la moyenne des rayons d'action
                    double moyenneRayons = 0;
                    for (int index2 = 0; index2 < tAvions.GetLength(1) - 1; index2++)
                    {
                        moyenneRayons += (double)tAvions[3, index2];
                    }
                    moyenneRayons = moyenneRayons / tAvions.GetLength(1);

                    Console.WriteLine(
                        "La moyenne des rayons d'action est de {0} km.",
                        moyenneRayons.ToString("##,##"));
                }

                // Avez-vous terminer, ou voulez-vous recommencer ?
                Console.WriteLine(
                    Environment.NewLine +
                    "\t Voulez-vous faire une autre recherche (O/N)");

                // Récupération de la réponse utilisateur
                s1 = Console.ReadKey().Key;
                Console.WriteLine();
                Console.WriteLine();

                // Si saisie <=> OUI
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
