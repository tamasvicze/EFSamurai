using System;
using System.Collections.Generic;

namespace EFSamurai.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Hairstyle? Hairstyle { get; set; }

        public ICollection<Quote> Quotes { get; set; }
        public SecretIdentity SecretIdentity { get; set; }
        public List<SamuraiBattle> SamuraiBattle { get; set; }

        private ICollection<SamuraiBattle> SamuraiBattles;
    }
}


