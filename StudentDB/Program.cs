//this is a mark 2 version because the first time I went through it the code failed to load properly litterally I dont know if it was confusing to follow or is visual studio downloaded weird but we will find out which
////Michael McAlexander
// TInfo 200 - L6        Due 2022-03-05
/////////////////////////////////////////////////////////////////////
//the purpose of this application is an interactive student database program.
//Change History
//Date          Developer       Description
//2022-02-10    Michael         start program
//2022-02-14    Micahel         full-auto and read write (error occured moving on without testing)
//2022-02-16    Michael         Grad-undergrad (big error happend here wont opne or read/write output ot input)
//2022-02-23    Michael         CRUD
//2022-03-02    Michael         SQL
//2022-03-03    Michael         trying to fix errors that occured, restar complete process. litterally no way to progress.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //make a singleton obj for the database app itself
            DbApp database = new DbApp();
            //execute the application main loop
            database.Run();
        }
        //for now this is not being used if we want to reverrt back ton testing using this canned data, we can.
        //static void TestMain1()
       // {
            //hard coded student obj created for testing.
            //Student stu1 = new Student("Alice", "Anderson", 3.9, "aanderson@uw.edu", DateTime.Now);
            //Student stu2 = new Student("Bob", "Bradshaw", 3.7, "bbradshaw@uw.edu", DateTime.Now);
            //Student stu3 = new Student("Carlos", "Cast", 3.7, "ccast@uw.edu", DateTime.Now);
            //Student stu4 = new Student("David", "Davis", 3.0, "ddavis@uw.edu", DateTime.Now);

            //Undergrad undergrad = new Undergrad("Eddie", "Ericson", 2.9, "eericson@uw.edu", DateTime.Now, YearRank.Freshman, "Computer Science");

            //nice to be able to just "writeline a student so we will go override the tostring method in student
            //Console.WriteLine(stu1);
            //Console.WriteLine(stu2);
            //Console.WriteLine(stu3);
            //Console.WriteLine(stu4);

            // test the output to the file to string calls
            //Console.WriteLine(stu1.ToStringForOutputFile());
            //Console.WriteLine(stu2.ToStringForOutputFile());
            //Console.WriteLine(stu3.ToStringForOutputFile());
            //Console.WriteLine(stu4.ToStringForOutputFile());


       //choic }
    }
}
