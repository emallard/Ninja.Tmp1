using System;

namespace Ninja.Tmp1
{
    public class Vendeurs_Premium_Paiement_GET : IMessage<Vendeurs_Premium_Paiement_GETResponse>
    {
        public string Formule;
        public string Montant;
    }


    public class Vendeurs_Premium_Paiement_GETResponse
    {
        public Submit<Vendeur_Premium_Paiement_POST, Void, Vendeur_Premium_Confirmation_GET> Submit;
    }

}
