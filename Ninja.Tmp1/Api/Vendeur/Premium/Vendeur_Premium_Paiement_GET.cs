using System;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class Vendeurs_Premium_Paiement_GET : IMessage<Vendeurs_Premium_Paiement_GETResponse>
    {
        public string Formule;
    }


    public class Vendeurs_Premium_Paiement_GETResponse
    {
        public string Montant;
    }

}
