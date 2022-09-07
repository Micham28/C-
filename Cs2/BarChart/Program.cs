//Michael McAlexander
// TInfo 200B - CS2        Due 2022-02-12
//bar chart with test information, Creative topics?
//range of bar chart is 1-30.
//the numbe to be displayed will be displayed by asterisks.
//the graph should only display 3 numbers.
/////////////////////////////////////////////////////////////////////
//Change History
//Date          Developer       Description
//2022-02-10    Michael         begining work on the program setting parameters.
//2022-02-11    Michael         trouble shooting issues with prints.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarChart
{
    //all this unessecary can just do a standard Main static void

    internal class Program
    {//varrables to be called

        static void Main(string[] args)
        {//calls for the values of list to be created to hold the separate numbers
            Console.WriteLine($"This program will simply put asterisks to represent the amount of a number in the forma of a barchart.");
            List<int> BarList = new List<int>();
            //takes the values and adds then to a list so they can be iterated through instead of indivicual calls test version static values.
            BarList.Add(3);
            BarList.Add(5);
            BarList.Add(8);
            BarList.Add(13);
            BarList.Add(21);
            //tells the function to use the paramenters and iterations found in the specific static
            DrawBarChart(BarList);
        }
        //creates the parameters under which the chart will be made
        static void DrawBarChart(List<int> LF)
        {//iterates through the list
            for (int i = 0; i < LF.Count; i++)
            {//iterates through th value found and adds an astersik as long as the value is true
                for (int j = 0; j < LF[i]; j++)
                {//tells the system to put an asterisk per value found
                    Console.Write('*');
                }//tells the program to write the string collected.
                Console.WriteLine();
            }
        }
    }
}
