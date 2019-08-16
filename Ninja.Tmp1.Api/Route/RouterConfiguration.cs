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
            builder.Get<Accueil_PAGE>().SetPath("api/index");
            builder.Get<Users_Connexion_PAGE>().SetPath("api/users/connexion");
            builder.Get<Users_Inscription_PAGE>().SetPath("api/users/inscription");
            builder.Get<Users_MotDePasseOublie_PAGE>().SetPath("api/users/mot-de-passe-oublie");

            builder.Get<Vendeur_Dashboard_GET>().SetPath("api/vendeur");

            return builder.Options;
        }
    }
}