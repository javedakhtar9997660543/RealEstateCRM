using DreamWedds.PersistenceLayer.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DreamWedds.PersistenceLayer.Repository
{
    public interface IAppIdentityDbContext
    {
        DbSet<UserMaster> UserMasters { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
