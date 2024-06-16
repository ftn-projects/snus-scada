using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADACore.Infrastructure.Domain.Enumeration
{
    public abstract class EnumUtils
    {
        public static T ParseEnum<T>(string value)
        {
            return (T) Enum.Parse(typeof(T), value, true);
        }
    }
}