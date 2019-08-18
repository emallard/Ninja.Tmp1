using System;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_NouvelleAnnonce_POST : IMessage<Vendeur_NouvelleAnnonce_POSTResponse>
    {
        public DateTime Date;
        public string Ville;
        public string Categorie;
    }

    public class Vendeur_NouvelleAnnonce_POSTResponse
    {
    }
}