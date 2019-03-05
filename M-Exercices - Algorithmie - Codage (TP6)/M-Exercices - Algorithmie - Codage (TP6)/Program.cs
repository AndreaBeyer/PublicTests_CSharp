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
        static string saisie, numCli, jourInterdit, moisInterdit;
        static string[] tFichier, tNumCli, tNomCli, tJourSemaine, tMois;
        static ConsoleKey s = ConsoleKey.O;

        // Procédure principale
        static void Main(string[] args)
        {
            do
            {
                // Lit le fichier ligne par ligne comme un tableau composé de chaines de caractères
                tFichier = System.IO.File.ReadAllLines(@"C:\Users\CRM\Documents\Git HUB\MyRepository\M-Exercices - Algorithmie - Codage (TP6)\Fichier Clients.csv");

                // Récupération du fichier dans 4 tableaux unidimensionnels
                tNumCli = tFichier[0].Split(',');
                tNomCli = tFichier[1].Split(',');
                tJourSemaine = tFichier[2].Split(',');
                tMois = tFichier[3].Split(',');

                // Mise en forme de l'interface
                Console.Title = "Controle des possibilités de livraisons".ToUpper();
                Console.WindowWidth = 110;
                Console.WindowHeight = 15;
                Console.ForegroundColor = ConsoleColor.Cyan;

                do
                {
                    // Récupère le numéro du CLIENT
                    Console.WriteLine("   Numéro du client : ");
                    saisie = Console.ReadLine();

                    // Si le numéro de client saisie existe dans le fichier, 
                    int i = 0;
                    while (i < tNumCli.Length)
                    {
                        if (tNumCli[i] == saisie)
                        {
                            // Le retenir.
                            numCli = saisie;
                        }
                        i++;
                    }
                    if (String.IsNullOrEmpty(numCli))
                    {
                        Console.WriteLine("   Ce client n'existe pas !");
                    }
                }
                while (String.IsNullOrEmpty(numCli));
                Console.WriteLine();

                do
                {
                    // Récupère l'indice du JOUR de la semaine
                    Console.WriteLine("   Jour de la semaine \t: ");
                    saisie = Console.ReadLine();

                    // Si l'indice du jour de la semaine choisi pour la livraison est un chiffre entre 1 et 6,
                    if (int.TryParse(saisie, out int indiceJour) && indiceJour >= 1 && indiceJour <= 6)
                    {
                        // Recherche le jour interdit pour le client choisi
                        int i = 0;
                        while (i < tNumCli.Length)
                        {
                            if (tNumCli[i] == numCli)
                            {
                                jourInterdit = ConversionJour(tJourSemaine[i]);
                            }
                            i++;
                        }

                        // Si le jour choisi est le jour de la semaine interdit,
                        if (saisie == jourInterdit)
                        {
                            Console.WriteLine("   On ne peut livrer chez le client n°{0} le {1} --> Veuillez chosir un autre jour.",
                                numCli, jourInterdit);
                        }
                        // S'il n'y a pas de jour interdit,
                        else if (String.IsNullOrEmpty(jourInterdit))
                        {
                            Console.WriteLine("   Tous les jours ouvrés sont disponibles.");
                        }
                        // S'il y a un jour interdit, mais que le jour choisi est différent,
                        else
                        {
                            Console.WriteLine("   On ne peut livrer chez le client n°{0} le {1} --> Mais le {2} c'est possible !",
                                numCli, jourInterdit, ConversionJour(saisie));
                            Console.WriteLine(Environment.NewLine);
                        }
                    }
                    // Si l'indice du jour de la semaine choisi pour la livraison n'est pas un chiffre, est inférieur à 1, ou excéde 6,
                    else
                    {
                        Console.WriteLine("   L'indice du jour de la semaine doit être compris entre 1 et 6 !");
                    }
                }
                while (!int.TryParse(saisie, out int indiceJourBis) || indiceJourBis < 1 || indiceJourBis > 6);

                do
                {
                    // Récupère l'indice du MOIS de la semaine
                    Console.WriteLine("   Mois \t: ");
                    saisie = Console.ReadLine();

                    // Si le mois choisi pour la livraison ne se compose que de chiffres, qu'il est entre 1 et 12,
                    if (int.TryParse(saisie, out int indiceMois) && indiceMois >= 1 || indiceMois <= 12)
                    {
                        // Recherche le mois interdit pour le client choisi
                        int i = 0;
                        while (i < tNumCli.Length)
                        {
                            if (tNumCli[i] == numCli)
                            {
                                moisInterdit = ConversionMois(tMois[i]);
                            }
                            i++;
                        }

                        // Si le mois choisi est le mois interdit,
                        if (saisie == jourInterdit)
                        {
                            Console.WriteLine("On ne peut livrer chez le client n°{0} en {1} --> Veuillez chosir un autre mois.",
                                numCli, jourInterdit);
                        }
                        // S'il n'y a pas de mois interdit,
                        else if (String.IsNullOrEmpty(jourInterdit))
                        {
                            Console.WriteLine("   Tous les mois sont disponibles.");
                        }
                        // S'il y a un mois interdit, mais que le mois choisi est différent,
                        else
                        {
                            Console.WriteLine("   On ne peut livrer chez le client n°{0} en {1} --> Mais en {2} c'est possible !",
                                numCli, moisInterdit, ConversionMois(saisie));
                            Console.WriteLine(Environment.NewLine);

                            int j = 0;
                            while (j < tNumCli.Length)
                            {
                                if (tNumCli[j] == numCli)
                                {
                                     = tNom[j]);
                                }
                                i++;
                            }
                            Console.WriteLine(" ------------------------------------------");
                            // Console.WriteLine(" | Vous pourrez livrer {0} un {1} en {2}. |", ooo, ooo, ConversionMois(saisie));
                            Console.WriteLine(" ------------------------------------------");
                            Console.WriteLine(Environment.NewLine);
                        }
                    }
                    // Si le mois choisi pour la livraison n'est pas un chiffre, est inférieur à 1, ou excéde 12,
                    else
                    {
                        Console.WriteLine("   L'indice du mois doit être compris entre 1 et 12 !");
                    }
                }
                while (!int.TryParse(saisie, out int indiceMoisBis) || indiceMoisBis < 1 || indiceMoisBis > 12);

                Console.WriteLine("   Voulez-vous effectuer une autre analyse (O/N)");
                s = Console.ReadKey().Key;
                Console.WriteLine(Environment.NewLine);

                while (s != ConsoleKey.O && s != ConsoleKey.N)
                {
                    Console.Clear();
                    Console.WriteLine("   Voulez-vous effectuer une autre analyse (O/N)");
                    Console.WriteLine(s);
                    Console.WriteLine("   Votre saisie est incorrecte");
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("   Voulez-vous effectuer une autre analyse (O/N)");
                    s = Console.ReadKey().Key;
                }
                Console.Clear();
            }
            while (s == ConsoleKey.O);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("\t Au revoir et à bientôt.");
            Console.WriteLine("\t (pressez une touche pour quitter)");
            Console.ReadKey();
        }

        static string ConversionJour(string j)
        {
            // Convertit cet indice de jour de la 
            // semaine en son équivalent en toutes lettres
            switch (int.Parse(j))
            {
                case 1: return "Lundi";
                case 2: return "Mardi";
                case 3: return "Mercredi";
                case 4: return "Jeudi";
                case 5: return "Vendredi";
                case 6: return "Samedi";
                default: return "";
            }
        }

        static string ConversionMois(string m)
        {
            // Convertit cet indice de jour de la 
            // semaine en son équivalent en toutes lettres
            switch (int.Parse(m))
            {
                case 1: return "Janvier";
                case 2: return "Février";
                case 3: return "Mars";
                case 4: return "Avril";
                case 5: return "Mai";
                case 6: return "Juin";
                case 7: return "Juillet";
                case 8: return "Août";
                case 9: return "Septembre";
                case 10: return "Octobre";
                case 11: return "Novembre";
                case 12: return "Décembre";
                default: return "";
            }
        }
    }
}