using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPInterface
{
    public class CompteEpargne : Compte
    {
        //public decimal TauxAbondement { get; set; }


        public CompteEpargne(string proprietaire, ICalculateurBenefice calculateurDeBenefice)
            : base(proprietaire, calculateurDeBenefice)
        {
            
        }

        public override void AfficherResume()
        {
            Console.WriteLine(string.Format("Résumé du compte Epargne de {0}", Proprietaire));
            Console.WriteLine("*************************************");
            if(calculateurDeBenefice is CalculateurBeneficeAleatoire)
            {
                Console.WriteLine(string.Format("Taux : {0}", ((CalculateurBeneficeAleatoire)calculateurDeBenefice).Taux));

            }
            Console.WriteLine(string.Format("Solde : {0}", Solde.ToString("N2")));
            Console.WriteLine("Opérations :");
            AfficheOperations();
            Console.WriteLine("*************************************");
        }
    }
}
