namespace Ninja.Tmp1
{
    public class Users_Inscription_GET : IMessage<Users_Inscription_GETResponse>
    {
        public ISubmit<Users_Inscription_POST, object> Submit;
    }

    public class Users_Inscription_GETResponse
    {
        public ISubmit<Users_Inscription_POST, Vendeur_Dashboard_GET> Submit;
    }

    public class Users_Inscription_POST : IMessage<Users_Inscription_POSTResponse>
    {
        public string Email;
        public string Password;
        public string PasswordConfirmation;
        public string Nom;
        public string Prenom;
        public string DateNaissance;
    }

    public class Users_Inscription_POSTResponse
    {
        public string jwt;
    }

    public class Users_Inscription_POSTHandler : IMessageHandler<Users_Inscription_POST, Users_Inscription_POSTResponse>
    {
        public Users_Inscription_POSTResponse Execute(Users_Inscription_POST post)
        {
            return new Users_Inscription_POSTResponse() { jwt = "jwt" };
        }
    }
}