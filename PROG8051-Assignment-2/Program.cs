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
        // Fields
        int row;
        int col;

        // Properties
        public int X {  get { return row; } }
        public int Y { get { return col; } }

        // Constructor 
        public Position(int x, int y)
        {
            row = x;
            col = y;
        }

        //Method
        public void ValidPosition(int row, int col)
        {
            if ((row < 0 && col < 0) || (row > 6 && col > 6))
            {
                Console.WriteLine("Invalid Move");
            }
            else if ((row + 1) == (col + 1))
            {
                Console.WriteLine("Cannot move diagonally");
            }
        }
    }

    // Create a class for Players

    class Player
    {
        //Fields
        string Player1;
        string Player2;
        int count;

        //Properties
        public string P1 {  get { return Player1; } }
        public string P2 { get { return Player2; } }
        public int GemCount { get { return count; } }

        //Position[,] position = new Position[6,6];

        public void CurrentTurn(int turn)
        {

           
                if (turn % 2 == 0)
                {
                    Console.WriteLine(" Player 1's turn");
               
                }
                else
                {
                 Console.WriteLine(" Player2's turn");
                   // return Player2 + " " + turn;
                }
            

        }

        // Create a method to get direction from the user such as 'U', 'D', 'L', 'R'
        public string Move(char direction)

        {
            int i = 0;
            int j = 0;
            switch(direction)
            {
                case 'U':
                    i -= 1;
                    
                    break;
                case 'D':
                    i += 1;
                    break;
                case 'R':
                    j += 1;

                    break;
                case 'L':
                    j-=1;
                    break;
                default:
                    Console.WriteLine("Invalid Move");
                    break;

            }
            return i.ToString() + " " + j.ToString();
        }
    }

  // Create a 6 x 6 Board
    class Board
    {
        
        string[,] Grid = new string[6,6];


        //Constructor
        public Board(int gems, int obstacles)
        {


           /* string[,] board1 = {{"P1", "-", "G", "-", "-","O"},{"-", "O", "-", "G", "-","-"},{"O", "-", "-", "-", "-","G"} ,
                               {"-", "G", "-", "O", "-","-"},{"-", "-", "-", "G", "-","-"},{"G", "-", "O", "-", "-","P2"}};*/
           for(int i = 0;i< Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++) 
                {
                    Grid[i, j] = "-";
                }
            }
            Grid[0, 0] = "P1";
            Grid[Grid.GetLength(0) - 1  , Grid.GetLength(1) - 1] = "P2";
           
            string elementSymbol1 = "G";
            string elementSymbol2 = "O";
            PlaceGameElements(gems,elementSymbol1);
            PlaceGameElements(obstacles, elementSymbol2);

        }
        public void PlaceGameElements(int numElements, string elementSymbol)
        {
            Random random = new Random();

            for (int i = 0; i < numElements; i++)
            {
                int row = random.Next(Grid.GetLength(0));
                int col = random.Next(Grid.GetLength(1));

                // Check if the position is already occupied.
                if (Grid[row, col] == "-")
                {
                    Grid[row, col] = elementSymbol;
                }
                else
                {
                    // Try again if the position is already occupied.
                    i--;
                }
            }
        }
        // Create a method Display() to display the Board
        public void display()
        {

            for (int a = 0; a < Grid.GetLength(0); a++)
            {
                Console.WriteLine("");
                for (int b = 0; b < Grid.GetLength(1); b++)
                {
                    Console.Write(Grid[a, b] + "  ");
                }
            }
            

        }
        
        public void IsValidMove(Player player, char direction)
        {
            for(int a = 0;a < Grid.GetLength(0);a++)
            { 
            for(int b=0;b < Grid.GetLength(1);b++)
                {
                    if (Grid[a, b] == "O")
                    {
                        Console.WriteLine("Obstacle ahead!! Not a valid move");
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            display();
            
        }
        public void CollectGem(Player player)

        {
            int GemCount = 0;

            for (int a = 0; a < Grid.GetLength(0); a++)
            {
                for (int b = 0; b < Grid.GetLength(1); b++)
                {
                    if (Grid[a, b] == "G")
                    {
                        GemCount++;
                        Grid[a, b] = "-";
                    }
                    else
                    {
                        continue;
                    }
                }
            }
          

        }

    }
    // Create a class for cell occupants
    class Cell
    {
        string[] occupant = { "P1", "P2", "G", "O", "-" };
        Board board;
        
    }

    // Create a class for Game 

    class Game
    {
        Board board;
        Player Player1;
        Player Player2;
        Player CurrentTurn;
        int TotalTurns = 0;
        public Game()
        {
            Console.WriteLine("Let the game begin :");
            //Board = new Board();
            Player1 = new Player();
            Player2 = new Player();





        }
        public void StartGame()
        {
            Board board1 = new Board(2,3);
           //
           //board1.display(board);
            //CurrentTurn.CurrentTurn();

           


            

        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(5, 3);
            board.display();
            Position position = new Position(0,0);
            position.ValidPosition(0,0);

            Player player1 = new Player();  

            
            player1.CurrentTurn(10);
            

            Console.WriteLine("Enter Your Direction: ");
            char UserDirection = Console.ReadLine()[0];
            player1.Move(UserDirection);











            // board.PlaceGameElements(3, "O");
            Game game = new Game();
            game.StartGame();



            // Position pos = new Position(0, 0);
            // pos.ValidPosition();
            // Player player = new Player();
            //player.Move('U');
            //board.display();

            // User inputs








        }
    }
}





