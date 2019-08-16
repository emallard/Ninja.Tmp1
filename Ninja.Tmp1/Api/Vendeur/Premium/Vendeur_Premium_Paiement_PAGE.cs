using System;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class Vendeurs_Premium_Paiement_PAGE : IPage<Vendeurs_Premium_Paiement_PAGEResponse>
    {
    }


    public class Vendeurs_Premium_Paiement_PAGEResponse
    {
        public Form<Vendeur_Premium_Paiement_POST, Void, Vendeur_Premium_Confirmation_PAGE> Form;
    }

}
