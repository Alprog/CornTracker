
using Npgsql;
using System;
using System.Collections.Generic;
using BrightIdeasSoftware;

namespace CornTracker
{
    public class User : Record
    {
        protected User() { }
        public User(NpgsqlDataReader reader) : base(reader) { }

        [Field] virtual public string login { get; set; }
        [Field] virtual public string name { get; set; }
        [Field] virtual public string password { get; set; }
        [Field] virtual public int job { get; set; }

        public override string ToString()
        {
            return name;
        }

    }
}
