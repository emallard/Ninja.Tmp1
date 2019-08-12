using System;

namespace Ninja.Tmp1
{

    public class Users_SaisieNouveauMotDePasse_Token_GET : IMessage<Users_SaisieNouveauMotDePasse_Token_GETResponse>
    {
        public Guid Token;
    }

    public class Users_SaisieNouveauMotDePasse_Token_GETResponse
    {
        public Submit<Users_SaisieNouveauMotDePasse_Token_POST, Void, object> Submit;
    }

}