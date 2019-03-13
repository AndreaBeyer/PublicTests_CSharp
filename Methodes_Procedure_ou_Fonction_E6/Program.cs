using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodes_Procedure_ou_Fonction_E6
{
    class Program
    {
        #region Déclarations publiques
        static string mot;
        #endregion

        #region Procédure principale
        static void Main(string[] args)
        {
            #region Initialisation de l'interface
            Console.Title = "Enoncé 6 • Inversion d'une chaine".ToUpper();
            Console.WriteLine();
            #endregion

            #region Récupération de la chaîne
            Console.WriteLine("  Veuillez saisir une chaine :");
            mot = Console.ReadLine();
            Console.WriteLine();
            #endregion

            #region Appel de fonction
            Inverser(ref mot);
            #endregion

            #region Affichage des données traitées
            Console.WriteLine("  L'exacte inverse de cette chaine est {0}.", mot);
            Console.ReadKey();
            #endregion
        }
        #endregion

        #region Fonction d'inversion des caractères de la chaine
        static void Inverser(ref string chaine)
        {
            char[] tC1 = chaine.ToCharArray();
            char[] tC2 = new char[tC1.Length];
            int j = 1;
            for (int i = 0; i < tC1.Length - 1; i++)
            {
                tC2[i] = tC1[tC1.Length - j];
                j++;
            }
            tC2[tC1.Length-1] = tC1[0];

            chaine = new string(tC2); // A noter dans ma FAQ
        }
        #endregion
    }
}