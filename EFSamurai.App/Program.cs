using System;
using System.Collections;
using System.Collections.Generic;
using EFSamurai.Data;
using EFSamurai.Domain;

namespace EFSamurai.App
{
    class Program
    {
        static void Main(string[] args)
        {
            AddOneSamurai();
            AddSomeSamurais();
        }

        private static void AddOneSamurai()
        {
            using SamuraiDbContext db = new();
            Samurai samurai = new() { Name = "Zelda" };
            db.Samurais.Add(samurai);
            db.SaveChanges();
        }

        private static void AddSomeSamurais()
        {
            IList<Samurai> newSamurai = new List<Samurai>()
            {
                new Samurai() { Name = "Harry" },
                new Samurai() { Name = "Liam" },
                new Samurai() { Name = "Zayn" },
            };

            using SamuraiDbContext db = new();
            db.AddRange(newSamurai);
            db.SaveChanges();
        }
    }
}
