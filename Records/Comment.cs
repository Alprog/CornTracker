using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace CornTracker
{
    public class Comment : TimeRecord
    {
        public Comment() { }
        public Comment(NpgsqlDataReader reader) : base(reader) { }

        [Field] virtual public int node { get; set; }
        [Field] virtual public string text { get; set; }
        [Field] virtual public int author { get; set; }

    }
}
