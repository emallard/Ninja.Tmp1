using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace CocoriCore.LeBonCoin
{

    public class Annonces_POST : ICommand, IMessage<Annonces_POSTResponse>
    {
        public string Ville;
        public string Categorie;
    }

    public class Annonces_POSTResponse
    {
        public ILink<Annonces_PAGE> Redirect;
    }


    public class Annonces_POSTHandler : MessageHandler<Annonces_POST, Annonces_POSTResponse>
    {

        public Annonces_POSTHandler()
        {
        }

        public override async Task<Annonces_POSTResponse> ExecuteAsync(Annonces_POST command)
        {
            await Task.CompletedTask;
            return new Annonces_POSTResponse()
            {
                Redirect = Link.New(new Annonces_PAGE()
                {
                    Ville = command.Ville,
                    Categorie = command.Categorie
                })
            };
        }
    }
}
