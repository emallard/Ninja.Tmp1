using System;
using System.Collections.Generic;

namespace Ninja.Tmp1
{

    public class Vendeur_Reunions_Id_Edit_POST : IRoutable<Guid>
    {
        public Guid R1 => Id;
        public Guid Id;

        public DateTime Date;
        public string Ville;
        public string Categorie;

    }

    public class Vendeur_Reunions_Id_Edit_POSTHandler
    {
        public Vendeur_Reunions_Id_Edit_POSTHandler(IRepository repository)
        {

        }
    }

}