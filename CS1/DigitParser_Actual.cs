//Michael McAlexander
// TInfo 200 - CS1        Due 2022-01-22
/////////////////////////////////////////////////////////////////////
//Change History
//Date          Developer       Description
//2022-01-20    Michael         Opening of Project (second project of digit parser)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digit_Parser
{//writes basic program that spaces the numbers as user gives.
    internal class Program
    {//main app entry execution point
        static void Main(string[] args)
        {//user interface explains the app and what it does to the user.
         //1-explain why user would use this app.
         //2-give user instructions on how the software works.
            Console.WriteLine(@"
****************************************
Welcome User(s) to the Digit Parser app
****************************************
this app takes a string of 5 digits and inserts space inbetween each digit.");
            //input area of the program
            //get number from the user
            //Console.Write("Please type 5 digits with no spaces here:");
            int number = 42339;
            var str = string.Join("   ", (IEnumerable<char>)number.ToString());
            Console.Write(number);
            Console.Write(str);
        }
    }
}
