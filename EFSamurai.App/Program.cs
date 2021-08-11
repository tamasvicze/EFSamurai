using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using EFSamurai.Data;
using EFSamurai.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFSamurai.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddOneSamurai();
            //AddSomeSamurais();
            //AddSomeBattles();
            AddOneSamuraiWithRelatedData();
            //ClearDatabase();

            //READ Methods
            //ListAllSamuraiNames();
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

        private static void AddSomeBattles()
        {
            using SamuraiDbContext db = new();

            IList<Battle> battles = new List<Battle>()
            {
                new()
                {
                    Name = "The Battle of Boybands",
                    Description = "The first battle ever documented in Samurai history",
                    StartDate = new DateTime(2011, 11, 18),
                    EndDate = new DateTime(2012, 11, 09),
                    BattleLog = new BattleLog()
                    {
                        Name = "Log of the Battle of Boybands",
                        BattleEvents = new List<BattleEvent>()
                        {
                            new()
                            {
                                Description = "They guys look too fresh to fight.",
                                Summary = "Liam recommends a pillowfight instead.",
                                Order = 01
                            },
                            new()
                            {
                                Description = "Harry doesn't want to get his hands dirty.",
                                Summary = "Harry cut his hair so every girls hear broke",
                                Order = 02
                            }
                        }
                    }
                },
                new()
                {
                    Name = "The Battle of the O2 Arena",
                    Description = "A battle for the most instagram followers",
                    StartDate = new DateTime(2013, 02, 23),
                    EndDate = new DateTime(2013, 02, 26),
                    BattleLog = new BattleLog()
                    {
                        Name = "Log of Battle of the O2 Arena",
                        BattleEvents = new List<BattleEvent>()
                        {
                            new()
                            {
                                Description = "The guys are selling out O2 Arena in London",
                                Summary = "Their instagram followers are going crazy beacuse of the ticket giveaway",
                                Order = 01
                            },
                            new()
                            {
                                Description = "Zayn took the microphone in his hand and began signing. ",
                                Summary = "Singing is better than killing people.",
                                Order = 02
                            }
                        }
                    }

                }
            };

            db.Battles.AddRange(battles);
            db.SaveChanges();
        }

        public static void AddOneSamuraiWithRelatedData()
        {
            using SamuraiDbContext db = new();

            Samurai samurai = new()
            {
                Name = "Harry Styles",
                Hairstyle = Hairstyle.Eastern,
                Quotes = new List<Quote>()
                {
                    new()
                    {
                        QuoteStyle = QuoteStyle.Cheesy, Text = "Everybody wanna steal my gi-i-irl"
                    }
                },
                SecretIdentity = new()
                {
                    RealName = "Harry Bad-Dresser"
                },
                SamuraiBattle = new List<SamuraiBattle>()
                {
                    new()
                    {
                        //The Samurai object part of the many to many table is already made, so only a Battle needs to be created
                        Battle = new()
                        {
                            Name = "The Battle of The British X-Factor",
                            Description = "This battle happened after Zayn Malik tried to quit the band.",
                            IsBrutal = true,
                            StartDate = new DateTime(2015, 05, 10),
                            EndDate = new DateTime(),

                            BattleLog = new()
                            {
                                Name = "Log for The Battle of The British X-Factor",
                                BattleEvents = new List<BattleEvent>()
                                {
                                    new()
                                    {
                                        Description =
                                            "BBC had exclusive rights for coverage of the X-Factor, which made their stocks increase by +400%",
                                        Summary = "So Simon Pawell was the host, which started this whole thing...",
                                        Order = 01
                                    }
                                },
                            }
                        }
                    }

                }
            };
            db.Samurais.Add(samurai);
            db.SaveChanges();
        }

        public static void ClearDatabase()
        {
            using SamuraiDbContext db = new();
            db.RemoveRange(db.Samurais);
            db.RemoveRange(db.Battles);

            db.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Samurais', RESEED, 1)");
            db.Database.ExecuteSqlRaw("DBCC CHECKIDENT('SecretIdentities', RESEED, 1)");
            db.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Quotes', RESEED, 1)");
            db.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Battles', RESEED, 1)");
            db.Database.ExecuteSqlRaw("DBCC CHECKIDENT('BattleLogs', RESEED, 1)");
            db.Database.ExecuteSqlRaw("DBCC CHECKIDENT('BattleEvents', RESEED, 1)");
            db.SaveChanges();
        }

        //Read-methods
        public static void ListAllSamuraiNames()
        {
            using SamuraiDbContext db = new();

            var query = from name in db.Samurais.AsEnumerable() select name.Name;
            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }

        public static void ListAllSamuraiNames_OrderByName()
        {
            using SamuraiDbContext db = new();

            var query = from name in db.Samurais.AsEnumerable() orderby name.Name select name.Name;
            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }
    }
}
