using SCADACore.Infrastructure.Domain;
using System.Data.Entity;

namespace SCADACore.Infrastructure.Repository
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
