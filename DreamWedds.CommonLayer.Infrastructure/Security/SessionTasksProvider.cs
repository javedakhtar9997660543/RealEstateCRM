using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamWedds.CommonLayer.Application.AppSettings;
using DreamWedds.CommonLayer.Application.Model.Security;
using DreamWedds.CommonLayer.Infrastructure.Security;
using DreamWedds.PersistenceLayer.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Exception = System.Exception;

namespace DreamWedds.PersistenceLayer.Repository.Security
{
    public class SessionTasksProvider
    {
        readonly Func<DateTime> _clock;
        private readonly AdminDbContext _dbContext;
        private readonly AppSettings _settings;

        public SessionTasksProvider(AdminDbContext dbContext, Func<DateTime> clock, IOptions<AppSettings> settings)
        {
            _dbContext = dbContext;
            _clock = clock;
            _settings = settings.Value;
        }

        public bool IsSessionValid(long logId)
        {
            var maxExtensionTime = _clock().AddMinutes(-1 * Convert.ToInt32(_settings.SessionTimeout));

            //if (_securityContext.User == null)
            //{
            //    return false;
            //}

            return (from session in _dbContext.Set<DailyLoginHistory>()
                where session.Id == logId
                      && session.LogOutTime == null
                      && (session.LoginTime > maxExtensionTime || session.LastExtension != null && session.LastExtension > maxExtensionTime)
                select true).SingleOrDefault();
        }
        public IEnumerable<ValidSecurityTask> ListAvailableTasks(int? userId = null)
        {
            return AvailableTasks(userId).Values;
        }

        public bool HasAccessTo(ApplicationTask applicationTask)
        {
            return AvailableTasks().TryGetValue((short) applicationTask, out _);
        }

        public bool HasAccessTo(ApplicationTask applicationTask, ApplicationTaskAccessLevel level)
        {
            return AvailableTasks().TryGetValue((short) applicationTask, out var task) && HasAccess(task, level);
        }

        IDictionary<short, ValidSecurityTask> AvailableTasks(int? userId = null)
        {
            //var identityId = userId ?? _securityContext.User.Id;
            throw new Exception();
        }

        //IQueryable<ValidSecurityTask> AvailableTasksFromDb(int userId)
        //{
        //    var today = _clock().Date;

        //    var tasks = _dbContext.PermissionsGranted(userId, "TASK", null, null, today)
        //        .Where(_ => _.CanExecute || _.CanDelete || _.CanInsert || _.CanUpdate);

        //    return from t in tasks
        //        select new ValidSecurityTask
        //        {
        //            TaskId = (short) t.ObjectIntegerKey,
        //            CanInsert = t.CanInsert,
        //            CanUpdate = t.CanUpdate,
        //            CanDelete = t.CanDelete,
        //            CanExecute = t.CanExecute
        //        };
        //}

        //public static IQueryable<PermissionsGrantedItem> PermissionsGranted(this AdminDbContext dbContext, int UserId, string objectTable, int? objectIntegerKey, string objectStringKey, DateTime today)
        //{
        //    var ctx = dbContext as SqlDbContext;

        //    return ctx == null
        //        ? FromInMemoryContext<PermissionsGrantedItem>(dbContext)
        //        : ctx.PermissionsGranted(UserId, objectTable, objectIntegerKey, objectStringKey, today);
        //}

        //[DbFunction("CodeFirstDatabaseSchema", "fn_PermissionsGranted")]
        //public IQueryable<PermissionsGrantedItem> PermissionsGranted(int userIdentityId, string objectTable, int? objectIntegerKey, string objectStringKey, DateTime today)
        //{
        //    var intKey = objectIntegerKey.HasValue;
        //    var strKey = !string.IsNullOrWhiteSpace(objectStringKey);

        //    var parameters = new[]
        //    {
        //        new ObjectParameter("pnIdentityKey", userIdentityId),
        //        new ObjectParameter("psObjectTable", objectTable),
        //        intKey ? new ObjectParameter("pnObjectIntegerKey", objectIntegerKey) : new ObjectParameter("pnObjectIntegerKey", typeof(int?)),
        //        strKey ? new ObjectParameter("psObjectStringKey", objectStringKey) : new ObjectParameter("psObjectStringKey", typeof(string)),
        //        new ObjectParameter("pdtToday", today)
        //    };

        //    var ctx = ((IObjectContextAdapter)this).ObjectContext;
        //    return ctx.CreateQuery<PermissionsGrantedItem>($"[{GetType().Name}].[fn_PermissionsGranted](@pnIdentityKey, @psObjectTable, @pnObjectIntegerKey, @psObjectStringKey, @pdtToday)", parameters);
        //}

        static IQueryable<T> FromInMemoryContext<T>(AdminDbContext dbContext) where T : class
        {
            return dbContext.Set<T>().AsQueryable();
        }

        static bool HasAccess(ValidSecurityTask task, ApplicationTaskAccessLevel level)
        {
            var hasAccess = true;

            hasAccess &= (level & ApplicationTaskAccessLevel.Create) != ApplicationTaskAccessLevel.Create ||
                         task.CanInsert;
            hasAccess &= (level & ApplicationTaskAccessLevel.Modify) != ApplicationTaskAccessLevel.Modify ||
                         task.CanUpdate;
            hasAccess &= (level & ApplicationTaskAccessLevel.Delete) != ApplicationTaskAccessLevel.Delete ||
                         task.CanDelete;
            hasAccess &= (level & ApplicationTaskAccessLevel.Execute) != ApplicationTaskAccessLevel.Execute ||
                         task.CanExecute;

            return hasAccess;
        }
    }
}
