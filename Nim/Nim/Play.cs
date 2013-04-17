using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Nim
{
    class Play
    {
        public int row1, row2, row3;
        int playerMoves = 0;
        int computerMoves = 0;
        int count = 0;
        CombinationObject currentBoard;
        ArrayList turnCombos = new ArrayList();
        int[] turnsTaken = new int[15];
        LogicHolder LH = new LogicHolder();


        public Play(int answer)
        {
            LH.combinationMaker();
            if (answer == 1)
            {
                pvc();
            }
            else
            {
                Console.WriteLine("How many times should they battle?");
                int battleNumber = Convert.ToInt32(Console.ReadLine());
                cvc(battleNumber);
            }
        }

        public void newGame()
        {
            
            row1 = 3;
            row2 = 5;
            row3 = 7;
            Console.WriteLine("GAME START");
            Console.WriteLine("1 2 3");
            Console.WriteLine("------");
            //
            printRows();
        }

        public void printRows()
        {
            Console.WriteLine(LH.printLogic(row1,row2,row3));
            Console.WriteLine();
        }

        public void pvc()
        {
            newGame();
            bool gameOver = false;
            do
            {
                playersTurn();
                if (checkForGameOver())
                {
                    gameOver = true;
                }

                computersTurn();
                if (checkForGameOver())
                {
                    gameOver = true;
                }
            }
            while(!gameOver);
           
            Console.WriteLine("Do you want to play again? y/n");
            string again = Console.ReadLine();
            if (again.Equals("y"))
            {
                pvc();
            }
            else
            {
                Console.WriteLine("Goodbye");
            }
        }

        public void cvc(int countdown)
        {
            do
            {
                newGame();
                bool gameOver = false;
                do
                {
                    computersTurn();
                    if (checkForGameOver())
                    {
                        gameOver = true;
                    }

                    computersTurn();
                    if (checkForGameOver())
                    {
                        gameOver = true;
                    }
                }
                while (!gameOver);
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

                makeMove(row, pieces);
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPS TRY AGAIN");
                playersTurn();
            }

            turnsTaken[count] = playerMoves;
            playerMoves++;
            count++;
        }

        public void computersTurn()
        {
            Random gen = new Random();
            if(row1!=0)
            {
                for (int i = row1 - 1; i > 0; i--)
                {
                    turnCombos.Add(new CombinationObject(i,row2,row3));
                }
                printRows();
            }
            if (row2 != 0)
            {
                for (int i = row2 - 1; i > 0; i--)
                {
                    turnCombos.Add(new CombinationObject(row1, i, row3));
                }
                printRows();
            }
            if(row3 !=0)
            {
                for (int i = row3 - 1; i > 0; i--)
                {
                    turnCombos.Add(new CombinationObject(row1, row2, i));
                }
                printRows();
            }

            int index = gen.Next(turnCombos.Count);
            CombinationObject move = turnCombos.get(index);
            turnsTaken[count] = computerMoves;
            computerMoves++;
            count++;
            
        }

        public bool checkRow(int row)
        {
            bool notZero = false;
            if(row == 1 && row1 > 0)
            {
                notZero = true;
            }
            else if (row == 2 && row2 > 0)
            {
                notZero = true;
            }
            else if (row == 3 && row3 > 0)
            {
                notZero = true;
            }
            return notZero;
        }

        public bool checkMove(int row, int num)
        {
            bool canMove = false;
            if (row == 1 && row1 >= num)
            {
                canMove = true;
            }
            else if (row == 2 && row2 >= num)
            {
                canMove = true;
            }
            else if (row == 3 && row3 >= num)
            {
                canMove = true;
            }
            return canMove;
        }

        public void makeMove(int row, int num)
        {
            if (row == 1)
            {
                row1 -= num;
            }
            else if (row == 2)
            {
                row2 -= num;
            }
            else
            {
                row3 -= num;
            }
            printRows();
        }

        public bool checkForGameOver()
        {
            bool gameover = false;
            if(row1 == 0 && row2 == 0 && row3 == 0)
            {
                gameover = true;
            }
            return gameover;
        }
    }

}
