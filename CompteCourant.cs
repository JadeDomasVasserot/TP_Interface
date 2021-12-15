using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPInterface
{
    public class CompteCourant : Compte
    {
        public decimal DecouvertAutorise { get; set; }

        public CompteCourant(string proprietaire, decimal decouvertAutorise, ICalculateurBenefice calculateurDeBenefice)
            : base(proprietaire, calculateurDeBenefice)
        {
            DecouvertAutorise = decouvertAutorise;
        }

        public override void AfficherResume()
        {
            Console.WriteLine(string.Format("Résumé du compte Courant de {0}", Proprietaire));
            Console.WriteLine("*************************************");
            Console.WriteLine("Decouvert : {0}", DecouvertAutorise);
            Console.WriteLine(string.Format("Solde : {0}", Solde.ToString("N2")));
            Console.WriteLine("Opérations :");
            AfficheOperations();
            Console.WriteLine("*************************************");
        }
    }
}
