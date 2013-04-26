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
        List<GameState> turnCombos = new List<GameState>();
        private int row1, row2, row3;
        Random gen = new Random();

        public ComputerLogic(int _row1, int _row2, int _row3)
        {
            row1 = _row1;
            row2 = _row2;
            row3 = _row3;
            findPossibleMoves();
        }

        public void findPossibleMoves()
        {
            if (row1 >= 0)
            {
                for (int i = row1 - 1; i >= 0; i--)
                {
                    turnCombos.Add(new GameState(i, row2, row3));
                }
            }
            if (row2 >= 0)
            {
                for (int i = row2 - 1; i >= 0; i--)
                {
                    turnCombos.Add(new GameState(row1, i, row3));
                }
            }
            if (row3 >= 0)
            {
                for (int i = row3 - 1; i >= 0; i--)
                {
                    turnCombos.Add(new GameState(row1, row2, i));
                }
            }
        }

        public int[] getRandomMove()
        {
            GameState move;
            Console.WriteLine("TurnCombos: " + turnCombos.Count);
            int index = gen.Next(0, turnCombos.Count-1);
            move = turnCombos[index];
            int pieces = 1;
            int row = 1;
            if (row1 > move.row1)
            {
                pieces = row1 - move.row1;
            }
            else if (row2 > move.row2)
            {
                pieces = row2 - move.row2;
                row = 2;
            }
            else
            {
                pieces = row3 - move.row3;
                row = 3;
            }
            
            return new int[]{row, pieces};// make use of the move here instead of this array
        }

    }
}
