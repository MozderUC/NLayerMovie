using Microsoft.AspNet.Identity.EntityFramework;
using NLayerMovie.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NLayerMovie.DAL.EF
{
    public class MovieContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }

        public MovieContext() : base("NlayerMovie")
        {
        }
        public MovieContext(string connectionString)
            : base(connectionString)
        {
        }
    }    
}
