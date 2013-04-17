using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class CombinationObject
    {

        public int Row1 { get; set; }
        public int Row2 { get; set; }
        public int Row3 { get; set; }
        public double MoveValue { get; set; }
        public int Count { get; set; }

        public CombinationObject(int rowA, int rowB, int rowC)
        {
            Row1 = rowA;
            Row2 = rowB;
            Row3 = rowC;
        }

        public String printCombo()
        {
            return Row1 + " " + Row2 + " " + Row3 + " ";
        }
    }
}
