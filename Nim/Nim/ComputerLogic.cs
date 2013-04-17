	﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
//using Nim;


namespace Nim
{

    class ComputerLogic
    {
        ArrayList turnCombos = new ArrayList();

        public ComputerLogic(int row1, int row2, int row3)
        {
            Random gen = new Random();
            if (row1 != 0)
            {
                for (int i = row1 - 1; i > 0; i--)
                {
                    turnCombos.Add(new CombinationObject(i, row2, row3));
                }
            }
            if (row2 != 0)
            {
                for (int i = row2 - 1; i > 0; i--)
                {
                    turnCombos.Add(new CombinationObject(row1, i, row3));
                }
            }
            if (row3 != 0)
            {
                for (int i = row3 - 1; i > 0; i--)
                {
                    turnCombos.Add(new CombinationObject(row1, row2, i));
                }
            }

            int index = gen.Next(turnCombos.Count);
            CombinationObject move = turnCombos.get(index);
        }

    }
}
