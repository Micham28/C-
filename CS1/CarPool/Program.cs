//Michael McAlexander
// TInfo 200 - CS1        Due 2022-01-22
/////////////////////////////////////////////////////////////////////
//Change History
//Date          Developer       Description
//2022-01-21    Michael         Begin work on CarPool calculator app, looked at making options for it but the research showed that varibles are too wide for what I wanted to do. how ever still added a neat original feature.
//2022-01-21    Michael         (COMPLETE)
//2022-01-22    Michael         extended work in options (complete)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool
{//writes basic program that calculates your savings per Day.
    internal class Program
    {//main app entry execution point
        static void Main(string[] args)
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
            Console.Write("Is your Vehicle a Car or SUV? to respond enter your Vehicle type in lowercase ONLY (car or suv or truck):");
            string answer = Console.ReadLine();
            if (answer == "suv")
            {
                double CPM = miles * 0.28;
                Console.Write($"your maintenance cost per mile is:{CPM} in dollars \n" +
                    $"");
            }
            else if (answer == "car")
            {
                double CPM = miles * 0.16;
                Console.Write($"your maintenance cost per mile is:{CPM} in dollars \n" +
                    $"");
            }
            else if (answer == "truck")
            {
                double CPM = miles * 0.29;
                Console.Write($"your maintenance cost per mile is:{CPM} in dollars \n" +
                    $"");
            }
            else
            {
                Console.Write($"there is not option for this yet or you did not type in lowercase,\n" +
                    $"either way when promted for the Cost Per Mile you will say 0.\n" +
                    $"");
            }

            //cost of gas for user on average
            Console.Write("Eneter the average cost in CENTS of gasoline costs in your area:");
            double CGas = double.Parse(Console.ReadLine());

            //Average miles per gallon
            Console.Write("Enter the average MPG or the advertised MPG your car gets (Miles Per Gallon):");
            double MPG = double.Parse(Console.ReadLine());

            //parking fees per day (in cents)
            Console.Write("Enter your parking fees cost in CENTS per day:");
            double Park = double.Parse(Console.ReadLine());

            //tolls per day (in cents)
            Console.Write("Enter the amount in CENTS that you pay in toll fees:");
            double Toll = double.Parse(Console.ReadLine());

            double MMPG = miles / MPG;
            double GMCost = MMPG * CGas;
            //user has to re-submitt the Maintenance cost per mile as I couldt remember how to get that on auto fill.
            Console.Write("please remind us what we estimated the Maintenance cost per mile was:");
            double reminder = double.Parse(Console.ReadLine());
            double v = Park + Toll + GMCost;
            double TCents = (v / 100) + reminder;
            Console.Write($"your daily total cost in dollars is {TCents}.\n" +
                $"");
            //talks on savings Vanpool provides
            Console.Write($"even with this low cost my personal comparable trip from Pierce \n" +
                $"Transit carPool with similar variables was only $2.71. (14% savings) \n" +
                $"there are also IRS Tax benefits, Employees can spend pretax dollars \n" +
                $"(up to $260 per month) on a public transportation benefit.\n" +
                $"The employer can in turn avoid paying FICA tax on those salary dollars.\n" +
                $"");
            //uses my exapmle trip which comes to a 14% savings, I apply that to the calculations
            double VRide = TCents * 0.14;
            Console.Write($"your estimated daily cost for a rideshare/vanpool service is: ${VRide}.\n" +
                $"");
            double WRide = VRide * 0.5;
            Console.Write($"and in Washington State your Tax credit per day is: ${WRide}.");

            Console.Write("Thank you for using the T-Info 200 vanpool estimate service we hope you enjoyed your experience.");

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


//description and research area//
//https://www.rideshare.com/easy-commute/commuter-savings-calculator/ helped me to come up with some optional things.
//https://www.piercetrips.com/139/Carpool
//https://www.uber.com/us/en/ride/uberpool/
//https://www.piercetransit.org/vanpool/
//https://www.wageworks.com/kgs/commuter/commuter-savings-calculator/ /mostly a cost ranger
//https://www.intercitytransit.com/vanpool/commuter-tax-benefits /tax benefit information provided by Intercity Transit
