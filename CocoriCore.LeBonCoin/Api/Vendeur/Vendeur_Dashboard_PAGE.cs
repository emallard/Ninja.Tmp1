using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_Dashboard_PAGE : IPage<Vendeur_Dashboard_PAGEResponse>, IQuery
    {
    }

    public class Vendeur_Dashboard_PAGEResponse
    {
        public string Nom;
        public string Prenom;
        public Vendeur_NouvelleAnnonce_PAGE NouvelleAnnonce = new Vendeur_NouvelleAnnonce_PAGE();
        public Vendeur_Annonces_PAGE Reunions = new Vendeur_Annonces_PAGE();
        public MenuUtilisateur MenuUtilisateur = new MenuUtilisateur();
    }

    public class Vendeur_Dashboard_PAGEHandler : MessageHandler<Vendeur_Dashboard_PAGE, Vendeur_Dashboard_PAGEResponse>
    {
        private readonly IClaimsProvider claimsProvider;
        private readonly IRepository repository;

        public Vendeur_Dashboard_PAGEHandler(IClaimsProvider claimsProvider, IRepository repository)
        {
            this.claimsProvider = claimsProvider;
            this.repository = repository;
        }

        public override async Task<Vendeur_Dashboard_PAGEResponse> ExecuteAsync(Vendeur_Dashboard_PAGE query)
        {
            var idUtilisateur = claimsProvider.GetClaims<UserClaims>().IdUtilisateur;
            var profile = await repository.LoadAsync<Profile>(x => x.IdUtilisateur, idUtilisateur);

            return new Vendeur_Dashboard_PAGEResponse()
            {
                Nom = profile.Nom,
                Prenom = profile.Prenom
            };
        }
    }
}