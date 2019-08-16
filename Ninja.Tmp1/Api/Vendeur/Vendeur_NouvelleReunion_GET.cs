using System;
using System.Collections.Generic;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class Vendeur_NouvelleReunion_GET : IMessage<Vendeur_NouvelleReunion_GETResponse>
    {
    }

    public class Vendeur_NouvelleReunion_GETResponse
    {
        public List<string> Categories;

        public Form<Vendeur_NouvelleReunion_POST, Vendeur_NouvelleReunion_POSTResponse, Vendeur_Reunions_PAGE> Submit;
    }
}