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
    public class Related
    {
        private static SamuraiContext _context = new SamuraiContext();
        public static void InsertNewPkFkGraph()
        {
            var samurai = new Samurai
            {
                Name = "Kambei Shimada",
                Quotes = new List<Quote>
                {
                    new Quote { Text = "I've come to save ypu"}
                }
            };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        public static void AddChildToExistingObjectWithTracked()
        {
            var samurai = _context.Samurais.First();
            samurai.Quotes.Add(new Quote
            {
                Text = "I bet you're happy that I've saved you!"
            });
            _context.SaveChanges();
        }

        public static void ModifyingRelatedDataWhenNotTracked()
        {
            var samurai = _context.Samurais.Include(s => s.Quotes).FirstOrDefault();
            var quote = samurai.Quotes[0];
            quote.Text += "Did you hear that?";
            using(var newContext = new SamuraiContext())
            {
                // newContext.Quotes.Update(quote);
                newContext.Entry(quote).State = EntityState.Modified;
                newContext.SaveChanges();
            }
        }

        public static void ModifyingRelatedDataWhenTracked()
        {
            var samurai = _context.Samurais.Include(s => s.Quotes).FirstOrDefault();
            samurai.Quotes[0].Text += "Did you hear that?";
            _context.SaveChanges();
        }

        public static void ProjectSomeProperties()
        {
            var someProperties = _context.Samurais.Select(s => new { s.Id, s.Name, s.Quotes }).ToList();
        }

        public static void EggerLoadSamuraiWithQuotes()
        {
            var samuraiWithQuotes = _context
                                        .Samurais
                                        .Where(s => s.Name.Contains("Julie"))
                                        .Include(s => s.Quotes)
                                        .Include(s => s.SecretIdentity)
                                        .FirstOrDefault();
        }

        public static void AddToExistingChildWhileNotTracked(int samuraiId)
        {
            //var samurai = _context.Samurais.First();
            var quote = new Quote
            {
                Text = " Now that I saved you, will you feed me dinner?",
                SamuraiId = samuraiId
            };
            using(var newContext = new SamuraiContext())
            {
                newContext.Quotes.Add(quote);
                newContext.SaveChanges();
            }
        }
    }
}
