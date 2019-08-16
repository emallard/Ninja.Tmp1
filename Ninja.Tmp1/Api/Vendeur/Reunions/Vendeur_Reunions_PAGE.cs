

using System;
using System.Collections.Generic;
using CocoriCore;

namespace Ninja.Tmp1
{


    public class Vendeur_Reunions_PAGE : IPage<Vendeur_Reunions_PAGEResponse>
    {
    }

    public class Vendeur_Reunions_PAGEResponse
    {
        public List<ReunionItem> Reunions;
        public Link<Vendeur_NouvelleReunion_PAGE> NouvelleReunion = Link.New(new Vendeur_NouvelleReunion_PAGE());


        public class ReunionItem
        {
            public Guid Id;

            public ILink<Vendeur_Reunions_Id_PAGE> LinkReunion => Link.New(new Vendeur_Reunions_Id_PAGE(this.Id));
        }
    }
}