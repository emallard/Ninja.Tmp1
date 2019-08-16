

using System;
using System.Collections.Generic;
using CocoriCore;

namespace Ninja.Tmp1
{


    public class Vendeur_Reunions_GET : IMessage<Vendeur_Reunions_GETResponse>
    {
    }

    public class Vendeur_Reunions_GETResponse
    {
        public List<ReunionItem> Reunions;
        public Link<Vendeur_NouvelleReunion_GET> NouvelleReunion = Link.New(new Vendeur_NouvelleReunion_GET());


        public class ReunionItem
        {
            public Guid Id;

            public ILink<Vendeur_Reunions_Id_GET> LinkReunion => Link.New(new Vendeur_Reunions_Id_GET(this.Id));
        }
    }
}