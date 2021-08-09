using System.Collections.Generic;

namespace EFSamurai.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuoteStyle? QuoteStyle { get; set; }

        public int SamuraiId { get; set; }
        public Samurai Samurai { get; set; }
    }
}