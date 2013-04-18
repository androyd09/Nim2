using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class Program
    {
        static void Main(string[] args)
        {
            bool tryagain = true;
            do
            {

            Console.WriteLine("Welcome, 1) Player Vs Computer or 2) Computer Vs Computer");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer == 1 || answer == 2)
            {
                tryagain = false;
                Play play = new Play(answer);
            }
            else
            {
                Console.WriteLine("1 or 2. not " + answer);
            }
            }
            while(tryagain == true);
        }
    }
}
