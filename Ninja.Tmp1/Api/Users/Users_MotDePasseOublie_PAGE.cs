using System;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class Users_MotDePasseOublie_PAGE : IMessage<Users_MotDePasseOublie_PAGEResponse>
    {

    }

    public class Users_MotDePasseOublie_PAGEResponse
    {
        public Form<Users_MotDePasseOublie_POST, Users_MotDePasseOublie_POSTResponse, Users_MotDePasseOublie_Confirmation_PAGE> Submit;
    }

}