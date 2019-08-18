

using System;
using System.Collections.Generic;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{


    public class Vendeur_Annonces_GET : IMessage<Vendeur_Annonces_GETResponse>
    {
    }

    public class Vendeur_Annonces_GETResponse
    {
        public List<ReunionItem> Reunions;
        public Link<Vendeur_NouvelleAnnonce_GET> NouvelleReunion = Link.New(new Vendeur_NouvelleAnnonce_GET());


        public class ReunionItem
        {
            public Guid Id;

            public ILink<Vendeur_Annonces_Id_GET> LinkReunion => Link.New(new Vendeur_Annonces_Id_GET(this.Id));
        }
    }
}