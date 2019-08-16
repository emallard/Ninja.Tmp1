using System;
using System.Collections.Generic;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class Vendeur_NouvelleReunion_PAGE : IMessage<Vendeur_NouvelleReunion_PAGEResponse>
    {
    }

    public class Vendeur_NouvelleReunion_PAGEResponse
    {
        public List<string> Categories;

        public Form<Vendeur_NouvelleReunion_POST, Vendeur_NouvelleReunion_POSTResponse, Vendeur_Reunions_PAGE> Submit;
    }
}