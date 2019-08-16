using System;
using System.Threading.Tasks;
using CocoriCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Ninja.Tmp1;

namespace Ninja.Tmp1.Api
{

    public class RouterConfiguration
    {

        public static RouterOptions Options()
        {
            var builder = new RouterOptionsBuilder();

            builder.Get<ApiFootprintQuery>().AddPath("footprint");
            builder.Get<Accueil_PAGE>().SetPath("page/index");

            builder.Get<Users_Connexion_PAGE>().SetPath("page/users/connexion");
            builder.Post<Users_Connexion_POST>().SetPath("api/users/inscription");
            builder.Get<Users_Inscription_PAGE>().SetPath("page/users/inscription");
            builder.Post<Users_Inscription_POST>().SetPath("api/users/inscription");

            builder.Get<Users_MotDePasseOublie_PAGE>().SetPath("page/users/mot-de-passe-oublie");


            builder.Get<Vendeur_Dashboard_PAGE>().SetPath("page/vendeur");
            builder.Get<Vendeur_Dashboard_GET>().SetPath("api/vendeur");

            return builder.Options;
        }
    }
}