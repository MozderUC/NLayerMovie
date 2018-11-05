using NLayerMovie.DAL.EF;
using NLayerMovie.DAL.Entities;
using NLayerMovie.DAL.Interfaces;

namespace NLayerMovie.DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public MovieContext Database { get; set; }
        public ClientManager(MovieContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
