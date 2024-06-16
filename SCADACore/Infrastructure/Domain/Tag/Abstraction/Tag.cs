﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADACore.Infrastructure.Domain.Tag.Abstraction
{
    [DataContract]
    public abstract class Tag
    {
        [DataMember]
        public string TagName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int IOAddress { get; set; }


    }
}