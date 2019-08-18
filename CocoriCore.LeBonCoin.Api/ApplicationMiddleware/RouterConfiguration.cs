using System;
using System.Threading.Tasks;
using CocoriCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using CocoriCore.LeBonCoin;

namespace CocoriCore.LeBonCoin.Api
{

    public class RouterConfiguration
    {

        public static RouterOptions Options()
        {
            var builder = new RouterOptionsBuilder();



            builder.Get<ApiFootprintQuery>().AddPath("api/footprint");
            builder.Get<Accueil_PAGE>().SetPath("api/accueil");

            builder.Get<Users_Connexion_PAGE>().SetPath("api/users/connexion");
            builder.Post<Users_Connexion_POST>().SetPath("api/users/connexion");
            builder.Get<Users_Inscription_PAGE>().SetPath("api/users/inscription");
            builder.Post<Users_Inscription_POST>().SetPath("api/users/inscription");

            builder.Get<Users_MotDePasseOublie_PAGE>().SetPath("api/users/mot-de-passe-oublie/page");
            builder.Get<Users_MotDePasseOublie_POST>().SetPath("api/users/mot-de-passe-oublie");



            builder.Get<Vendeur_Dashboard_PAGE>().SetPath("api/page/vendeur");
            builder.Get<Vendeur_Dashboard_GET>().SetPath("api/vendeur");

            return builder.Options;
        }
    }
}