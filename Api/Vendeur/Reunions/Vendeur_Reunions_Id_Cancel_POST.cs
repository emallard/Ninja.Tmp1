using System;
using System.Collections.Generic;

namespace Ninja.Tmp1
{

    public class Vendeur_Reunions_Id_Cancel_POST : IMessage<Void>, IRoutable<Guid>
    {
        public Guid R1 => Id;
        public Guid Id;

        public Vendeur_Reunions_Id_Cancel_POST(Guid id)
        {
            Id = id;
        }
    }

    public class Vendeur_Reunions_Id_Cancel_POSTHandler : IMessageHandler<Vendeur_Reunions_Id_Cancel_POST, Void>
    {
        private readonly IRepository repository;

        public Vendeur_Reunions_Id_Cancel_POSTHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public Void Execute(Vendeur_Reunions_Id_Cancel_POST post)
        {
            return new Void();
        }
    }

}