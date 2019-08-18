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

            builder.Get<ApiFootprintQuery>()
                                                        .SetPath("api/footprint");
            builder.Get<Accueil_PAGE>()
                                                        .SetPath("api/");
            builder.Get<Users_Connexion_PAGE>()
                                                        .SetPath("api/users/connexion");
            builder.Post<Users_Connexion_POST>()
                                                        .SetPath("api/users/connexion");
            builder.Get<Users_Inscription_PAGE>()
                                                        .SetPath("api/users/inscription");
            builder.Post<Users_Inscription_POST>()
                                                        .SetPath("api/users/inscription");
            builder.Get<Users_MotDePasseOublie_PAGE>()
                                                        .SetPath("api/users/mot-de-passe-oublie");
            builder.Post<Users_MotDePasseOublie_POST>()
                                                        .SetPath("api/users/mot-de-passe-oublie");
            builder.Get<Vendeur_Dashboard_PAGE>()
                                                        .SetPath("api/vendeur");
            builder.Get<Vendeur_NouvelleAnnonce_PAGE>()
                                                        .SetPath("api/vendeur/nouvelle-annonce");
            builder.Post<Vendeur_NouvelleAnnonce_POST>()
                                                        .SetPath("api/vendeur/nouvelle-annonce");
            builder.Get<Vendeur_Annonces_GET>()
                                                        .SetPath(x => $"api/vendeur/annonces");
            builder.Get<Vendeur_Annonces_Id_GET>()
                                                        .SetPath(x => $"api/vendeur/annonces/{x.Id}");
            builder.Get<Annonces_PAGE>()
                                                        .SetPath("api/annonces");
            builder.Post<Annonces_POST>()
                                                        .SetPath("api/annonces");
            builder.Get<Annonces_Id_PAGE>()
                                                        .SetPath(x => $"api/annonces/{x.Id}");
            builder.Get<Villes_GET>()
                                                        .SetPath("api/villes");


            return builder.Options;
        }
    }
}