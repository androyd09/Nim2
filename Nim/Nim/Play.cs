using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Nim
{
    class Play
    {

        GameState currentState;
        int playerMoves = 0;
        int computerMoves = 0;
        int count = 0;
        ArrayList turnCombos = new ArrayList();
        int[] turnsTaken = new int[15];
        LogicHolder LH = new LogicHolder();


        public Play(int answer)
        {
            LH.combinationMaker();
            if (answer == 1)
            {
                playerVsComputer();
            }
            else
            {
                Console.WriteLine("How many times should they battle?");
                int battleNumber = Convert.ToInt32(Console.ReadLine());
                ComputerVsComputer(battleNumber);
            }
        }

        public void newGame()
        {
            currentState = new GameState(3, 5, 7);
            Console.WriteLine("GAME START");
            Console.WriteLine("1 2 3");
            Console.WriteLine("------");
            currentState.printGameState();
        }

        public void playerVsComputer()
        {
            newGame();
            bool gameOver = false;
            do
            {
                playersTurn();
                gameOver = currentState.checkForGameOver();
                computersTurn();
                gameOver = currentState.checkForGameOver();
            }
            while(!gameOver);
            askToPlayAgain();
            
        }

        public void ComputerVsComputer(int countdown)
        {
            do
            {
                newGame();
                bool gameOver = false;
                do
                {
                    computersTurn();
                    gameOver = currentState.checkForGameOver();
                    computersTurn();
                    gameOver = currentState.checkForGameOver();
                }
                while (!gameOver);
                countdown--;
            }
            while(countdown > 0);
        }

        public void playersTurn()
        {
            bool done = false;
            int row = 0;
            int pieces = 0;
            
            try
            {
                //Pick Row
                do
                {
                    Console.WriteLine("What row would you like to take from?");
                    row = Convert.ToInt32(Console.ReadLine());
                    if (row == 1 || row == 2 || row == 3)
                    {
                        done = checkRow(row);
                    }
                    
                }
                while (!done);

                done = false;

                //Pick number of pieces
                do
                {
                    Console.WriteLine("How many pieces from row " + row + "?");
                    pieces = Convert.ToInt32(Console.ReadLine());
                    done = checkMove(row, pieces);
                }
                while (!done);

                currentState.makeMove(row, pieces);
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPS TRY AGAIN");
                Console.WriteLine(e.Message);
                playersTurn();
            }

            turnsTaken[count] = playerMoves;
            playerMoves++;
            count++;
        }

        public void computersTurn()
        {
            ComputerLogic cpu = new ComputerLogic(currentState.row1, currentState.row2, currentState.row3);
            int[] cpuMove = cpu.getRandomMove();
            currentState.makeMove(cpuMove[0], cpuMove[1]);
            turnsTaken[count] = computerMoves;
            computerMoves++;
            count++;
            
        }

        public bool checkRow(int row)
        {
            bool notZero = false;
            if(row == 1 && currentState.row1 > 0)
                notZero = true;
            else if (row == 2 && currentState.row2 > 0)
                notZero = true;
            else if (row == 3 && currentState.row3 > 0)
                notZero = true;
            return notZero;
        }

        public bool checkMove(int row, int num)
        {
            bool canMove = false;
            if (row == 1 && currentState.row1 >= num)
                canMove = true;
            else if (row == 2 && currentState.row2 >= num)
                canMove = true;
            else if (row == 3 && currentState.row3 >= num)
                canMove = true;
            return canMove;
        }

        public void askToPlayAgain()
        {
            Console.WriteLine("Do you want to play again? y/n");
            string again = Console.ReadLine();
            if (again.Equals("y"))
                playerVsComputer();
            else
                Console.WriteLine("Goodbye");
        }
    }

}
