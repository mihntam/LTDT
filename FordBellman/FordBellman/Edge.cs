using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordBellman
{
    class Edge
    {
        public int iSource { get; set; }
        public int iDetination { get; set; }
        public int iWeight { get; set; }
        public Edge(int source = 0, int detination = 0, int weight = 0)
        {
            iSource = source;
            iDetination = detination;
            iWeight = weight;
        }

    }
}
