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
                string type = tag is AnalogInputTag ? nameof(AnalogInputTag) : nameof(DigitalInputTag); // Mislim da moze bolje
                db.TagValues.Add(new InputTagValue(tag.TagName, tag.DriverType, value, timestamp, type));
                db.SaveChanges();
            }
        }

        public static List<InputTagValue> GetAll()
        {
            using (var db = new TagValueContext())
            {
                return db.TagValues.ToList();
            }
        }

        public static void Wipe()
        {
            using (var db = new TagValueContext())
            {
                db.Database.ExecuteSqlCommandAsync("TRUNCATE TABLE [InputTagValues]");
            }
        }
        
        public static List<InputTagValue> GetValuesInPeriod(DateTime start, DateTime end)
        {
            using (var db = new TagValueContext())
            {
                return db.TagValues.Where(value => value.Timestamp >= start && value.Timestamp <= end).ToList();
            }
        }
        
        public static List<InputTagValue> GetValuesByTagType(string tagType)
        {
            using (var db = new TagValueContext())
            {
                return db.TagValues.Where(value => value.InputTagType == tagType).ToList();
            }
        }
        
        public static List<InputTagValue> GetValuesByTagName(string tagName)
        {
            using (var db = new TagValueContext())
            {
                return db.TagValues.Where(value => value.TagName == tagName).ToList();
            }
        }
    }
}