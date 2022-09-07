//Michael McAlexander
// to help learn multiplication
//program should initiate two one digit integer values both positive. Ex: 6x7=____
//student inputs answer
//program checks and gives a message response like "Correct!" or "Incorrect!"
//the program should allow the user to try the same question repeatedly until correct.
//a separate method should be used to generate each new question.
//should only be called at the begining and when the user gets the answer correct.
//assistance in Ch.7
/////////////////////////////////////////////////////////////////////
//Change History
//Date          Developer       Description
//2022-02-11    Michael         begin to wrap aroun the problem 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITeacher
{//what type of program
    internal class Program
    {//tells the program to run
        static void Main(string[] args)
        {//user informational interface
            Console.WriteLine($"This is an early learning basic multiplication self tutor program,\n" +
                    $" this AI will help you understand math. some user notes:\n" +
                    $"1 - When you being you wil be prompted below with one varible multiplied by another. \n" +
                    $"2 - In the space below you will enter the number you think is the answer. \n" +
                    $"3 - If you get the answer wrong the system will alert you, simpply type '1' in the space provided to continue.\n" +
                    $"4 - Have fun there is not reason for you to stress this system doesnt keep score and you only compete with \n" +
                    $"your own knowledge.");
            Random NumberRand = new Random();//tells the program its going to be making random numbers
            int numOne = NumberRand.Next(0, 10);
            int numTwo = NumberRand.Next(0, 10);//makes the initial random numbers, between 1-10.
            while (true)//the function remains running until told to stop
            {
                Console.WriteLine($"What is {numOne} * {numTwo}= ");//displays the math the user need to do
                int UserResponse = 0;//sets a int place holder value for the user answer
                UserResponse = Convert.ToInt32(Console.ReadLine());//take sthe first user response and makes it an int
                int AnswerDir = numOne * numTwo;//tells the program to do math for the answer
                if (UserResponse != AnswerDir )//if the user guesses incorect the same problem is given back for the user to tryu again
                {
                    Console.WriteLine("That was not really the right answer champ, try again. (type '1' below to continue.)\n ");
                    UserResponse = Convert.ToInt32(Console.ReadLine());//take ths user input on the second one replaces the value of the first and converts it to int
                }
                else//if the answer is correct
                {
                    Console.WriteLine("You got it right super star!");
                    Console.WriteLine("would you like to try another? (yes/no)");
                    if (Console.ReadLine() != "yes")//tells the program to stop if the answer is not yes
                    {
                        break;//tells the program to end
                    }
                    else//if the answer is yes
                    {
                        numOne = NumberRand.Next(0, 10);//this tells the program to make a new set
                        numTwo = NumberRand.Next(0, 10);
                    }
                }
            }
        }
        
    }
}
