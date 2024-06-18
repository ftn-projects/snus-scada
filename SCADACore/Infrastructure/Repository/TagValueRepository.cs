using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SCADACore.Infrastructure.Domain.Tag;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;

namespace SCADACore.Infrastructure.Repository
{
    public class TagValueContext : DbContext
    {
        public DbSet<InputTagValue> TagValues { get; set; }
    }

    public static class TagValueRepository
    {
        public static void Add(InputTag tag, double value, DateTime timestamp)
        {
            using (var db = new TagValueContext())
            {
                db.TagValues.Add(new InputTagValue(tag.TagName, tag.DriverType, value, timestamp));
            }
        }

        public static List<InputTagValue> GetAll()
        {
            using (var db = new TagValueContext())
            {
                return db.TagValues.ToList();
            }
        }
    }
}