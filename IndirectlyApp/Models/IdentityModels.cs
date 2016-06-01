using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IndirectlyApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Mosaic> Mosaics { get; set; }
        public DbSet<Item> Items { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Mosaic>()
                        .HasMany<ApplicationUser>(s => s.LikedBy)
                        .WithMany(c => c.LikedMosaics)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("MosaicId");
                            cs.MapRightKey("UserId");
                            cs.ToTable("MosaicLikedBy");
                        });

            base.OnModelCreating(modelBuilder);
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}