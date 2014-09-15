using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CornTracker
{
    public class Parameter
    {
        public string Name;
        public bool IsSQLString;
        public Object Value;

        public Parameter(string Name, object Value)
        {
            this.Name = Name;
            this.Value = Value.GetType().IsEnum ? (int)Value : Value;
            IsSQLString = false;
        }

        public Parameter(string Name, string SQLValue)
        {
            this.Name = Name;
            this.Value = SQLValue;
            IsSQLString = true;
        }

        public string SQLString
        {
            get {
                if (IsSQLString)
                    return (string)Value;
                else
                    return "@" + Name;
            }
        }

    }
}