using System;
using System.Collections.Generic;

namespace EFSamurai.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public ICollection<Quote> Quotes { get; set; }

        public SecretIdentity SecretIdentity { get; set; }
        private ICollection<SamuraiBattle> SamuraiBattles;
    }
}
