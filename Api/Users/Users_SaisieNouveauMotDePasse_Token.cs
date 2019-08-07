using System;

namespace Ninja.Tmp1
{

    public class Users_SaisieNouveauMotDePasse_Token_GET : IRoutable<Guid>, IMessage<Users_SaisieNouveauMotDePasse_Token_GETResponse>
    {
        public Users_SaisieNouveauMotDePasse_Token_GET(Guid token)
        {
            this.Token = token;
        }
        public Guid R1 => Token;
        public Guid Token;
    }

    public class Users_SaisieNouveauMotDePasse_Token_GETResponse
    {
        public ISubmit<Users_SaisieNouveauMotDePasse_Token_POST, object> Submit;
    }

    public class Users_SaisieNouveauMotDePasse_Token_POST : IRoutable<Guid>
    {
        public Guid R1 => Token;
        public Guid Token;
        public Password Password;
        public Password PasswordConfirmation;
    }

}