using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CornTracker
{

    class TextObject<T>
    {
        private string Text;
        public T Value;

        public TextObject(string text, T value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }

        public static implicit operator T( TextObject<T> obj )
        {
            return obj.Value;
        }

    }

}
