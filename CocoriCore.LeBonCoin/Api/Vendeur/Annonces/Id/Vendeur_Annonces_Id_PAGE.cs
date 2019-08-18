using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Vendeur_Annonces_Id_PAGE : IMessage<Vendeur_Annonces_Id_PAGEResponse>
    {
        public Guid Id;
    }

    public class Vendeur_Annonces_Id_PAGEResponse
    {
        public Get<Vendeur_Annonces_Id_GETResponse> Data;
        public ILink<Vendeur_Annonces_Id_Edit_PAGE> Edit;
        public ILink<Vendeur_Annonces_Id_Cancel_POST> Cancel;
    }

    public class Vendeur_Annonces_Id_PAGEHandler : MessageHandler<Vendeur_Annonces_Id_PAGE, Vendeur_Annonces_Id_PAGEResponse>
    {
        public override async Task<Vendeur_Annonces_Id_PAGEResponse> ExecuteAsync(Vendeur_Annonces_Id_PAGE query)
        {
            await Task.CompletedTask;
            var response = new Vendeur_Annonces_Id_PAGEResponse();
            response.Edit = Link.New(new Vendeur_Annonces_Id_Edit_PAGE() { Id = query.Id });
            response.Cancel = Link.New(new Vendeur_Annonces_Id_Cancel_POST { Id = query.Id });
            return response;
        }
    }
}