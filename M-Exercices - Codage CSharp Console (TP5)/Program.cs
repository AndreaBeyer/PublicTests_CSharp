using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Exercices___Algorithmie___Codage__TP5_
{
    class Program 
    {
        static string saisie;
        static int mo, ca, ch, ca_a, co, vo, ca_s;
        int currentLineCursor = Console.CursorTop;
        static void Main(string[] args)
        {
            ConsoleKey s = ConsoleKey.O;
            System.Text.RegularExpressions.MatchCollection occurences;

            Console.Title = "Analyse lexicale d'une chaîne de caractères".ToUpper();
            do
            {
                Console.Clear();
                Console.WriteLine("Veuillez entrer la chaîne de caractères à analyser (moins de 255 charactères) : ");
                saisie = Console.ReadLine();
                
                if (!String.IsNullOrEmpty(saisie))
                {
                    // Gestion du point final
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    if (saisie.Contains('.'))
                    {
                        saisie = saisie.TrimEnd('.');
                    }
                    else
                    {
                        Console.WriteLine(saisie + ".");
                    }

                    // Analyse de la chaine
                    // Mots
                    string[] tMo;
                    char[] tCa;
                    tMo = saisie.Split(' ');
                    mo = tMo.Length;
                    // Caractères
                    tCa = saisie.ToCharArray();
                    ca = tCa.Length;
                    // Chiffres
                    ch = 0;
                    foreach (var c in saisie)
                    {
                        if (char.IsNumber(c))
                        {
                            ch++;
                        }
                    }
                    // Alphanumériques (chiffres ou lettres)
                    ca_a = 0;
                    foreach (var c in saisie)
                    {
                        if (char.IsLetterOrDigit(c))
                        {
                            ca_a++;
                        }
                    }
                    // Consoles
                    co = 0;
                    occurences = System.Text.RegularExpressions.Regex.Matches(saisie, "[bcdfghjklmnpqrstvwxz]");
                    foreach (System.Text.RegularExpressions.Match trouvaille in occurences)
                    {
                        co++;
                    }
                    // Voyelles
                    vo = 0;
                    occurences = System.Text.RegularExpressions.Regex.Matches(saisie, "[aeiouy]");
                    foreach (System.Text.RegularExpressions.Match trouvaille in occurences)
                    {
                        vo++;
                    }
                    // Caractères spéciaux
                    ca_s = 0;
                    occurences = System.Text.RegularExpressions.Regex.Matches(saisie, "[ -_'/:;,.?!\\\\[\\]\\*\\(\\)\\+=\\&]");
                    foreach (System.Text.RegularExpressions.Match trouvaille in occurences)
                    {
                        ca_s++;
                    }

                    // Affichage du résultat
                    Console.WriteLine("\nCette chaîne est composée de : \n\t " +
                        "- {0} mots \n\t " +
                        "- {1} caractères... \n\t\t " +
                        "- {2} chiffres \n\t\t " +
                        "- {3} caractères alphanumériques... \n\t\t\t " +
                        "- {4} consonnes \n\t\t\t " +
                        "- {5} voyelles \n\t\t " +
                        "- et {6} caractères spéciaux. \n", mo, ca, ch, ca_a, co, vo, ca_s);
                    
                    Console.WriteLine("Voulez-vous effectuer une autre analyse (O/N)");
                    s = Console.ReadKey().Key;
                    Console.WriteLine(Environment.NewLine);
                    while (s != ConsoleKey.O && s != ConsoleKey.N)
                    {
                        Console.WriteLine("Votre saisie est incorrecte");
                        Console.WriteLine("Voulez-vous effectuer une autre analyse (O/N)");
                        s = Console.ReadKey().Key;
                        Console.WriteLine(Environment.NewLine);
                    }
                }
            }
            while (s == ConsoleKey.O);
            Console.WriteLine("Au revoir et à bientôt ! \n(presser une touche...)");
            Console.ReadKey();
        }

        private static void ClearCurrentConsoleLine()
        {
            throw new NotImplementedException();
        }
    }
}
