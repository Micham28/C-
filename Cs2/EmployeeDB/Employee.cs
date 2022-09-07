//Michael McAlexander
// TInfo 200B - CS2        Due 2022-02-12
//class feild needs to be designated Employee
//file: program.cs
//3 peices of information: name-first name-last salary
//3 employees
//constructor to initialize three values
//use set/get blocs
//salary is listed as monthly and raise is listed as total annual after the fact.

/////////////////////////////////////////////////////////////////////
//Change History
//Date          Developer       Description
//2022-02-08    Michael         intializing project solving problem to why "Get" and "Set" wont work.  silly its because I didnt make any call for them.
//2022-02-09    Michael         adding the raise functions and possible menu option. determined since this is an accounts test function like in chapter 4 no user interface is required.
//2022-02-10    Michael         annotating the code.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//tells the programs that they are related to files with similar names
namespace EmployeeDB
{//main arguments and start of functions, tells the program that these are objects with definitions somewhere else.
    internal class Employee : object
    {//tells the program to bring the values from the other attachd program and sets a parameter value for how the program reads the values.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public decimal Raise { get; set; }
        //makes a value for the system to act on
        public decimal v = 0.1m;
        //sets a value to conver the requested monthly into yearly

        public decimal h = 12;
        //overloaded function calles for the functions from other page.
        public Employee(string fn, string ln, decimal sal)
        {
            FirstName = fn;
            LastName = ln;
            Salary = sal;
        }
        //calls for overload
        public Employee()
        {

        }   
        //tells the program what to execute with in the output
        public override string ToString()
        {//I had trouble setting external values for raise so I brought it here and it seems to work. but somethings could be improved on.
            Console.WriteLine("this program is only intended to calculate the salaries of the few lucky employees\n" +
                " getting a raise and showing you what the cost to the company is.");
            decimal abs1 = Math.Abs(Salary);//this ensures the value entered can never be zero even with errors.
            decimal Raise = ((Salary * v) + Salary) * h;//takes the salary which has already been converted to yearly and adds the 10% raise.
            decimal abs2 = Math.Abs(Raise);//this ensures the new value cant be zero.
            //tells the program to get readt to write
            string str = string.Empty;
           //output
            str += $"**********************************************************************************************\n";
            str += "********************** The Company Employee up for a Raise ***********************************\n";
            str += "**********************************************************************************************\n";
            str += $"{FirstName} {LastName}\n";
            str += $"Their current Monthly salary rates are: {abs1:C}\n";
            str += $"Their annual raise will bring their yearly salary to: {abs2:C}\n";
            //return tells the program to execute the string values.
            return str;
                
        }

    }
}
