using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Domain.Attributes
{
    public class GuidAttribute : Attribute
    {
        public GuidAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
