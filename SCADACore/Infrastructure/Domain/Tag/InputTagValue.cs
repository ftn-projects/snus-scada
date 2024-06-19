using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using SCADACore.Infrastructure.Domain.Enumeration;

namespace SCADACore.Infrastructure.Domain.Tag
{
    [DataContract]
    public class InputTagValue
    {
        [Key]
        public int Id { get; set; }
        [DataMember]
        public string TagName { get; set; }
        [DataMember]
        public DriverType DriverType { get; set; }
        [DataMember]
        public double Value { get; set; }
        [DataMember]
        public DateTime Timestamp { get; set; }

        public InputTagValue(string tagName, DriverType driverType, double value, DateTime timestamp)
        {
            TagName = tagName;
            DriverType = driverType;
            Value = value;
            Timestamp = timestamp;
        }
    }
}