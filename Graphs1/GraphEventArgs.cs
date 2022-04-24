using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs1
{
    class GraphEventArgs<T>:EventArgs
    {
        public GraphEventArgs(T from, T to)
        {
            From = from;
            To = to;
        }

        public T From { get; set; }
        public T To { get; set; }
    }
}
