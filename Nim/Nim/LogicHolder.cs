using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class LogicHolder
    {
        //public 
        public Dictionary<int, CombinationObject> combinations = new Dictionary<int, CombinationObject>();
        private CombinationObject combo;
        public int moveValue = 0;

        public void combinationMaker()
        {
            int count = 0;
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 5; j++)
                {   
                    for (int k = 0; k <= 7; k++)
                    {
                        combo = new CombinationObject(i,j,k);
                        combinations.Add(count, combo);
                        count++;
                    }
                }
            }
        }
        public void printAllLogic()
        {
            foreach (KeyValuePair<int, CombinationObject> combo in combinations)
            {
                Console.WriteLine(combo.Value.printCombo());
            }
        }
        public string printLogic(int a, int b, int c)
        {
            string rows="";
            foreach(KeyValuePair<int, CombinationObject> combo in combinations)
            {
                
                if (combo.Value.Row1 == a && combo.Value.Row2 == b && combo.Value.Row3 == c)
                {
                    rows= combo.Value.printCombo();
                }
               
            }
            return rows;
        }

        public void posNegLogic(int row1, int row2, int row3, int playerMoves)
        {
            moveValue += (1 / playerMoves);
        }

    }
}
