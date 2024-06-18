using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SCADACore.Infrastructure.Domain.Alarm;

namespace SCADACore.Infrastructure.Repository
{
    public class AlarmInvocationContext : DbContext
    {
        public DbSet<AlarmInvocation> AlarmInvocations { get; set; }
    }

    public class AlarmInvocationRepository
    {
        public static void Add(AlarmInvocation alarm)
        {
            using (var db = new AlarmInvocationContext())
            {
                db.AlarmInvocations.Add(alarm);
            }
        }

        public static List<AlarmInvocation> GetAll()
        {
            using (var db = new AlarmInvocationContext())
            {
                return db.AlarmInvocations.ToList();
            }
        }
    }
}