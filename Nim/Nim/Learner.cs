using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class Learner
    {
        public Dictionary<GameState, int> moves = new Dictionary<GameState, int>();
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
                this.moves[state] = value+1;
        }

        private void valueDown(GameState state)
        {
            int value = moves[state];
            if (value > MIN_VALUE)
                this.moves[state] = value-1;
        }

        public GameState pickBestMove(List<GameState> possibleMoves)
        {
            GameState bestMove = null;
            int highestValue = MIN_VALUE;
            foreach (GameState state in possibleMoves)
            {
                int value = moves[state];
                if (value >= highestValue)
                {
                    highestValue = value;
                    bestMove = state;
                }

            }
            /*foreach(GameState state in possibleMoves)
            {
                int value = moves[state];
                if (value != highestValue)
                {
                    possibleMoves.Remove(state);
                }
            }
            bestMove = possibleMoves[0];*/
            return bestMove;
        }
    }
}
