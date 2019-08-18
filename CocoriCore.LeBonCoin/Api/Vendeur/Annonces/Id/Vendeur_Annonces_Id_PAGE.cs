using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Vendeur_Annonces_Id_PAGE : IPage<Vendeur_Annonces_Id_PAGEResponse>
    {
        public Guid Id;
    }

    public class Vendeur_Annonces_Id_PAGEResponse
    {
        public Guid Id;
        public string Ville;
        public string Categorie;

        public Vendeur_Annonces_Id_Edit_PAGE Edit;

        public Vendeur_Annonces_Id_Cancel_POST Cancel;
    }

    public class Vendeur_Annonces_Id_PAGEHandler : MessageHandler<Vendeur_Annonces_Id_PAGE, Vendeur_Annonces_Id_PAGEResponse>
    {
        public async override Task<Vendeur_Annonces_Id_PAGEResponse> ExecuteAsync(Vendeur_Annonces_Id_PAGE query)
        {
            await Task.CompletedTask;
            return new Vendeur_Annonces_Id_PAGEResponse()
            {
                Id = query.Id,
                Edit = new Vendeur_Annonces_Id_Edit_PAGE { Id = query.Id },
                Cancel = new Vendeur_Annonces_Id_Cancel_POST { Id = query.Id }
            };
        }
    }
}
