using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class Rows
    {
        public int row1 { get; set; }
        public int row2 { get; set; }
        public int row3 { get; set; }

        public Rows(int _row1, int _row2, int _row3)
        {
            row1 = _row1;
            row2 = _row2;
            row3 = _row3;
        }
    }
}
