using System;

namespace Ninja.Tmp1
{
    public class Users_MotDePasseOublie_GET : IMessage<Users_MotDePasseOublie_GETResponse>
    {

    }

    public class Users_MotDePasseOublie_GETResponse
    {
        public ISubmit<Users_MotDePasseOublie_POSTBody, Users_MotDePasseOublie_Confirmation_GET> Submit;
    }

    public class Users_MotDePasseOublie_POSTBody
    {
        public Email Email;
    }

    public class Users_MotDePasseOublie_POSTHandler
    {
        public void Execute(Users_MotDePasseOublie_POSTBody post)
        {

        }
    }
}