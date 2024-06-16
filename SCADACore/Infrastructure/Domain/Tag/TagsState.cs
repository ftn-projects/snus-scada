using System.Runtime.Serialization;

namespace SCADACore.Infrastructure.Domain.Tag
{
    [DataContract]
    public class TagsState
    {
        [DataMember]
        public AnalogInputTag[] analogInputTags { get; set; }

        [DataMember]
        public AnalogOutputTag[] analogOutputTags { get; set; }

        [DataMember]
        public DigitalInputTag[] digitalInputTags { get; set; }

        [DataMember]
        public DigitalOutputTag[] digitalOutputTags { get; set; }
    }
}
