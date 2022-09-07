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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//tells the programs that they are related to files with similar names
namespace EmployeeDB
{//sets a class of programs to run
    internal class Program
    {//main arguments and start of functions
        static void Main(string[] args)
        {//sets value for each account
            Employee NicolasEmp = new Employee();
            Employee NajaEmp = new Employee();
            Employee RichardEmp = new Employee();
            //sets starting attributeable values as well as sharibles
            Employee Emp1 = new Employee("Nicolas", "Garner", 2916.66m);
            Employee Emp2 = new Employee("Naja", "Albatros", 3750.00m);
            Employee Emp3 = new Employee("Richard", "Bungalo", 4583.33m);
            //first employee varriable
            NicolasEmp.FirstName = "Nicholas";
            NicolasEmp.LastName = "Garner";
            NicolasEmp.Salary = 35000.00m;
            
            //second employee varriable
            NajaEmp.FirstName = "Naja";
            NajaEmp.LastName = "Albatros";
            NajaEmp.Salary = 45000.00m;
            
            //third employee varriable
            RichardEmp.FirstName = "Richard";
            RichardEmp.LastName = "Bungalo";
            RichardEmp.Salary = 55000.00m;

            //start of ignore!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //commented this out as it was only needed to test.
            //this is the part of the function that calls for the out puts so then can be overload called later.
            //put raise amount here
            //Console.WriteLine("**************************************************");
            //Console.WriteLine($"the following employee is up for a yearly raise: \n" +
            // $"\t {NicolasEmp.FirstName} {NicolasEmp.LastName} with a current salary of: {NicolasEmp.Salary:C}");

            //put raise amount here

            //Console.WriteLine("**************************************************");
            //Console.WriteLine($"the following employee is up for a yearly raise: \n" +
            //$"\t {NajaEmp.FirstName} {NajaEmp.LastName} with a current salary of: {NajaEmp.Salary:C}");

            //put raise here

            // Console.WriteLine("**************************************************");
            // Console.WriteLine($"the following employee is up for a yearly raise: \n" +
            // $"\t {RichardEmp.FirstName} {RichardEmp.LastName} with a current salary of: {RichardEmp.Salary:C}");

            //end of ignore!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //sets a valule to be given for the overloaded function.
            Console.WriteLine(Emp1);
            Console.WriteLine(Emp2);
            Console.WriteLine(Emp3);
        }
    }
}