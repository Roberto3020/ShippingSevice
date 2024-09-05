using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranversal.Enums;
    public class EnumFieldDescriptionAttribute : Attribute
    {
        public EnumFieldDescriptionAttribute(string value) { Description = value; }
        public string Description { get; }
    }

