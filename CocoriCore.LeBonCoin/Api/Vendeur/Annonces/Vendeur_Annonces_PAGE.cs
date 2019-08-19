

using System;
using System.Collections.Generic;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{


    public class Vendeur_Annonces_PAGE : IPage<Vendeur_Annonces_PAGEResponse>
    {
    }


    public class Vendeur_Annonces_PAGEResponseItem
    {
        public Guid Id;

        public Vendeur_Annonces_Id_PAGE Lien = new Vendeur_Annonces_Id_PAGE();
    }

    public class Vendeur_Annonces_PAGEResponse
    {
        public Vendeur_Annonces_PAGEResponseItem[] Annonces;
        public Vendeur_NouvelleAnnonce_PAGE NouvelleReunion = new Vendeur_NouvelleAnnonce_PAGE();


    }

}