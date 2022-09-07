//Michael McAlexander
// TInfo 200B - CS2        Due 2022-02-12
//app choses a rand number
//displays a prompt instructing to guess the number
//player inputs guess
//app gives a promt indicating "TOO high, try again" or "TOO Low, try again" helping the user zero in on the value
//app prompts for next guess
//when user gets correct answer the propmt will display "Congratulations. You guessed the number!"
//the user will have the option displayed for users to play again or not.
//similar program found in chapter 18
/////////////////////////////////////////////////////////////////////
//Change History
//Date          Developer       Description
//2022-02-11    Michael         begin work on guess the number rand and user input
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//name
namespace GuessTheNumber
{//type of program/preload sys
    internal class Program
    {//start of main function/only functions
        static void Main(string[] args)
        {
            Console.WriteLine($"This is a Random number generator, you as the user will be given a chance\n" +
                $"to guess what number the computer has picked from 1 to 100, \n" +
                $"if you guess wrong dont worry it will give you the distance you were from the guess.\n" +
                $"The program will them allow you to try again, if you get it right and want to go again \n" +
                $"follow the prompt and a new number will populate. Have fun guessing");
            Random randomGuess = new Random();//sets the ability for a value.
            int G = randomGuess.Next(1, 100);//sets a random value with in the range
            //user intro
            Console.WriteLine("Guess a number between 1 and 100:");
            //keeps the question going as long as the boolean is true right
            while (true)
            {
                //initial values
                //Random randomGuess = new Random();//sets the ability for a value.
                //int G = randomGuess.Next(1, 100);//sets a random value with in the range
                int userGuess = 0;//sets value for user int number place.
                userGuess = Convert.ToInt32(Console.ReadLine());//takes the user input and converts to int
                int G_actual = Math.Abs(userGuess - G);// allows for easier tesing by giving a guess distance, but keeps it a guess by making the result and with absolute value.
                if (userGuess != G)//tells teh program to run again based on if the values match or dont match.
                {
                    Console.WriteLine($"the distance between the number and your guess is: {G_actual}");//gives the distance from correct to the user
                    Console.WriteLine("Try another number between 1 and 100:");
                }
                else
                {
                    Console.WriteLine("You've done it you guessed my number!");//user interface if corect
                    Console.WriteLine("Try again? (yes/no)");
                    if (Console.ReadLine().ToLower() != "yes")
                    {
                       break;   // end the while loop
                    }
                    else
                    {
                        G = randomGuess.Next(1, 100);
                        Console.WriteLine("Guess a number between 1 and 100:");//sets the user information for second loop.
                    }
                    
                }
            }
        }
    }
}
