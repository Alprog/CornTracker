using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CornTracker
{
    class Parameters : Dictionary<string, Object>
    {
        Parameters() { }

        Parameters(Object[] values)
        {
            for (int i = 0; i < values.Length; i++)
                base.Add((string)values[i], values[i + 1]);
        }


    }
}