using CSharpTutorials;
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
        int X;
        int Y;
        // Constructor 
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void ValidPosition()
        {
            if ((X < 0 && Y < 0) || (X > 6 && Y > 6))
            {
                Console.WriteLine("Invalid Move");
            }





        }

    }



    // Create a class for Players

    class Player
    {
        string P1;
        string P2;
        Position Position;







        int GemCount = 0;
        // Create a method to get direction from the user such as 'U', 'D', 'L', 'R'
        public string Move(char direction)
        {

            Console.WriteLine("Enter Your Direction: ");
            char UserDirection = Console.ReadLine()[0];

            int i = 0;
            int j = 0;
            Position = new Position(i, j);

            if (UserDirection == 'U')
            {
                i = i + 1;
                j = j;

            }
            else if (UserDirection == 'D')
            {
                i = i - 1;
                j = j;
            }
            else if (UserDirection == 'L')
            {
                i = i;
                j = j - 1;
            }
            else if (UserDirection == 'R')
            {
                i = i;
                j = j + 1;
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

            return i.ToString() + " " + j.ToString();
        }
    }


    /* switch(UserPosition) 
     {
      case "U":


             position = new Position(5, 0);  
             break;
      case "D":
             position = new Position(1, 0); ;
             break;
      case "L":
             position = new Position(0, 1);
             break;
      case "R":
             position = new Position(0, 3);
             break;



     }*/





    // Create a 6 x 6 Board
    class Board
    {
        string[,] Grid;


        //Constructor
        public Board()
        {

            string[,] board = {{"P1", "-", "G", "-", "-","O"},{"-", "O", "-", "G", "-","-"},{"O", "-", "-", "-", "-","G"} ,
                               {"-", "G", "-", "O", "-","-"},{"-", "-", "-", "G", "-","-"},{"G", "-", "O", "-", "-","P2"}};
            Grid = board;

        }
        // Create a method Display() to display the Board
        public void display()
        {

            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Console.Write(Grid[i, j] + "  ");
                }
            }

        }
        public void IsValidMove(Player player, char direction)
        {

        }
        public void CollectGem(Player player)
        {

        }

    }
    class Cell
    {

    }
    class Game
    {

    }


    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.display();



            // Position pos = new Position(0, 0);
            // pos.ValidPosition();
            Player player = new Player();
            player.Move('U');
            board.display();

            // User inputs








        }
    }
}




