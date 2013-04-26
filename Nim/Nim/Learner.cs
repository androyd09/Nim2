using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class Learner
    {
        private Dictionary<GameState, int> moves = new Dictionary<GameState, int>();
        private const int MAX_VALUE = 10;
        private const int MIN_VALUE = -10; 

        public Learner()
        {
            GameState state;
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    for (int k = 0; k <= 7; k++)
                    {
                        state = new GameState(i, j, k);
                        moves.Add(state, 0);
                    }
                }
            }
        }

        public void updateStates(bool oddMovesGood, Dictionary<int, GameState> turns)
        {
            int numForOddOrEven;
            if (oddMovesGood)
                numForOddOrEven = 1;
            else
                numForOddOrEven = 0;


                foreach (var turn in turns)
                {
                    if (turn.Key % 2 == numForOddOrEven)
                        valueUp(turn.Value);
                    else
                        valueDown(turn.Value);
                }
        }

        private void valueUp(GameState state)
        {
            int value = moves[state];
            if (value < MAX_VALUE)
                moves[state] = value++;
        }

        private void valueDown(GameState state)
        {
            int value = moves[state];
            if (value > MIN_VALUE)
                moves[state] = value--;
        }
    }
}
