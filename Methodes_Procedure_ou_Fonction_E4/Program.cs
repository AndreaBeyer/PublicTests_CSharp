using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodes_Procedure_ou_Fonction_E4
{
    class Program
    {
        #region Déclarations
        static uint annee;
        #endregion

        #region Procédure principale
        static void Main(string[] args)
        {
            #region Initialisation de l'interface
            Console.Title = "Enoncé 4 • Détection des années bisextiles".ToUpper();
            Console.WriteLine();
            #endregion

            #region Récupération de l'année
            Console.WriteLine("  Veuillez entrer une année (AAAA) :");
            annee = uint.Parse(Console.ReadLine()); // PEUT ETRE DEVELOPPE
            Console.WriteLine();
            #endregion

            #region Affichage des données traitées
            if (EstBissextile(annee))
            {
                Console.WriteLine("  L'année {0} est bissextile.", annee);
            }
            else
            {
                Console.WriteLine("  L'année {0} n'est pas bissextile.", annee);
            }
            Console.ReadKey();
            #endregion
        }
        #endregion

        #region Fonction principale de vérification
        static bool EstBissextile(uint an)
        {
            if ( (annee % 4)==0 )
            {
                if ( (annee % 100)==0 && (annee % 400)==0)
                {
                    return true;
                }
                else if ( !((annee % 100)==0) )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
