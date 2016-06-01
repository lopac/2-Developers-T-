using System.Collections.Generic;
using IndirectlyApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IndirectlyApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IndirectlyApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        private static ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
        protected override void Seed(IndirectlyApp.Models.ApplicationDbContext context)
        {
            var mosaics = new List<Mosaic>();

            for (int i = 0; i < 10; i++)
            {
                var mosaic = new Mosaic();
                mosaic.Description = "Description of mosaic " + i;
                mosaic.User = _userManager.Users.First();
                mosaics.Add(mosaic);
            }

            var item1 = new Item()
            {
                AmazonUrl =
                    "http://www.amazon.com/Casio-MQ24-1E-Black-Resin-Watch/dp/B000GAWSHM/ref=sr_1_1?ie=UTF8&qid=1464751185&sr=8-1&keywords=watch",
                Height = 100,
                Width = 100,
                X = 100,
                Y = 100,
                Mosaic = mosaics[0]
            };

            var comments = new List<Comment>();

            for (int i = 0; i < 10; i++)
            {
                var comment = new Comment();
                comment.Body = "Test comment " + i;
                comment.User = _userManager.Users.First();
                comment.Mosaic = mosaics[i];
                comments.Add(comment);
            }

            db.Mosaics.AddRange(mosaics);
            db.Comments.AddRange(comments);
            db.SaveChanges();
        }
    }
}