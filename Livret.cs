using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPInterface
{
    public class Livret : Compte
    {
        public override void AfficherResume()
        {
            Console.WriteLine(string.Format("Résumé du compte Livret de {0}", Proprietaire));
            Console.WriteLine("*************************************");
            Console.WriteLine(string.Format("Solde : {0}", Solde.ToString("N2")));
            Console.WriteLine("Opérations :");
            AfficheOperations();
            Console.WriteLine("*************************************");
        }
        public Livret(string proprietaire, ICalculateurBenefice calculateurBenefice)
           : base(proprietaire, calculateurBenefice)
        {
        }
    }
}
