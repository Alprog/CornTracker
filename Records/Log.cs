using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace CornTracker
{
    class Log : TimeRecord
    {
        public Log() { }
        public Log(NpgsqlDataReader reader) : base(reader) { }

        [Field] virtual public int node { get; set; }
        [Field] virtual public int author { get; set; }
        [Field] virtual public int action { get; set; }
        [Field] virtual public int param { get; set; }
    }
}
