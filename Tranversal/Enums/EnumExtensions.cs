using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tranversal.Enums;

    public static class EnumExtensions
    {
        public static string? GetDescription(this Enum value)
        {
            var type = value.GetType();

            if (type.GetField(value.ToString()) is FieldInfo member)
            {
                var attribute = member.GetCustomAttribute<EnumFieldDescriptionAttribute>();
                return attribute?.Description ?? null;
            }

            return null;

        }
    }

