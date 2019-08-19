using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Users_MotDePasseOublie_POST : IMessage<Users_MotDePasseOublie_POSTResponse>, ICommand
    {
        public string Email;
    }

    public class Users_MotDePasseOublie_POSTResponse
    {
        public Users_MotDePasseOublie_Confirmation_PAGE Redirect = new Users_MotDePasseOublie_Confirmation_PAGE();
    }

    public class Users_MotDePasseOublie_POSTHandler : MessageHandler<Users_MotDePasseOublie_POST, Users_MotDePasseOublie_POSTResponse>
    {
        private readonly IEmailSender emailSender;
        private readonly IRepository repository;

        public Users_MotDePasseOublie_POSTHandler(IEmailSender emailSender, IRepository repository)
        {
            this.emailSender = emailSender;
            this.repository = repository;
        }
        public async override Task<Users_MotDePasseOublie_POSTResponse> ExecuteAsync(Users_MotDePasseOublie_POST query)
        {
            var token = new TokenMotDePasseOublie()
            {
                Id = Guid.NewGuid(),
                IdUtilisateur = Guid.Empty
            };
            await repository.InsertAsync(token);


            await this.emailSender.Send(new MyMailMessage<EmailMotDePasseOublie>()
            {
                From = "from@example.com",
                To = "aa@aa.aa",
                Body = new EmailMotDePasseOublie()
                {
                    Lien = new Users_SaisieNouveauMotDePasse_Token_PAGE()
                    {
                        Token = token.Id
                    }
                }
            });
            return new Users_MotDePasseOublie_POSTResponse();
        }
    }
}