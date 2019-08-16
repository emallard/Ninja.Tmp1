using CocoriCore;

namespace Ninja.Tmp1
{
    public class Vendeur_Premium_GET
    {
        public bool EstPremium;
        public string FormulePremium;
        public string DateFinPremium;

        public Link<Vendeurs_Premium_Paiement_GET> Formule1Mois;
        public Link<Vendeurs_Premium_Paiement_GET> Formule3Mois;
    }
}