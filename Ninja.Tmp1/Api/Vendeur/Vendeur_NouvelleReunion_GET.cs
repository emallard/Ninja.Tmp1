using System;
using System.Collections.Generic;

namespace Ninja.Tmp1
{
    public class Vendeur_NouvelleReunion_GET : IMessage<Vendeur_NouvelleReunion_GETResponse>
    {
    }

    public class Vendeur_NouvelleReunion_GETResponse
    {
        public List<string> Categories;

        public Submit<Vendeur_NouvelleReunion_POST, Vendeur_NouvelleReunion_POSTResponse, Vendeur_Reunions_GET> Submit;
    }
}