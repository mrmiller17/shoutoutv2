using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ShoutoutProgram.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Added Sets
        public DbSet<Shoutout> Shoutouts { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<Event> Events { get; set; }
        #endregion

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}