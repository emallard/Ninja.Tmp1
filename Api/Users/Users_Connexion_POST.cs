using System;
using System.Linq;

namespace Ninja.Tmp1
{

    public class Users_Connexion_POSTBodyValidators
    {
    }

    public class Users_Connexion_POST
    {
        public Email Email;
        public Password Password;
    }

    public class Users_Connexion_POSTResponse
    {
        public string token;
    }


    public class Users_Connexion_POSTHandler : IMessageHandler<Users_Connexion_POST, Users_Connexion_POSTResponse>
    {
        private readonly IRepository repository;

        public Users_Connexion_POSTHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public Users_Connexion_POSTResponse Execute(Users_Connexion_POST body)
        {
            var utilisateur = repository.Query<Utilisateur>().First(x => x.Email == body.Email.Value);
            if (utilisateur == null)
                throw new Exception("Validation Exception, Email, NotFound");

            return new Users_Connexion_POSTResponse()
            {
                token = utilisateur.Id.ToString()
            };
        }
    }
}
