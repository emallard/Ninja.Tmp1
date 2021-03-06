using System;
using System.Threading.Tasks;

namespace CocoriCore.LeBonCoin
{

    public class Users_SaisieNouveauMotDePasse_Token_POST : IMessage<Users_SaisieNouveauMotDePasse_Token_POSTResponse>
    {
        public Guid Token;
        public string MotDePasse;
        public string Confirmation;
    }

    public class Users_SaisieNouveauMotDePasse_Token_POSTResponse
    {
        public Users_Connexion_PAGE Redirect = new Users_Connexion_PAGE();
    }

    public class Users_SaisieNouveauMotDePasse_Token_POSTHandler : MessageHandler<Users_SaisieNouveauMotDePasse_Token_POST, Users_SaisieNouveauMotDePasse_Token_POSTResponse>
    {
        private readonly IRepository repository;
        private readonly IHashService hashService;

        public Users_SaisieNouveauMotDePasse_Token_POSTHandler(IRepository repository, IHashService hashService)
        {
            this.repository = repository;
            this.hashService = hashService;
        }

        public async override Task<Users_SaisieNouveauMotDePasse_Token_POSTResponse> ExecuteAsync(Users_SaisieNouveauMotDePasse_Token_POST message)
        {
            var token = await repository.LoadAsync<TokenMotDePasseOublie>(message.Token);
            var utilisateur = await repository.LoadAsync<Utilisateur>(x => x.Email, token.Email);
            utilisateur.HashMotDePasse = await this.hashService.HashAsync(message.MotDePasse);
            await repository.UpdateAsync(utilisateur);
            return new Users_SaisieNouveauMotDePasse_Token_POSTResponse();
        }
    }
}