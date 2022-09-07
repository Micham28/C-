//Michael McAlexander
// TInfo 200 - CS1        Due 2022-01-22
/////////////////////////////////////////////////////////////////////
//Change History
//Date          Developer       Description
//2022-01-25    Michael         Strart project
//2022-01-26    Micahel         class continuation of development
//2022-02-03    Michael         finalizing the development and comments / looking into the options
//2022-04-03    Michael         finding things to add for development
using System;
//main used to call the function.
namespace GLife
{//class used to designate the functions.
    internal class Game
    {//values used to track whats on the game board.
        private char[,] gameBoard;
        private char[,] buffBoard;

        //char constants for the alive, dead, and the empty WS chars
        public const char Live = '@';
        public const char Dead = '-';
        public const char Space = ' ';

        public readonly int ROW_SIZE = 50;
        public readonly int COL_SIZE = 80;

        public Game()
        {
            //initalize major obj here
            gameBoard = new char[ROW_SIZE, COL_SIZE];
            buffBoard = new char[ROW_SIZE, COL_SIZE];

            //initalize the game boards
            InitalizeGameBoards();

            //insert the startup patter or arrangment of lives
            //InsertStartupPatterns1(10, 10);
            InsertStartupPatterns1(20, 20);
            //InsertStartupPatterns1(30, 30);


        }
        //this is the function that calls for the user input as to how many gernerations and set perameters for how long its supposed to run.
        internal void PlayTheGame()
        {
            Console.WriteLine("Enter the number of genreations to display:");
            int numGenerations = int.Parse(Console.ReadLine());

            for (int generation = 1; generation <= numGenerations; generation++)
            {
                //display game board
                DisplayCurrentGameBoard(generation);

                //process the game board to prepare the next generation
                ProcessGameBoard();

                //swap the two boards
                SwapTheGameBoards();

            }
        }
        //this tells the program the pattern its should use first.
        private void InsertStartupPatterns1(int r, int c)
        {
            //after one dead cell
            //insert 8 lives cells
            gameBoard[r, c + 1] = Live;
            gameBoard[r, c + 2] = Live;
            gameBoard[r, c + 3] = Live;
            gameBoard[r, c + 4] = Live;
            gameBoard[r, c + 5] = Live;
            gameBoard[r, c + 6] = Live;
            gameBoard[r, c + 7] = Live;
            gameBoard[r, c + 8] = Live;

            //leave 1 dead
            //insert 5 live
            gameBoard[r, c + 10] = Live;
            gameBoard[r, c + 11] = Live;
            gameBoard[r, c + 12] = Live;
            gameBoard[r, c + 13] = Live;
            gameBoard[r, c + 14] = Live;

            //leave 3 dead
            //insert 3 live
            gameBoard[r, c + 18] = Live;
            gameBoard[r, c + 19] = Live;
            gameBoard[r, c + 20] = Live;
            //leave 6 dead
            //insert 7 live
            gameBoard[r, c + 27] = Live;
            gameBoard[r, c + 28] = Live;
            gameBoard[r, c + 29] = Live;
            gameBoard[r, c + 30] = Live;
            gameBoard[r, c + 31] = Live;
            gameBoard[r, c + 32] = Live;
            gameBoard[r, c + 33] = Live;
            //leave 1 dead
            //insert 5 live
            gameBoard[r, c + 35] = Live;
            gameBoard[r, c + 36] = Live;
            gameBoard[r, c + 37] = Live;
            gameBoard[r, c + 38] = Live;
            gameBoard[r, c + 39] = Live;
            //end of pattern
        }
        //this is where the initial game board set up gets swaped for a new generation/lay out.
        private void SwapTheGameBoards()
        {
            //tmp = A
            char[,] tmp = gameBoard;
            gameBoard = buffBoard;
            buffBoard = tmp;
            //A = B
            //B = tmp
        }
        //command called to check another command that determines if the geration is alive or dead.
        private void ProcessGameBoard()
        {
            //iterate throught the entire 2 dimenstional ray
            for (int r = 0; r < ROW_SIZE; r++)
            {
                for (int c = 0; c < COL_SIZE; c++)
                {
                    //consider the current cell (loc r,c) - determine if this cell will be live or dead in the next generation (on the buffBoard)
                    //calculate which state to store in the results board
                    buffBoard[r, c] = DetermineLifeOrDeath(r, c);
                }
            }
        }
        //I left the first example we did in there for my own edification \ counts the alive v dead cells and deterimins if that generation goes on and when to activate growth.
        private char DetermineLifeOrDeath(int r, int c)
        {
            //1- count the number of neightbor cells that currently hold live orgs
            int count = GetNeighborCount(r, c);
            //2- apply the rules of the game (standard B3/S23)
            //0,1,2,3,4,5,6,7,8 neighbours == Dead
            //
            //any live cell with fewer than two live neighbors dies, as if by underpopulation
            //if (gameBoard[r, c] == Live && count < 2) return Dead;
            //any live cell with two or three live neightbors live on to the next generation.
            //if (gameBoard[r, c] == Live && (count == 2 || count == 3)) return Live;
            //any cell with more than three live neighbours dies, as if by overpopulation.
            //if (gameBoard[r, c] == Live && count > 3) return Dead;
            //any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
            //if (gameBoard[r, c] == Dead && count == 3) return Live;
            //////////////////////////////////////////////////////////////////////////////////////////////
            if (count == 2) return gameBoard[r, c];
            else if (count == 3) return Live;
            else return Dead;
        }
        //tells the program where neighbor generations can be added.
        private int GetNeighborCount(int r, int c)
        {
            int neighborCount = 0;

            if (r == 0 && c == 0)
            {
                //Top left corner
                if (gameBoard[r, c + 1] == Live) neighborCount++;
                if (gameBoard[r + 1, c] == Live) neighborCount++;
                if (gameBoard[r + 1, c + 1] == Live) neighborCount++;
            }
            else if(r == 0 && c == COL_SIZE - 1)
            {
                //Top righ corner
                
                if (gameBoard[r, c - 1] == Live) neighborCount++;
                if (gameBoard[r + 1, c - 1] == Live) neighborCount++;
                if (gameBoard[r + 1, c] == Live) neighborCount++;
                
            }
            else if (r == ROW_SIZE - 1 && c == COL_SIZE - 1)
            {
                //Bottom right corner  //requires second look
                if (gameBoard[r - 1, c - 1] == Live) neighborCount++;
                if (gameBoard[r - 1, c] == Live) neighborCount++;
                if (gameBoard[r, c - 1] == Live) neighborCount++;
            }
            else if (r == ROW_SIZE - 1 && c == 0)
            {
                //Bottom Left corner //requires second look
                if (gameBoard[r - 1, c] == Live) neighborCount++;
                if (gameBoard[r - 1, c + 1] == Live) neighborCount++;
                if (gameBoard[r, c + 1] == Live) neighborCount++;
            }
            else if (r == 0)
            {
                //top edge not corner
               
                if (gameBoard[r, c - 1] == Live) neighborCount++;
                if (gameBoard[r, c + 1] == Live) neighborCount++;
                if (gameBoard[r + 1, c - 1] == Live) neighborCount++;
                if (gameBoard[r + 1, c] == Live) neighborCount++;
                if (gameBoard[r + 1, c + 1] == Live) neighborCount++;
            }
            else if (c == COL_SIZE - 1)
            {
                //right edge not corner
                if (gameBoard[r - 1, c - 1] == Live) neighborCount++;
                if (gameBoard[r - 1, c] == Live) neighborCount++;
                if (gameBoard[r, c - 1] == Live) neighborCount++;
                if (gameBoard[r + 1, c - 1] == Live) neighborCount++;
                if (gameBoard[r + 1, c] == Live) neighborCount++;
               
            }
            else if (r == ROW_SIZE - 1)
            {
                //Bottom edge not corner
                if (gameBoard[r - 1, c - 1] == Live) neighborCount++;
                if (gameBoard[r - 1, c] == Live) neighborCount++;
                if (gameBoard[r - 1, c + 1] == Live) neighborCount++;
                if (gameBoard[r, c - 1] == Live) neighborCount++;
                if (gameBoard[r, c + 1] == Live) neighborCount++;
            }
            else if (c == 0)
            {
                //Left edge not corner 
                if (gameBoard[r - 1, c] == Live) neighborCount++;
                if (gameBoard[r - 1, c + 1] == Live) neighborCount++;
                if (gameBoard[r, c + 1] == Live) neighborCount++;
                if (gameBoard[r + 1, c] == Live) neighborCount++;
                if (gameBoard[r + 1, c + 1] == Live) neighborCount++;
            }
            else
            {
                //nominal case
                //r,c
                if(gameBoard[r-1,c-1] == Live) neighborCount++;
                if (gameBoard[r-1, c] == Live) neighborCount++;
                if (gameBoard[r-1, c+1] == Live) neighborCount++;
                if (gameBoard[r, c-1] == Live) neighborCount++;
                if (gameBoard[r, c+1] == Live) neighborCount++;
                if (gameBoard[r+1, c-1] == Live) neighborCount++;
                if (gameBoard[r+1, c] == Live) neighborCount++;
                if (gameBoard[r+1, c+1] == Live) neighborCount++;
            }
            return neighborCount;
            //returns the count as a value that can be used to determin if dead or alive.
        }

        private void DisplayCurrentGameBoard(int generation)
        {
            Console.WriteLine($"Displaying generation #{generation}");
            //processing the row on iteration
            for (int r = 0; r < ROW_SIZE; r++)
            {//processing the colum on iteration
                for (int c = 0; c < COL_SIZE; c++)
                {
                    Console.Write($"{Space}{gameBoard[r, c]}");
                }
                Console.WriteLine();
            }
        }
        //tells the game board to start the pattern with zero alive, this is important so the game doesnt start in the middle of a generation and produces a true zero start point.
        private void InitalizeGameBoards()
        {
            for (int r = 0; r < ROW_SIZE; r++)
            {//these loops tel the program that if there are zero alive that the row adds one generation based on the code above.
                for (int c = 0; c < COL_SIZE; c++)
                {//tells the rows and columns to start with no live components.
                    gameBoard[r, c] = Dead;
                    buffBoard[r, c] = Dead;
                }
            }
        }
    }
}