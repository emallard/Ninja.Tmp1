using System;
using CocoriCore;

namespace Ninja.Tmp1
{

    public class Users_MotDePasseOublie_POST : IMessage<Users_MotDePasseOublie_POSTResponse>, ICommand
    {
        public Email Email;
    }

    public class Users_MotDePasseOublie_POSTResponse
    {

    }

    public class Users_MotDePasseOublie_POSTHandler
    {
        public void Execute(Users_MotDePasseOublie_POST post)
        {

        }
    }
}