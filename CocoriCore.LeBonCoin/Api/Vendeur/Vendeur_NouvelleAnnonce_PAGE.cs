using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_NouvelleAnnonce_PAGE : IPage<Vendeur_NouvelleAnnonce_PAGEResponse>
    {
    }

    public class Vendeur_NouvelleAnnonce_PAGEResponse
    {
        public string[] Categories;

        public Form<Vendeur_NouvelleAnnonce_POST, Vendeur_NouvelleAnnonce_POSTResponse> Form = new Form<Vendeur_NouvelleAnnonce_POST, Vendeur_NouvelleAnnonce_POSTResponse>();
    }

    public class Vendeur_NouvelleAnnonce_PAGEHandler : MessageHandler<Vendeur_NouvelleAnnonce_PAGE, Vendeur_NouvelleAnnonce_PAGEResponse>
    {
        public override async Task<Vendeur_NouvelleAnnonce_PAGEResponse> ExecuteAsync(Vendeur_NouvelleAnnonce_PAGE query)
        {
            await Task.CompletedTask;
            return new Vendeur_NouvelleAnnonce_PAGEResponse()
            {

            };
        }
    }
}