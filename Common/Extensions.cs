using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CornTracker
{
    public static class Extensions
    {
        public static string Tag(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            Tag[] attribs = fieldInfo.GetCustomAttributes(typeof(Tag), false) as Tag[];
            return attribs.Length > 0 ? attribs[0].value : null;
        }
    }
}
