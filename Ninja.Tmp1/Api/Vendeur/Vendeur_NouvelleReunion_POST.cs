using System;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class Vendeur_NouvelleReunion_POST : IMessage<Vendeur_NouvelleReunion_POSTResponse>
    {
        public DateTime Date;
        public string Ville;
        public string Categorie;
    }

    public class Vendeur_NouvelleReunion_POSTResponse
    {
    }
}