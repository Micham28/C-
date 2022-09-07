//Cs3 we have to choose two programs to make in this solution, I assume it is acceptable to model it after the student DB structure.
//Michael McAlexander
//Info 200 - Cs3            Due 2022-03-12
////////////////////////////////////////////////////////////////
//these applications have the purpose of:
//Change History
//Date          Developer           Description
//2022-03-09    Michael             start of choosing programs and creating base.
using System;


namespace Cs3Apps
{

    internal class TicTacData
    {
       static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
       static int player = 1;
       static int choice;
       static int flag = 0;
        public void TicTacGame(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player_1 = X and Player_2 = O");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player_2 It's your turn! :-)");
                }
                else
                {
                    Console.WriteLine("Player_1 It's your move! :-)");
                }
                Console.WriteLine("\n");
                GameBoard();
                choice = int.Parse(Console.ReadLine());
                if (arr[choice] !='X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("oops row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait as the Board resets.");
                    System.Threading.Thread.Sleep(2000);
                }
                flag = CheckWin();
            }
            while (flag != 1 && flag != -1);
            Console.Clear();
            GameBoard();
            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("No Winner :-(");
            }
            Console.ReadLine();
        }

        private int CheckWin()
        {
            #region Horizontal Winning Condition

            if  (arr[1] == arr[2] && arr[2] == arr[3])
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
            else if (arr[1] != '1' && arr [2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }

        private void GameBoard()
        {
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
    }
    
}