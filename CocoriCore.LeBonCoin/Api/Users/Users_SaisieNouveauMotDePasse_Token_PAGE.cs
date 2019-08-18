using System;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Users_SaisieNouveauMotDePasse_Token_PAGE : IPage<Users_SaisieNouveauMotDePasse_Token_PAGEResponse>
    {
        public Guid Token;
    }

    public class Users_SaisieNouveauMotDePasse_Token_PAGEResponse
    {
        public Form<Users_SaisieNouveauMotDePasse_Token_POST, Void, Users_SaisieNouveauMotDePasse_Token_PAGE> Form;
    }

}