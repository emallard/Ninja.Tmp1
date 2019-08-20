using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace CocoriCore.LeBonCoin
{

    public class Annonces_GET : ICommand, IMessage<Annonces_POSTResponse>
    {
        public string Ville;
        public string Categorie;
    }

    public class Annonces_POSTResponse
    {
        public Annonces_PAGE Annonces;
    }


    public class Annonces_POSTHandler : MessageHandler<Annonces_GET, Annonces_POSTResponse>
    {

        public Annonces_POSTHandler()
        {
        }

        public override async Task<Annonces_POSTResponse> ExecuteAsync(Annonces_GET command)
        {
            await Task.CompletedTask;
            return new Annonces_POSTResponse()
            {
                Annonces = new Annonces_PAGE()
                {
                    Ville = command.Ville,
                    Categorie = command.Categorie
                }
            };
        }
    }
}
