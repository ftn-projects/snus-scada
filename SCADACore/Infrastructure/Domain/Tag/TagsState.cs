using System.Runtime.Serialization;

namespace SCADACore.Infrastructure.Domain.Tag
{
    [DataContract]
    public class TagsState
    {
        [DataMember]
        public AnalogInputTag[] AnalogInputTags { get; set; }

        [DataMember]
        public AnalogOutputTag[] AnalogOutputTags { get; set; }

        [DataMember]
        public DigitalInputTag[] DigitalInputTags { get; set; }

        [DataMember]
        public DigitalOutputTag[] DigitalOutputTags { get; set; }
    }
}
