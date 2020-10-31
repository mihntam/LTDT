using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FordBellman
{
    class WeightMatrix
    {
        public int iVetices;
        public int iEdges;
        public int[,] iMatrix;

        public WeightMatrix(int numberV, int numbeE)
        {
            iVetices = numberV;
            iEdges = numbeE;
            iMatrix = new int[iVetices, iVetices];
        }
    }
}
