using System;

namespace Ninja.Tmp1
{
    public class Vendeurs_Premium_Paiement_GET : IRoutable<string>
    {
        public string R1 => Formule;
        public string Formule;
        public string Montant;

        public ISubmit<Vendeur_Premium_Paiement_POST, Vendeur_Premium_Confirmation_GET> Submit;
    }

    public class Vendeur_Premium_Paiement_POST
    {
        public string NumeroCarte;
        public string Mois;
        public string Annee;
        public string Cryptogramme;

        public IValidators Validators;
    }


    public class Vendeur_Premium_Paiement_POSTHandler
    {
        public void Execute(Vendeur_Premium_Paiement_POST post)
        {

        }
    }
}
