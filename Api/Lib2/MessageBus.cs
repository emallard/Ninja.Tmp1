using System;
using System.Threading.Tasks;

namespace Ninja.Tmp1
{

    public class MessageBus : IMessageBus
    {
        public MessageBus()
        {
        }

        public T Execute<T>(IMessage<T> t)
        {
            return (T)this.Execute((object)t);
        }

        public object Execute(object o)
        {
            if (o is Users_Connexion_GET connexionGet)
                return new Users_Connexion_GETHandler().Execute(connexionGet);
            if (o is Users_Inscription_GET inscription)
                return new Users_Inscription_GETResponse();
            if (o is Users_Inscription_POST inscriptionPost)
                return new Users_Inscription_POSTHandler().Execute(inscriptionPost);
            if (o is Vendeur_Dashboard_GET vendeur_Dashboard_GET)
                return new Vendeur_Dashboard_GETHandler().Execute(vendeur_Dashboard_GET);

            throw new Exception("MessageBus");
        }
    }
}