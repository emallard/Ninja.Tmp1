using System;

namespace CocoriCore.LeBonCoin
{

    public class Users_SaisieNouveauMotDePasse_Token_POST
    {
        public Guid Token;
        public Password Password;
        public Password PasswordConfirmation;
    }

}