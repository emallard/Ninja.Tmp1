using System;
using System.Threading.Tasks;
using CocoriCore;

namespace Ninja.Tmp1
{

    public class Vendeur_Reunions_Id_PAGE : IMessage<Vendeur_Reunions_Id_PAGEResponse>
    {
        public Vendeur_Reunions_Id_PAGE(Guid id)
        {
            this.Id = id;
        }
        public Guid Id;
    }

    public class Vendeur_Reunions_Id_PAGEResponse
    {
        public Get<Vendeur_Reunions_Id_GETResponse> Data;
        public ILink<Vendeur_Reunions_Id_Edit_PAGE> Edit;
        public ILink<Vendeur_Reunions_Id_Cancel_POST> Cancel;
    }

    public class Vendeur_Reunions_Id_PAGEHandler : MessageHandler<Vendeur_Reunions_Id_PAGE, Vendeur_Reunions_Id_PAGEResponse>
    {
        public override async Task<Vendeur_Reunions_Id_PAGEResponse> ExecuteAsync(Vendeur_Reunions_Id_PAGE query)
        {
            await Task.CompletedTask;
            var response = new Vendeur_Reunions_Id_PAGEResponse();
            response.Edit = Link.New(new Vendeur_Reunions_Id_Edit_PAGE() { Id = query.Id });
            response.Cancel = Link.New(new Vendeur_Reunions_Id_Cancel_POST(query.Id));
            return response;
        }
    }
}