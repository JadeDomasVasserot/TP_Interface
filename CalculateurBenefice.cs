using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPInterface
{
   public interface ICalculateurBenefice
    {
        //Méthode déclaré de l'interface
        decimal CalculeBenefice(decimal solde);
    }
    public class CalculateurBeneficeATauxFixe : ICalculateurBenefice
    {
        //Attribut
        public decimal Taux { get; set; }

        //constructeur
        public CalculateurBeneficeATauxFixe(decimal taux)
        {
            this.Taux = taux;
        }

        
        //méthodes de mon interface
        public decimal CalculeBenefice(decimal solde)
        {
            return solde *(1 + Taux);
        }
    }
    public class CalculateurBeneficeAleatoire : ICalculateurBenefice
    {
        //attributs
        public decimal Taux { get; set; }
        //constructeur
        public CalculateurBeneficeAleatoire() {
            Random random = new Random();
            Taux = (decimal)random.NextDouble();
        }

        //méthode de l'interface
        public decimal CalculeBenefice(decimal solde)
        {
            return solde * (1 + Taux);
        }
    }
    public class CalculateurAucunBenefice : ICalculateurBenefice
    {
        // méthode provenant de l'interface
        public decimal CalculeBenefice(decimal solde)
        {
            return solde;
        }
    }
}
