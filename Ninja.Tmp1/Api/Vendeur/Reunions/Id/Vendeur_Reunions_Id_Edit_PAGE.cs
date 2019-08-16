using System;
using System.Collections.Generic;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class Vendeur_Reunions_Id_Edit_PAGE : IMessage<Vendeur_Reunions_Id_Edit_PAGEResponse>
    {
        public Guid Id;
    }

    public class Vendeur_Reunions_Id_Edit_PAGEResponse
    {
        public Get<Vendeur_Reunions_Id_Edit_GETResponse> Get;

    }

    public class Vendeur_Reunions_Id_Edit_PAGEHandler
    {
        public Vendeur_Reunions_Id_Edit_PAGEHandler()
        {

        }
    }

}