using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeUI
{
    public class Simple
    {
        public static SamuraiContext _context = new SamuraiContext();
        public static void DeleteUsingId(int samuraiId)
        {
            var samurai = _context.Samurais.Find(samuraiId);
            _context.Remove(samurai);
            _context.SaveChanges();
        }

        public static void DeletedSamuraiWhileTracked()
        {
            var samurai = _context.Samurais.Where(s => s.Name == "JulieSan");
            _context.Samurais.RemoveRange(samurai);
            // Some alternate
            // _context.Remove(samurai);
            //  _context.Samurais.Remove(_context.Samurais.Find(1));
            _context.SaveChanges();
        }

        public static void QueryAndUpdateBattle_Disconnected()
        {
            var battle = _context.Battles.FirstOrDefault();
            battle.EndDate = new DateTime(2018, 11, 07);
            using (var newContextInstance = new SamuraiContext())
            {
                newContextInstance.Battles.Update(battle);
                newContextInstance.SaveChanges();
            }
        }

        public static void RetriveAndUpdateMultipleSamurais()
        {
            var samurais = _context.
                    Samurais
                    .ToList();
            samurais.ForEach(s => s.Name += "San");
            _context.SaveChanges();
        }

        public static void RetriveAndUpdateSamurais()
        {
            var samurai = _context
                    .Samurais
                    .FirstOrDefault();
            samurai.Name += "San";
            _context.SaveChanges();
        }

        public static void MoreQueries()
        {
            var samurais = _context
                    .Samurais
                    .Where(s => EF.Functions.Like(s.Name, "J%"))
                    .ToList();
        }

        public static void SimpleSamuraiQuery()
        {
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais.ToList();
            }
        }

        public static void InsertMultipleDifferentObjects()
        {
            var samurai = new Samurai { Name = "Oda Nobunga" };
            var battle = new Battle
            {
                Name = "Battle Of Panipat",
                StartDate = new DateTime(2018, 07, 17),
                EndDate = new DateTime(2018, 09, 19)
            };
            using (var context = new SamuraiContext())
            {
                context.AddRange(samurai, battle);
                context.SaveChanges();
            }
        }

        public static void InsertMultipleSamurais()
        {
            var samuraiSammy = new Samurai { Name = "Sammy" };
            var samurai = new Samurai { Name = "Julie" };
            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(samurai, samuraiSammy);
                context.SaveChanges();
            }

        }

        public static void InsertSamurai()
        {
            var samurai = new Samurai { Name = "Julie" };
            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }
    }
}
