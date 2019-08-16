using System;
using System.Collections.Generic;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class Vendeur_Reunions_Id_Edit_GET : IMessage<Vendeur_Reunions_Id_Edit_GETResponse>
    {
        public Guid Id;
    }

    public class Vendeur_Reunions_Id_Edit_GETResponse
    {
        public DateTime Date;
        public string Ville;
        public string Categorie;

        public IEnumerable<string> ListCategories;

    }

    public class Vendeur_Reunions_Id_Edit_GETHandler
    {
        public Vendeur_Reunions_Id_Edit_GETHandler()
        {

        }
    }

}