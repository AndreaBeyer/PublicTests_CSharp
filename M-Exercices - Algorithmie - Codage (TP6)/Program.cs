using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Exercices_Algorithmie_Codage_TP6
{
    /* 
        \' for a Single Quote
        \" for a Double Quote
        \\ for a Backslash
        \n for a New Line
        \r for a Carriage Return
        \b for a Backspace
        \f for a Form Feed
        \0 for a Null Character
        \a for an Alert Character
        \t for a Horizontal Tab
        \v for a Vertical Tab
        \x# for (the hex value of) Unicode Characters (Exemple: \x20).
        \U######## for (the hex value of) Unicode Characters, Supporting the generation of Surrogates
    */

    class Program
    {
        // Déclarations publiques
        static string saisie, numCli, nomCli, jourInterdit, moisInterdit, jourChoisi;

        // Procédure principale
        static void Main(string[] args)
        {
            // A DEBUGER !!! //
            
            // Déclarations
            ConsoleKey s = ConsoleKey.O;
            string moisChoisi;

            do
            {
                // Déclarations
                string[] tFichier, tNumCli, tNomCli, tJourSemaine, tMois;

                // Lit le fichier ligne par ligne comme un tableau composé de chaines de caractères
                tFichier = System.IO.File.ReadAllLines(@"C:\Users\CRM\Documents\Git HUB\MyRepository\M-Exercices - Algorithmie - Codage (TP6)\Clients.csv");

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

                    // Cherche le numéro de client saisie dans le tableau crée à partir du contenu du fichier, 
                    int i = 0;
                    while (i < tNumCli.Length-1)
                    {
                        if (tNumCli[i] == saisie)
                        {
                            numCli = saisie;
                            nomCli = tNomCli[i];
                        }
                        i++;
                    }
                    // Si le numéro de client saisie est trouvé, le retenir et retenir le nom de client correspondant
                    if (String.IsNullOrEmpty(numCli))
                    {
                        Console.WriteLine("\t Ce client n'existe pas !");
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
                        // Cherche le jour interdit pour le client choisi
                        int i = 0;
                        while (i < tNumCli.Length)
                        {
                            if (tNumCli[i] == numCli)
                            {
                                jourInterdit = Jour(tJourSemaine[i]);
                            }
                            i++;
                        }

                        // Si le jour choisi est le jour de la semaine interdit,
                        if (Jour(saisie) == jourInterdit)
                        {
                            Console.WriteLine("   On ne peut livrer chez {0} le {1}. Veuillez chosir un autre jour.",
                                nomCli, jourInterdit);
                        }
                        // Si le jour saisi n'a pas été renseigné,
                        else if (String.IsNullOrEmpty(Jour(saisie)))
                        {
                            Console.WriteLine("   Veuillez entrer le jour.");
                        }
                        // S'il n'y a pas de jour interdit,
                        else if (String.IsNullOrEmpty(Jour(saisie)))
                        {
                            Console.WriteLine("   On peut livrer chez {0} tous les jours ouvrés.");
                            jourChoisi = Jour(saisie);
                        }
                        else
                        {
                            // S'il y a un jour interdit, mais que le jour choisi est différent,
                            Console.WriteLine("   On peut livrer chez {0} le {1} (NB: Ce n'est pas possible le {2}.)",
                                nomCli, Jour(saisie), jourInterdit);
                            Console.WriteLine(Environment.NewLine);
                            jourChoisi = Jour(saisie);
                        }
                    }
                    // Si l'indice du jour de la semaine choisi pour la livraison n'est pas un chiffre, est inférieur à 1, ou excéde 6,
                    else
                    {
                        Console.WriteLine("   L'indice du jour de la semaine ne peut aller que 1 à 6.");
                    }
                }
                while (!int.TryParse(saisie, out int indiceJourBis) || indiceJourBis < 1 || indiceJourBis > 6 || Jour(saisie) == jourInterdit);

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
                                moisInterdit = Mois(tMois[i]);
                            }
                            i++;
                        }

                        // Si le mois choisi est le mois interdit,
                        if (Mois(saisie) == moisInterdit)
                        {
                            Console.WriteLine("   On ne peut livrer chez {0} en {1}. Veuillez chosir un autre mois.",
                                nomCli, moisInterdit);
                        }
                        // Si le mois saisi n'a pas été renseigné,
                        else if (String.IsNullOrEmpty(Mois(saisie)))
                        {
                            Console.WriteLine("   Veuillez entrer le mois.");
                        }
                        // S'il n'y a pas de mois interdit,
                        else if (String.IsNullOrEmpty(moisInterdit))
                        {
                            Console.WriteLine("   On peut livrer chez {0} tous les mois.");
                            moisChoisi = Mois(saisie);

                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine("\t === Vous pourrez livrer {0} un {1} en {2}. === ",
                                nomCli, jourChoisi, moisChoisi);
                            Console.WriteLine(Environment.NewLine); // NB: ceci va deux fois à la ligne => saut de ligne
                        }
                        // S'il y a un mois interdit, mais que le mois choisi est différent,
                        else
                        {
                            Console.WriteLine("   On peut livrer chez {0} en {1} (NB: Ce n'est pas possible en {2}.)",
                                nomCli, Mois(saisie), moisInterdit);

                            moisChoisi = Mois(saisie);
                            Console.WriteLine(Environment.NewLine); // NB: ceci va deux fois à la ligne => saut de ligne
                            Console.WriteLine("\t === Vous pourrez livrer {0} un {1} en {2}. === ", 
                                nomCli, jourChoisi, moisChoisi);
                            Console.WriteLine(Environment.NewLine); // NB: ceci va deux fois à la ligne => saut de ligne
                        }
                    }
                    // Si le mois choisi pour la livraison n'est pas un chiffre, est inférieur à 1, ou excéde 12,
                    else
                    {
                        Console.WriteLine("   L'indice du mois ne peut aller que de 1 à 12.");
                    }
                }
                while (!int.TryParse(saisie, out int indiceMoisBis) || indiceMoisBis < 1 || indiceMoisBis > 12 || Mois(saisie) == moisInterdit);

                Console.WriteLine("\t Voulez-vous effectuer une autre analyse (O/N)");
                s = Console.ReadKey().Key;
                Console.WriteLine(Environment.NewLine); // Attention ceci ira deux fois à la ligne (sautera une ligne).

                while (s != ConsoleKey.O && s != ConsoleKey.N)
                {
                    Console.Clear();
                    Console.WriteLine("\t Voulez-vous effectuer une autre analyse (O/N)");
                    Console.WriteLine(s);
                    Console.WriteLine("\t Votre saisie est incorrecte");
                    Console.WriteLine();
                    Console.WriteLine("\t Voulez-vous effectuer une autre analyse (O/N)");
                    s = Console.ReadKey().Key;
                }
                Console.Clear();
            }
            while (s == ConsoleKey.O);
            
            Console.WriteLine("\t Merci d'avoir utilisé notre logiciel.");
            Console.WriteLine("\t (pressez une touche pour quitter)");
            Console.ReadKey();
        }
        
        static string Jour(string sJ)
        {
            // Convertit cet indice de jour de la 
            // semaine en son équivalent en toutes lettres
            if (int.TryParse(sJ, out int iJ))
            {
                switch (iJ)
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
            else
            {
                return "ERREUR";
            }
        }

        static string Mois(string sM)
        {
            // Convertit cet indice de jour de la 
            // semaine en son équivalent en toutes lettres
            if (int.TryParse(sM, out int iM))
            {
                switch (iM)
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
            else
            {
                return "ERREUR";
            }
        }
    }
}