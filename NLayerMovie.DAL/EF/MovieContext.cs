using Microsoft.AspNet.Identity.EntityFramework;
using NLayerMovie.DAL.Entities;
using System.Data.Entity;


namespace NLayerMovie.DAL.EF
{
    public class MovieContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Upvote> Upvotes{ get; set; }

        public MovieContext() : base("NlayerMovie")
        {
        }
        public MovieContext(string connectionString)
            : base(connectionString)
        {
        }
    }    
}
