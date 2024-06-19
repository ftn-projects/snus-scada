using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SCADACore.Infrastructure.Domain.Alarm;
using SCADACore.Infrastructure.Domain.Enumeration;

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
                db.SaveChanges();
            }
        }

        public static List<AlarmInvocation> GetAll()
        {
            using (var db = new AlarmInvocationContext())
            {
                return db.AlarmInvocations.ToList();
            }
        }

        public static void Wipe()
        {
            using (var db = new TagValueContext())
            {
                db.Database.ExecuteSqlCommandAsync("TRUNCATE TABLE [AlarmInvocations]");
            }
        }

        public static List<AlarmInvocation> GetAlarmsInPeriod(DateTime start, DateTime end)
        {

            using(var db = new AlarmInvocationContext())
            {
                return db.AlarmInvocations.Where(a => a.Timestamp >= start && a.Timestamp <= end)
                    .OrderBy(a => a.Priority)
                    .ThenBy(a => a.Timestamp)
                    .ToList();
            }
        }
        public static List<AlarmInvocation> GetAlarmsByPriority(Priority priority)
        {
            using (var db = new AlarmInvocationContext())
            {
                return db.AlarmInvocations.Where(a => a.Priority == priority)
                    .OrderBy(a => a.Timestamp)
                    .ToList();
            }
        }
    }
}