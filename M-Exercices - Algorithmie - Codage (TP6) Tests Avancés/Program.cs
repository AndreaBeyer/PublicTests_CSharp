using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Exercices_Algorithmie_Codage_TP6
{
    class Program
    {
        // Déclarations publiques
        static string saisie, client, jourInterdit, moisInterdit;
        static char[] tSaisie;
        static string[] tFichier, tNumCli, tNomCli, tJourSemaine, tMois;

        // Procédure principale
        static void Main(string[] args)
        {
            // Lit le fichier ligne par ligne comme un tableau composé de chaines de caractères
            tFichier = System.IO.File.ReadAllLines(@"C:\Users\CRM\Documents\Git HUB\MyRepository\M-Exercices - Algorithmie - Codage (TP6)\Fichier Clients.csv");
            // Avec la fonction csharp native ReadAllLines le fichier est automatiquement refermé à la fin de la lecture ? Moi j'ai envie d'y croire. Et vous ? <je sors>

            // Récupération du fichier dans 4 tableaux unidimensionnels
            tNumCli = tFichier[0].Split(',');
            tNomCli = tFichier[1].Split(',');
            tJourSemaine = tFichier[2].Split(',');
            tMois = tFichier[3].Split(',');

            // Déclarations locales
            ConsoleKey s = ConsoleKey.O;

            // Détail parce que. (J'ai pas mis de couleurs, alors juste ça, quoi.)
            Console.Title = "Controle des possibilités de livraisons".ToUpper();

            // ooo Redimmensionner la console en largeur !
            Console.WindowWidth = 110;
            Console.WindowHeight = 15;
            Console.ForegroundColor = ConsoleColor.Cyan;

            do
            {
                do
                {
                    Console.WriteLine("\n   Numéro du client \t: ");
                    saisie = Console.ReadLine();
                    EraseLine();
                    EraseLine();
                    Console.Write("   Numéro du client \t: {0}", saisie);
                }
                while (!VerifSaisie("CLI"));
                client = saisie;
                Console.Write(Environment.NewLine);

                do
                {
                    Console.WriteLine("   Jour de la semaine \t: ");
                    saisie = Console.ReadLine();
                    EraseLine();
                    EraseLine();
                    Console.Write("   Jour de la semaine \t: {0}", saisie);
                }
                while (!VerifSaisie("J"));
                Console.Write(Environment.NewLine + Environment.NewLine);

                do
                {
                    Console.WriteLine("   Mois \t: ");
                    saisie = Console.ReadLine();
                    EraseLine();
                    EraseLine();
                    Console.Write("   Mois \t: {0}", saisie);
                }
                while (!VerifSaisie("MM"));

                // Reherche les informations et affiche les résultats
                VerifSiDispo("J", client);
                VerifSiDispo("MM", client);
                Console.Write(Environment.NewLine);

                Console.WriteLine("   Voulez-vous effectuer une autre analyse (O/N)");
                s = Console.ReadKey().Key;
                Console.WriteLine(Environment.NewLine);
                while (s != ConsoleKey.O && s != ConsoleKey.N)
                {
                    Console.WriteLine("\n\n\tVotre saisie est incorrecte");
                    Console.WriteLine("\nVoulez-vous effectuer une autre analyse (O/N)");
                    s = Console.ReadKey().Key;
                    Console.WriteLine(Environment.NewLine);
                }
            }
            while (s == ConsoleKey.O);
            Console.WriteLine("\n\tAu revoir et à bientôt.");
            Console.ReadKey();
        }

        static bool VerifSaisie(string code)
        {
            tSaisie = saisie.ToCharArray();
            switch (code)
            {
                case "CLI": // Si on vérifie le numéro du client, 
                    // S'il compte 3 caractères,
                    if (tSaisie.Length == 3)
                    {
                        // S'il existe dans la fichier, 
                        for (int i = 0; i < tNumCli.Length; i++)
                        {
                            // S'il existe dans la fichier,
                            if (tNumCli[i] == saisie)
                            {
                                Console.WriteLine("\n   "+tNomCli[i]);
                                return true;
                            }
                        }
                        EraseLine();
                        Console.Write("\n\tCe client n'existe pas !");
                        Console.ReadKey();
                        EraseLine();
                        EraseLine();
                        return false;
                    }

                    else {
                        // Le format des données est incorrect (inutile de les traiter).
                        Console.Write("\n   Saisie non valide.\n");
                        Console.ReadKey();
                        EraseLine();
                        EraseLine();
                        return false;
                    }

                case "J": // Si on vérifie l'indice du jour de la semaine choisi pour la livraison, 

                    // S'il comporte exactement 1 caractères,  
                    if (tSaisie.Length == 1)
                    {
                        // S'il ne se compose que de chiffres, qu'il est entre 1 et 5 (7 correspondant aux dimanches),
                        if (int.TryParse(saisie, out int saisie_ok) && saisie_ok >= 1 && saisie_ok < 7)
                        {
                            // Le jour saisie respecte les critères de base.
                            return true;
                        }

                        else {
                            // Le format des données est incorrect (inutile de les traiter
                            Console.Write(" (L'indice du jour de la semaine doit être compris entre 1 et 6 !)");
                            Console.WriteLine(Environment.NewLine);
                            EraseLine();
                            return false;
                        }
                    }

                    else {
                        // Le format des données est incorrect (inutile de les traiter).
                        EraseLine();
                        Console.Write("\n\tSaisie non valide.\n");
                        Console.ReadKey();
                        EraseLine();
                        return false;
                    }

                case "MM": // Si on vérifie le mois choisi pour la livraison, 

                    // S'il comporte exactement 2 caractères,  
                    Console.Write(" "+saisie+" ");
                    
                    if (tSaisie.Length == 2)
                    {
                        // S'il ne se compose que de chiffres, qu'il est entre 1 et 12,
                        if (int.TryParse(saisie, out int saisie_ok) && saisie_ok >= 1 && saisie_ok <= 12)
                        {
                            // Le jour saisie respecte les critères de base.
                            return true;
                        }

                        else {
                            // Le format des données est incorrect, inutile de les traiter. 
                            Console.Write(" (L'indice du mois doit être compris entre 1 et 12 !)");
                            Console.WriteLine(Environment.NewLine);
                            EraseLine();
                            return false;
                        }
                    }

                    else {
                        // Le format des données est incorrect (inutile de les traiter).
                        EraseLine();
                        Console.Write("\n\tSaisie non valide.\n");
                        Console.ReadKey();
                        EraseLine();
                        return false;
                    }

                default:
                    return false;
            }
        }

        static void VerifSiDispo(string codeRecherche, string numCli)
        {
            // Vérifie, dans le fichier, la disponibilité du JOUR ou du MOIS de livraison
            switch (codeRecherche)
            {
                case "J":
                    // Recherche le JOUR interdit pour le string "client" donné (si le jour est 0 il n'y a aucune interdiction)
                    for (int i = 0; i < tNumCli.Length; i++)
                    {
                        if (numCli == tNumCli[i])
                        {
                            jourInterdit = tJourSemaine[i];
                            break;
                        }
                    }
                    
                    switch (int.Parse(jourInterdit))
                    {
                        case 1: jourInterdit = "Lundi";
                            break;
                        case 2: jourInterdit = "Mardi";
                            break;
                        case 3: jourInterdit = "Mercredi";
                            break;
                        case 4: jourInterdit = "Jeudi";
                            break;
                        case 5: jourInterdit = "Vendredi";
                            break;
                        case 6: jourInterdit = "Samedi";
                            break;
                        default:
                            break;
                    }

                    Console.Write(" On ne peut livrer chez le client n°{0} le {1} --> ", client, jourInterdit);
                    // Si le jour choisi est le jour de la semaine interdit
                    if (saisie == jourInterdit)
                    {
                        Console.Write("Veuillez chosir un autre jour.");
                    }
                    else {
                        Console.Write("Le {0} c'est possible !", saisie);
                    }
                    break;

                case "MM":
                    // Recherche le MOIS interdit pour le string "client" donné (si le jour est 0 alors il n'y a aucune interdiction)
                    for (int i = 0; i < tNumCli.Length; i++)
                    {
                        if (numCli == tNumCli[i]) {
                            moisInterdit = tMois[i];
                            break;
                        }
                    }

                    switch (int.Parse(moisInterdit))
                    {
                        case 1: moisInterdit = "Janvier";
                            break;
                        case 2: moisInterdit = "Février";
                            break;
                        case 3: moisInterdit = "Mars";
                            break;
                        case 4: moisInterdit = "Avril";
                            break;
                        case 5: moisInterdit = "Mai";
                            break;
                        case 6: moisInterdit = "Juin";
                            break;
                        case 7: moisInterdit = "Juillet";
                            break;
                        case 8: moisInterdit = "Août";
                            break;
                        case 9: moisInterdit = "Septembre";
                            break;
                        case 10: moisInterdit = "Octobre";
                            break;
                        case 11: moisInterdit = "Novembre";
                            break;
                        case 12: moisInterdit = "Décembre";
                            break;
                        default:
                            break;
                    }

                    Console.Write(" On ne peut livrer chez le client n°{0} en {1} --> ", client, moisInterdit);
                    // Si le mois choisi est le mois interdit
                    if (saisie == moisInterdit)
                    {
                        Console.Write("Veuillez chosir un autre jour.");
                    }
                    else {
                        Console.Write("Le {0} c'est possible !", saisie);
                    }
                    break;
            }
            Console.WriteLine(Environment.NewLine);
        }
        static void EraseLine()
        {
            // Reinitialise la ligne précédente de la console
            if (Console.CursorTop > 0)
            {
                Console.SetCursorPosition(0, Console.CursorTop -1);
            }
            // for (int i = 0; i < saisie.Length; i++)
            // {
                Console.WriteLine("\b");
            // }
        }
    }
}