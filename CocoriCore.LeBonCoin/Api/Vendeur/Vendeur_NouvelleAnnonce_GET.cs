using System;
using System.Collections.Generic;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_NouvelleAnnonce_GET : IMessage<Vendeur_NouvelleAnnonce_GETResponse>
    {
    }

    public class Vendeur_NouvelleAnnonce_GETResponse
    {
        public List<string> Categories;

        public Form<Vendeur_NouvelleAnnonce_POST, Vendeur_NouvelleAnnonce_POSTResponse, Vendeur_Annonces_PAGE> Submit;
    }
}