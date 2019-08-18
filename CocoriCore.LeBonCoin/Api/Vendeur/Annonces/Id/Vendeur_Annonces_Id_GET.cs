using System;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Vendeur_Annonces_Id_GET : IMessage<Vendeur_Annonces_Id_GETResponse>
    {
        public Vendeur_Annonces_Id_GET(Guid id)
        {
            this.Id = id;
        }
        public Guid Id;
    }

    public class Vendeur_Annonces_Id_GETResponse
    {
        public Guid Id;
        public DateTime Date;
        public string Ville;
        public string Categorie;

        public ILink<Vendeur_Annonces_Id_Edit_GET> Edit => Link.New(new Vendeur_Annonces_Id_Edit_GET() { Id = this.Id });

        public ILink<Vendeur_Annonces_Id_Cancel_POST> Cancel => Link.New(new Vendeur_Annonces_Id_Cancel_POST(this.Id));
    }

    public class Vendeur_Annonces_Id_GETHandler
    {
        /*
        private readonly IRepository repository;

        public Vendeur_Annonces_Id_GETHandler(IRepository repository)
        {
            this.repository = repository;
        }*/
    }
}