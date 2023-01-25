using FAFscord.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
        where TAttribute : Attribute
        {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            return enumType.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }

        public static Guid GetGuid(this Enum value)
        {
            var attribute = GetAttribute<GuidAttribute>(value);

            if (attribute == null) return Guid.Empty;

            return new Guid(attribute.Value);
        }
    }
}
