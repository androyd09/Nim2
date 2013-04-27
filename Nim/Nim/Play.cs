using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Nim
{
    class Play
    {

        public GameState currentState;
        int count = 0;
        ArrayList turnCombos = new ArrayList();
        Dictionary<int, GameState> turnsTaken = new Dictionary<int,GameState>();
        Learner learn = new Learner();
        string whoGoesFirst;


        public Play(int answer)
        {
            gameTypeChooser(answer);
        }

        public void gameTypeChooser(int gameType)
        {
            if (gameType == 1)
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
            count = 0;
            turnsTaken.Clear();
            currentState = new GameState(3, 5, 7);
            Console.WriteLine("GAME START");
            Console.WriteLine("1 2 3");
            Console.WriteLine("------");
            currentState.printGameState();
        }

        public void pickWhoGoesFirst()
        {
            Random gen = new Random();
            int randomNumber = gen.Next();
            if (randomNumber % 2 == 0)
                whoGoesFirst = "CPU1";
            else
                whoGoesFirst = "CPU2";
        }

        public void playerVsComputer()
        {
            newGame();
            bool gameOver = false;
            while (!gameOver)
            {
                playersTurn();
                gameOver = currentState.checkForGameOver();
                if (gameOver)
                {
                    Console.WriteLine("YOU LOST!\n");
                    break;
                }
                
                computersTurn();
                gameOver = currentState.checkForGameOver();
                if (gameOver)
                {
                    Console.WriteLine("YOU WON!\n");
                }
                
            }
            
            askToPlayAgain();
            
        }

        public void ComputerVsComputer(int countdown)
        {
            for (int i = countdown; i > 0;i-- )
            {
                newGame();
                pickWhoGoesFirst();
                bool gameOver = false;
                do
                {
                    computersTurn();
                    gameOver = currentState.checkForGameOver();
                }
                while (!gameOver);
                calulateWhoWon();
            }
            askToPlayAgain();
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
            count++;
        }

        public void computersTurn()
        {
            ComputerLogic cpu = new ComputerLogic(currentState.row1, currentState.row2, currentState.row3);
            int[] cpuMove = cpu.findBestMove(learn);
            currentState.makeMove(cpuMove[0], cpuMove[1]);
            count++;
            turnsTaken.Add(count, new GameState(currentState.row1, currentState.row2, currentState.row3));
            
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
            {
                Console.WriteLine("1 - Player Vs CPU\n2 - CPU Vs CPU");
                int gameType = Convert.ToInt32(Console.ReadLine());
                gameTypeChooser(gameType);
            }
            else
                Console.WriteLine("Goodbye");
        }

        public void calulateWhoWon()
        {
            string whoWon;
            Console.WriteLine("\nWho went first: " + whoGoesFirst + "\nNumber of turns taken: " + count);
            if ((whoGoesFirst.Equals("CPU1") && count % 2 == 0) ||
                (whoGoesFirst.Equals("CPU2") && count % 2 == 1))
                whoWon = "CPU1";
            else
                whoWon = "CPU2";

            Console.WriteLine(whoWon + " WINS!\n");
            if (whoGoesFirst.Equals(whoWon))
                learn.updateStates(false, turnsTaken);
            else
                learn.updateStates(true, turnsTaken);
        }
    }

}
