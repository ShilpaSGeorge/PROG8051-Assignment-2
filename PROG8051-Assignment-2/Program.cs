using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorials
{
    // Create a class to determine the position
    class Position
    {
        // Constructor 
        public Position(int x, int y)
        {
            x = 0;
            y = 0;
        }
    }
    // Create a 6 x 6 Board
    class Board
    {
        //Constructor
        public Board()
        {
        }
        // Create a method Display() to display the Board
        public void Display()

        {
            string[,] Board = {{"-", "-", "-", "-", "-","-"},{"-", "-", "-", "-", "-","-"},{"-", "-", "-", "-", "-","-"} ,
                               {"-", "-", "-", "-", "-","-"},{"-", "-", "-", "-", "-","-"},{"-", "-", "-", "-", "-","-"}};


            for (int i = 0; i < Board.GetLength(0); i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Console.Write(Board[i, j] + "  ");
                }
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
           
            Board board = new Board();
            board.Display();
            

            
        }
    }
}
