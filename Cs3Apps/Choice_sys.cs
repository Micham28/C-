//Cs3 we have to choose two programs to make in this solution, I assume it is acceptable to model it after the student DB structure.
//didnt model it all the way after DB I decidded against it as it was too much for me. 
//these applications have the purpose of:
//I chose TicTac Toe with the Duplicate removal, Duplicate just takes a random array in a range of 10-100 and put 5 values down and removes any double printed values.
//Tic Tac Toe a standard country wide game that cures boardem you get three in direct or close proximity to win (horizonal, vertical, diagnal) must be a two player game.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Michael McAlexander
//Info 200 - Cs3            Due 2022-03-12
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Change History
//Date          Developer           Description
//2022-03-09    Michael             start of choosing programs and creating base.
//2022-03-10    Michael             branching systems to run off central choice. changes it so that the program is one central choice running out of time and this runs better, and is structured in a more effiecent way.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//had many different choices of how to build then got rid of them as they seem less efficeint hence the unused "using systems".
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Cs3Apps
{
    internal class Choice_sys
    {
        
        //made general list, was going to separate into file but I felt this was more effienct. 
        //list of characters to use on tic Tac toe board for spot selection, used a similar approach to the menu and the other menus we have done in class making a character selection but using array value selection.
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        //sets a player value all else is the other player
        static int player = 1;
        //tells the void to pull from another area and grab those values.
        public int choice { get; set; }
        //parameter set for letting the game know if there are any more moves to be made, stops the game if someone has already won.
        static int flag = 0;

        //menu selection and first main portion of code.
        internal void Run()
        {//displays the console value set for GUI
            Displaymenu();
            //sets a vlaue for characters to be selected instead of making a if select ___ varraible. could always use Readline and that works but I figured I'd follow the previous method shown by the professor.
            char selection = GetSelection();
            //menu selections cases.
            switch (selection)
            {
                case 'D':
                case 'd':
                    DuplicateElimination();
                    break;
                case 'T':
                case 't':
                    Tic_Tac_Toe();
                    break;
                case 'E':
                case 'e'://closes out the system
                    System.Environment.Exit(0);
                    break;
                default://incase user doesnt understand.
                    Console.WriteLine("Not and option");
                    break;
            }
        }

        private void DuplicateElimination()
        {//was going to make this a two step but found a Linq way of doing this problem that would save time and space, so I just left it to call a function
            RandomNumber(); 
        }

        private void RandomNumber()
        {//list created for the integers
            var rnum = new Random();
            List<int> rnlist = new List<int>();
            //tells the program to run until a certain amount has been collected
            for (int i = 0; i <= 5; i++)
            {//tells the list to add the numbers generated, writes the numbers generated.
                rnlist.Add(rnum.Next(10, 101));
                Console.Write($"\n{rnlist[i]}");
            }
            //a linq function that tells the list to only keep unique numbers ones that have no doubles.
            int[] unique = rnlist.Distinct().ToArray();
            Console.WriteLine($"\nthe changes non duplicate array: \n");
            //tellsa the program to write until the list of int is done 
            Array.ForEach(unique, x => Console.WriteLine(x));
        }

        private void Tic_Tac_Toe()
        {//edit

            do
            {//clears the board but values are saved with the designated values at the top of this entire code. 
                Console.Clear();
                Console.WriteLine("Player_1 = X and Player_2 = O");
                Console.WriteLine("\n");
                //differentiates between player 1 and 2 's turn
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player_2 It's your turn! :-)");
                }
                else
                {
                    Console.WriteLine("Player_1 It's your move! :-)");
                }
                //pulls up the game board and its values with arrays
                Console.WriteLine("\n");
                GameBoard();
                //reads the user choice on the selection of which spot on the board, marks them with x and o and onlt does that seemlessly if there is no user value in  that place.
                choice = int.Parse(Console.ReadLine());
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = 'O';
                        player++;//adds that to a value in the array in the array numbers place.
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;//adds that to a value in the array in the array numbers place.
                    }
                }
                else
                {
                    Console.WriteLine("oops row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait as the Board resets.");
                    System.Threading.Thread.Sleep(2000);//if the user makes a choice that is already there it resets the values of the board
                }
                flag = CheckWin();//calls function to see if there are anymore viable plays.
            }//differentiates if there are any plays left to make.
            while (flag != 1 && flag != -1);
            Console.Clear();
            GameBoard();
            if (flag == 1)
            {//If someone has won the value of player is replaced in the array marker.
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("No Winner :-(");
                System.Environment.Exit(0);
            }
            Console.ReadLine();
        }
        //checks to see if that final value is a winner or loser
        private int CheckWin()
        {
            #region Horizontal Winning Condition
            //checks to see if it hjas a row of all the same or value of one
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion
            #region Vertical Winning Condition
            //checks to see if their is an upward 3 match with the same value
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            //checks to see if their is an diagonal either way 3 match with the same value
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion
            #region Checking for Draw
            //if there are not matches of 3 the value will come back as less than real value making it a null or no win
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion
            //anyother situation is a no win
            else
            {
                return 0;
            }
        }
        private void GameBoard()
        {//Gui for the game board in which array values are held as positional markers
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }


        private char GetSelection()
        {// tells the program to use key selected as a value
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            return keyPressed.KeyChar;
        }

        private void Displaymenu()
        {//Gui for menu.
            Console.WriteLine(@"
****************************************************************************
*********** Choose to run Duplicate elimination or Tic Tac Toe *************
****************************************************************************
Make a user selection as to which program you would like to run first,
by entering the letter provided in the box.

[D]uplicate Elimination
[T]ic Tac Toe
[E]xit program
**************************************************** user selection: ");
        }
    }
}