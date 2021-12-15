using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateurAucunBenefice aucun = new CalculateurAucunBenefice();
            CalculateurBeneficeAleatoire alea = new CalculateurBeneficeAleatoire();
            CalculateurBeneficeATauxFixe tauxFixe = new CalculateurBeneficeATauxFixe(20m);
            // Test pour avec 2 comptes courant et un compte epargne

            CompteCourant compteNicolas = new CompteCourant("Nicolas", 2000, aucun);
            CompteCourant compteJeremy = new CompteCourant("Jeremy", 500, aucun);

            CompteEpargne compteEpargneNicolas = new CompteEpargne("Nicolas", alea);

            Livret livretNicolas = new Livret("Nicolas", tauxFixe);

            compteNicolas.Crediter(1000);
            compteNicolas.Debiter(50);
            compteEpargneNicolas.Crediter(50);
            compteNicolas.Crediter(100);
            compteEpargneNicolas.Crediter(100);
            compteJeremy.Debiter(500);
            compteJeremy.Debiter(200, compteNicolas);

            livretNicolas.Crediter(800);
            livretNicolas.Crediter(200);

            compteNicolas.AfficherResume();
            Console.WriteLine("");
            compteJeremy.AfficherResume();
            Console.WriteLine("");
            compteEpargneNicolas.AfficherResume();
            Console.WriteLine("");
            livretNicolas.AfficherResume();
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
