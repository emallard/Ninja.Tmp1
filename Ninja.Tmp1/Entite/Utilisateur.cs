using System;
using System.Threading.Tasks;
using CocoriCore;

namespace Ninja.Tmp1
{
    public class Utilisateur : IEntity
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FacebookId { get; set; }

        public DateTime dateInscription { get; set; }

        public bool EstUnClient { get; set; }

        public bool EstUnVendeur { get; set; }

        public bool EstUnAdmin { get; set; }

        public bool EstUnSuperAdmin { get; set; }
        public DateTime DateSuppression { get; set; }
    }
}