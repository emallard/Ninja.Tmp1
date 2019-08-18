using System;
using System.Collections.Generic;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_Annonces_Id_Edit_PAGE : IMessage<Vendeur_Annonces_Id_Edit_PAGEResponse>
    {
        public Guid Id;
    }

    public class Vendeur_Annonces_Id_Edit_PAGEResponse
    {
        public Get<Vendeur_Annonces_Id_Edit_GETResponse> Get;

    }

    public class Vendeur_Annonces_Id_Edit_PAGEHandler
    {
        public Vendeur_Annonces_Id_Edit_PAGEHandler()
        {

        }
    }

}