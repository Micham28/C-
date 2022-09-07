//Michael McAlexander
// TInfo 200 - CS1        Due 2022-01-22
/////////////////////////////////////////////////////////////////////
//Change History
//Date          Developer       Description
//2022-01-20    Michael         Opening of Project (starts with odd or even) something to look at adding is a way to see if and how to tell if a digit set with decinmal is even.
//2022-01-21    Michael         looked into making it for whole numbers with decimals didnt work out so im leaving it at whole numbers only (COMPLETE)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOrEven
{//writes basic program that tells if a number(s) given by the user are/is odd or even.
    internal class Program
    {//main app entry execution point
        static void Main(string[] args)
        {//user interface explains the app and what it does to the user.
         //1-explain why user would use this app.
         //2-give user instructions on how the software works.
            Console.WriteLine(@"
*******************************************
Welcome user(s) to the Odd or Even program
*******************************************
This app is designed to help you determine 
if certain numbers are odd or even. you will
be asked to give input in the form of a 
certain number.(whole numbers ONLY)");
            //input area of the program
            //get number from the user
            Console.Write("Enter your number to test here:");
            int UserNum = int.Parse(Console.ReadLine());
            //find remainder for the number the user gives.
            int Remainder = UserNum % 2;
            //determining section is even if the remainder = 0 and if not remainder will not equal 0
            if (Remainder != 0)
            {
                Console.Write($"your number is an odd number as the remainder of {UserNum} is {Remainder} and not 0.");
            }
            else
            {
                Console.Write($"your number is an even number as the remainder of {UserNum} is {Remainder} which means the number is completely divisible by 2.");
            }
        }
    }
}