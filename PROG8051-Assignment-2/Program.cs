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
        public int X { get { return row; } }
        public int Y { get { return col; } }


        // Constructor 
        public Position(int x, int y)
        {
            this.row = x;
            this.col = y;
        }

        //Method
        public bool ValidPosition(int X, int Y)
        {
            if (X < 0 || Y < 0 || X > 5 || Y > 5)
            {
                Console.WriteLine("Invalid Move");
                return false;
            }
            
            else
            {
                
                return true;
            }
        }
    }

    // Create a class for Players

    class Player
    {
        
        public string name;
        public int GemCount = 0;

        //Properties
       
        public Position position;
         

        // Create a method to get direction from the user such as 'U', 'D', 'L', 'R'
        public string Move(char direction)

        {
            int i = position.X;
            int j = position.Y;

            switch (direction)
            {
                case 'U':
                    i -= 1;
                    position = new Position(i, j);

                    break;
                case 'D':
                    i += 1;
                    position = new Position(i, j);
                    break;
                case 'R':
                    j += 1;
                    position = new Position(i, j);
                    break;
                case 'L':
                    j -= 1;
                    position = new Position(i, j);
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

        public string[,] Grid = new string[6, 6];
        

        //Constructor
        public Board(int gems, int obstacles)
        {
           

            /* string[,] board1 = {{"P1", "-", "G", "-", "-","O"},{"-", "O", "-", "G", "-","-"},{"O", "-", "-", "-", "-","G"} ,
                                {"-", "G", "-", "O", "-","-"},{"-", "-", "-", "G", "-","-"},{"G", "-", "O", "-", "-","P2"}};*/
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i, j] = "-";
                }
            }
            Grid[0, 0] = "P1";
            Grid[Grid.GetLength(0) - 1, Grid.GetLength(1) - 1] = "P2";

            string elementSymbol1 = "G";
            string elementSymbol2 = "O";
            PlaceGameElements(gems, elementSymbol1);
            PlaceGameElements(obstacles, elementSymbol2);
           // gemsPresent = gems;
            
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
            Console.WriteLine();


        }

        public bool IsValidMove(Player player, char direction)
        {
            int old_row = player.position.X;
            int old_col = player.position.Y;
            switch (direction)
            {
                case 'U':
                    old_row -= 1;
               
                    break;
                case 'D':
                    old_row += 1;
                    
                    break;
                case 'R':
                    old_col += 1;
                  
                    break;
                case 'L':
                    old_col -= 1;
                    
                    break;
                

            }
            if (!player.position.ValidPosition(old_row, old_col))
            { return false; }


            else if (Grid[old_row, old_col] == "O")
            {
                Console.WriteLine("Obstacle ahead!! Not a valid move");
                return false;
            }
            else if (Grid[old_row, old_col] == "P1" || Grid[old_row, old_col] == "P2")
            {
                Console.WriteLine("Player ahead!! Not a valid move");
                return false;
            }

            else
            {
                return true;
            }

        }
        public void CollectGem(Player player)

        {
          
            if (Grid[player.position.X, player.position.Y] == "G")
            {
              
               player.GemCount++;
                Console.WriteLine($"Yay,{player.name} got a GEM!!");

            }
 
        }

    }
    // Create a class for cell occupants
    class Cell
    {
        string[] occupant = { "P1", "P2", "G", "O", "-" };
        

    }

    // Create a class for Game 

    class Game
    {
        Board board;
        Player player1;
        Player player2;
        Player CurrentTurn;
      
        char direction;
        

        int TotalTurns = 0;
        public Game()
        {
            
            board = new Board(7, 4);
            player1 = new Player();
            player2 = new Player();
        }
        
        public void StartGame()
        {
            player1.name = "P1";
            player2.name = "P2";
            player1.position = new Position(0, 0);
            player2.position = new Position(5, 5);

            board.display();
            while (!IsGameOver()) { SwitchTurn(); }
            DeclareWinner();
            
        }
        public void SwitchTurn()
        {
            
            repeat:
            if (TotalTurns % 2 == 0)
            {
                Console.WriteLine("Player 1's turn");
                Console.WriteLine("Enter Your Direction: ");
                direction = Convert.ToChar(Console.ReadLine());
                CurrentTurn = player1;
                
            }
            else
            {
                Console.WriteLine(" Player2's turn");
                Console.WriteLine("Enter Your Direction: ");
                direction = Convert.ToChar(Console.ReadLine());
                CurrentTurn = player2;
                
            }
            int oldx=CurrentTurn.position.X; 
            int oldy=CurrentTurn.position.Y;

            string value = board.Grid[oldx,oldy];
            if (board.IsValidMove(CurrentTurn, direction))
            {
                TotalTurns++;
                CurrentTurn.Move(direction);
                board.CollectGem(CurrentTurn);
                board.Grid[CurrentTurn.position.X,CurrentTurn.position.Y] = value;
                board.Grid[oldx,oldy] = "-";
                board.display();

            }
            else
            {
                goto repeat;
            }

        }
        public bool IsGameOver()
        {
            if(TotalTurns>29)
            {
                Console.WriteLine("Game Over");
 
                return true;
            }
            
            else
            { 
                return false; 
            }

        }
        public void DeclareWinner()
        {
           
            if (player1.GemCount > player2.GemCount)
            {
                Console.WriteLine("Player 1 is the winner!!");
                
            }
            else if (player2.GemCount > player1.GemCount)
            { Console.WriteLine("Player 2 is the winner!!"); }
           /* else 
            { Console.WriteLine($"Tie!!"); }*/
        }
        
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Gem Hunters Game!!\nGame Rules : \n 1.Players can not move diagnoly.Only Up(U),Down(D),Left(L) and Right(R) allowed." +
                "\n 2.Can not move to cells which contain Obstacles(O).\n 3.Players can not overlap\nOkay!! Now let's begin the game!!");
        game:
            Game game = new Game();
            game.StartGame();
            Console.WriteLine("Game Over!!Do you want to play again?(Y/N):");
            char decision =  Convert.ToChar(Console.ReadLine());    
            if(decision == 'Y')
            {
                goto game;
            }
            else if (decision == 'N')
            {
                Console.WriteLine("Game Over!!Thankyou for playing Gem Hunter!!");
            }

        }
    }
}





