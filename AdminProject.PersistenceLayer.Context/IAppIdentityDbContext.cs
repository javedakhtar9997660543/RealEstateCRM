using AdminProject.PersistenceLayer.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AdminProject.PersistenceLayer.Repository
{
    public interface IAppIdentityDbContext
    {
        DbSet<UserMaster> UserMasters { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
