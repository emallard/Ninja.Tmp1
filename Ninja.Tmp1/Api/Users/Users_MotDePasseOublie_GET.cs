using System;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class Users_MotDePasseOublie_GET : IMessage<Users_MotDePasseOublie_GETResponse>
    {

    }

    public class Users_MotDePasseOublie_GETResponse
    {
        public Submit<Users_MotDePasseOublie_POST, Users_MotDePasseOublie_POSTResponse, Users_MotDePasseOublie_Confirmation_GET> Submit;
    }

}