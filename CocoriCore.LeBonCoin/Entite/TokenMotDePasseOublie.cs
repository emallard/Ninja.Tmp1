using System;

namespace CocoriCore.LeBonCoin
{
    public class TokenMotDePasseOublie : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdUtilisateur { get; set; }
    }
}