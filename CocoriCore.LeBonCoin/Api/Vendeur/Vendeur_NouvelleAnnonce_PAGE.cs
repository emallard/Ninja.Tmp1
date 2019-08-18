using System;
using System.Collections.Generic;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_NouvelleAnnonce_PAGE : IMessage<Vendeur_NouvelleAnnonce_PAGEResponse>
    {
    }

    public class Vendeur_NouvelleAnnonce_PAGEResponse
    {
        public List<string> Categories;

        public Form<Vendeur_NouvelleAnnonce_POST, Vendeur_NouvelleAnnonce_POSTResponse> Form = new Form<Vendeur_NouvelleAnnonce_POST, Vendeur_NouvelleAnnonce_POSTResponse>();
    }
}