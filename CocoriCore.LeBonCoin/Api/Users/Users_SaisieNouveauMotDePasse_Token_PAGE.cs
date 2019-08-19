using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Users_SaisieNouveauMotDePasse_Token_PAGE : IPage<Users_SaisieNouveauMotDePasse_Token_PAGEResponse>
    {
        public Guid Token;
    }

    public class Users_SaisieNouveauMotDePasse_Token_PAGEResponse
    {
        public Form<Users_SaisieNouveauMotDePasse_Token_POST, Users_SaisieNouveauMotDePasse_Token_POSTResponse> Form = new Form<Users_SaisieNouveauMotDePasse_Token_POST, Users_SaisieNouveauMotDePasse_Token_POSTResponse>();
    }

    public class Users_SaisieNouveauMotDePasse_Token_PAGEHandler : MessageHandler<Users_SaisieNouveauMotDePasse_Token_PAGE, Users_SaisieNouveauMotDePasse_Token_PAGEResponse>
    {
        private readonly IRepository repository;
        private readonly IHashService hashService;

        public Users_SaisieNouveauMotDePasse_Token_PAGEHandler(IRepository repository, IHashService hashService)
        {
            this.repository = repository;
            this.hashService = hashService;
        }

        public async override Task<Users_SaisieNouveauMotDePasse_Token_PAGEResponse> ExecuteAsync(Users_SaisieNouveauMotDePasse_Token_PAGE message)
        {
            var token = await repository.LoadAsync<TokenMotDePasseOublie>(message.Token);
            if (token == null)
                throw new Exception("token invalide");
            return new Users_SaisieNouveauMotDePasse_Token_PAGEResponse()
            {
            };
        }
    }

}