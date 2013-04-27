using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class GameState
    {
        public int row1 { get; private set; }
        public int row2 { get; private set; }
        public int row3 { get; private set; }
        private bool gameOver;

        public GameState(int _row1, int _row2, int _row3)
        {
            row1 = _row1;
            row2 = _row2;
            row3 = _row3;
            gameOver = false;
        }

        public void makeMove(int rowNum, int piecesToBeRemoved)
        {
            if (rowNum == 1)
                row1 -= piecesToBeRemoved;
            else if (rowNum == 2)
                row2 -= piecesToBeRemoved;
            else
                row3 -= piecesToBeRemoved;
            printGameState();
        }
        
        public bool checkForGameOver()
        {
            if (row1 == 0 && row2 == 0 && row3 == 0)
                gameOver = true;
            return gameOver;
        }

        public void printGameState()
        {
            Console.WriteLine(row1 + " " + row2 + " " + row3);
            Console.WriteLine();
        }

        public override int GetHashCode()
        {
            return row1.GetHashCode() ^ row2.GetHashCode() ^ row3.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            GameState fooItem = obj as GameState;

            return (fooItem.row1 == this.row1) && (fooItem.row2 == this.row2) && (fooItem.row3 == this.row3);
        }
    }
}
