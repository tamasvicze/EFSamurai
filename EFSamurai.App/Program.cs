using System;
using System.Collections;
using System.Collections.Generic;
using EFSamurai.Data;
using EFSamurai.Domain;
using Microsoft.EntityFrameworkCore.Design;

namespace EFSamurai.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddOneSamurai();
            //AddSomeSamurais();
        }

        #region AddOneSamurai
        private static void AddOneSamurai()
        {
            using SamuraiDbContext db = new();
            Samurai samurai = new() { Name = "Zelda" };
            db.Samurais.Add(samurai);
            db.SaveChanges();
        }
        #endregion


        #region AddSomeSamurais
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
        #endregion


        #region AddSomeBattles
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

        #endregion

        #region AddOneSamuraiWithRelatedData
        


        #endregion
    }
}
