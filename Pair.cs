using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class Pair
    {
        public int Index { get; set; }
        public double Value { get; set; }

        public Pair(int index, double value)
        {
            Index = index;
            Value = value;
        }
    }
}
