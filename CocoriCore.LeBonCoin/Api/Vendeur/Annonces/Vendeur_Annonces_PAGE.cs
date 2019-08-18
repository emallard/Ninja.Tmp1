

using System;
using System.Collections.Generic;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{


    public class Vendeur_Annonces_PAGE : IPage<Vendeur_Annonces_PAGEResponse>
    {
    }

    public class Vendeur_Annonces_PAGEResponse
    {
        public List<ReunionItem> Reunions;
        public Link<Vendeur_NouvelleAnnonce_PAGE> NouvelleReunion = Link.New(new Vendeur_NouvelleAnnonce_PAGE());


        public class ReunionItem
        {
            public Guid Id;

            public ILink<Vendeur_Annonces_Id_PAGE> LinkReunion => Link.New(new Vendeur_Annonces_Id_PAGE(this.Id));
        }
    }
}