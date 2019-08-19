using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace CocoriCore.LeBonCoin
{

    public class Users_Connexion_POSTBodyValidators
    {
    }

    public class Users_Connexion_POST : ICommand, IMessage<Users_Connexion_POSTResponse>
    {
        public string Email;
        public string Password;
    }

    public class Users_Connexion_POSTResponse
    {
        public string Token;
        public Vendeur_Dashboard_PAGE Redirect;
    }


    public class Users_Connexion_POSTHandler : MessageHandler<Users_Connexion_POST, Users_Connexion_POSTResponse>
    {
        private readonly IRepository repository;

        public Users_Connexion_POSTHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public override async Task<Users_Connexion_POSTResponse> ExecuteAsync(Users_Connexion_POST command)
        {
            var utilisateur = await repository.Query<Utilisateur>().Where(x => x.Email == command.Email).FirstOrDefaultAsync();
            if (utilisateur == null)
                throw new Exception("Validation Exception, Email, NotFound");

            return new Users_Connexion_POSTResponse()
            {
                Token = utilisateur.Id.ToString(),
                Redirect = new Vendeur_Dashboard_PAGE()
            };
        }
    }
}
