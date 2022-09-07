using System;
//Michael McAlexander
// TInfo 200 - CS1        Due 2022-01-22
/////////////////////////////////////////////////////////////////////
//Change History
//Date          Developer       Description
//2022-01-21    Michael         Begin work on CarPool calculator app
namespace CarPool
{
    internal class ProgramBase
    {
        static void Main(string[] args, double)
        {//user interface explains the app and what it does to the user.
         //1-explain why user would use this app.
         //2-give user instructions on how the software works.
            Console.WriteLine(@"
*******************************************
Welcome user(s) to the Car-Pool program
*******************************************
This app is designed to calculate how much 
money you save per day by carpooling with a
standard carpool service. You will be asked 
to provide all the cost in fomation 
(minus the miles) in cents. To convert your
dollars to cents simply take the price in 
dollars and move the decimal place all the 
way to the right.");
            //input area of the program
            //get daily trip information from the user
            //create dollars to cents converter for each
            //give option to use cents only instead of converter
            //total miles driven per day

            //miles you drive on average
            //based on research adding repair cost per mile as calculated from "The Ride Share Company"
            //also based on research i felt it nessecary to add this differentiation funtion for true cost comparision
            Console.Write("enter the total number of miles you drive each day (in whole number amounts):");
            double miles = double.Parse(Console.ReadLine());
            Console.Write("Is your Vehicle a Car or SUV? to respond enter your Vehicle type in lowercase ONLY (car or suv):");
            string answer = Console.ReadLine();
            if (answer == "suv")
            {
                double CPM = miles * 0.28;
            }
            else if (answer == "car")
            {
                double CPM = miles * 0.16;
            }
            else
            {
                Console.Write("sorry that is not yet an option. your response will be calculated WITHOUT maintenance per mile cost. :-(");
                double CPM = miles * 0;
            }

            //cost of gas for user on average
            Console.Write("Eneter the average amount gasoline costs in your area:");
            double CGas = double.Parse(Console.ReadLine());

            //Average miles per gallon
            Console.Write("Enter the average MPG or the advertised MPG your car gets (Miles Per Gallon):");
            double MPG = double.Parse(Console.ReadLine());

            //parking fees per day (in cents)
            Console.Write("Enter your parking fees cost in cents per day:");
            double Park = double.Parse(Console.ReadLine());

            //tolls per day (in cents)
            Console.Write("Enter the amount in cents that you pay in toll fees:");
            double Toll = double.Parse(Console.ReadLine());

            double MMPG = miles / MPG;
            double GMCost = MMPG * CGas;
            double TCents = Park + Toll + GMCost + CPM;
            double TDollars = TCents / 100;

            //cost of a similar trip containing similar variables on carpool sites.
            //convert those costs to cents.
            //at the end put helpful information to the user like how this effects carbon polution.
            //cost comaparison per day

            //Uber
            //
            //Pierce Trips
            //
            //PierceTransit
            //average trip for where I am from to UWT is $2.35
        }
    }
}