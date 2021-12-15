using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPInterface
{
    public abstract class Compte
    {
        public string Proprietaire { get; set; }
        //Ajout d'une variable de type protected IcalculateurBenefice
        protected ICalculateurBenefice calculateurDeBenefice;

        public virtual decimal Solde
        {
            get
            {
                decimal solde = 0;

                foreach (Operation operation in _operations)
                {
                    if (operation.Type == TypeOperation.credit)
                    {
                        solde = solde + operation.Montant;
                    }
                    else
                    {
                        solde = solde - operation.Montant;
                    }
                }

                return this.calculateurDeBenefice.CalculeBenefice(solde);
            }
        }

        protected ICalculateurBenefice CalculateurBenefice { get => calculateurDeBenefice; set => calculateurDeBenefice = value; }

        protected List<Operation> _operations;
        // ajout de paramètre
        public Compte(string proprietaire, ICalculateurBenefice calculateurDeBenefice)
        {
            Proprietaire = proprietaire;
            _operations = new List<Operation>();
            this.calculateurDeBenefice = calculateurDeBenefice;
        }

        public void Crediter(decimal somme)
        {
            AjouterMouvement(somme, TypeOperation.credit);
        }

        public void Crediter(decimal somme, Compte compteDebitant)
        {
            AjouterMouvement(somme, TypeOperation.credit);
            compteDebitant.Debiter(somme);
        }

        public void Debiter(decimal somme)
        {
            AjouterMouvement(somme, TypeOperation.debit);
        }

        public void Debiter(decimal somme, Compte compteCreditant)
        {
            AjouterMouvement(somme, TypeOperation.debit);
            compteCreditant.Crediter(somme);
        }
        public abstract void AfficherResume();

       /* public virtual void AfficherResume()
        {
            Console.WriteLine(string.Format("Résumé du compte de {0}", Proprietaire));
            Console.WriteLine("*************************************");
            Console.WriteLine(string.Format("Solde : {0}", Solde.ToString("N2")));
            Console.WriteLine("Opérations :");
            AfficheOperations();
            Console.WriteLine("*************************************");
        }*/

        protected void AfficheOperations()
        {
            foreach (Operation operation in _operations)
            {
                if (operation.Type == TypeOperation.credit)
                {
                    Console.WriteLine(string.Format("+{0}", operation.Montant.ToString("N2")));
                }
                else
                {
                    Console.WriteLine(string.Format("-{0}", operation.Montant.ToString("N2")));
                }
            }
        }

        private void AjouterMouvement(decimal somme, TypeOperation type)
        {
            Operation operation = new Operation { Montant = somme, Type = type };

            _operations.Add(operation);
        }
    }
}
