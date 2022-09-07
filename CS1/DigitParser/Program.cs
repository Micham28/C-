//Michael McAlexander
// TInfo 200 - CS1        Due 2022-01-22
/////////////////////////////////////////////////////////////////////
//Change History
//Date          Developer       Description
//2022-01-20    Michael         Opening of Project (starts with odd or even)
//2022-01-20    Michael         Completed Digit Parser on 2022-01-20 (COMPLETE)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitParser
{//writes basic program that adds spaces inbetween digits that are a string of 5.
    internal class Program
    {//main app entry execution point
        static void Main(string[] args)
        {//user interface explains the app and what it does to the user.
         //1-explain why user would use this app.
         //2-give user instructions on how the software works.
            Console.WriteLine(@"
*******************************************
Welcome user(s) to the Digit Parser program
*******************************************
This app is designed to put spaces inbetween
your numbers as long as there are only 5 
total digits.(whole numbers ONLY)");
            //input area of the program
            //get number from the user
            Console.Write("Enter your 5 digit number here:");
            //tells the program it should be accepting integers/digits
            int number = int.Parse(Console.ReadLine());
            //tells the program to change the accpeted digits into a string so the characters can be counted
            string LNum = number.ToString();
            //marking out varriables and determining if the string of numbers is the specified lenght
            if (LNum.Length == 5)
            {
                
                var str = string.Join("   ", (IEnumerable<char>)number.ToString());
                Console.Write(str);
            }
            else if (LNum.Length < 5) 
            {
                Console.Write("sorry the number you have inserted is too short. Try again.");
            }
            //the = to 5 is left as else as this is a last option
            else
            {
                Console.Write("sorry the number you have inserted is too long. Try again.");
            }
        }
    }
}