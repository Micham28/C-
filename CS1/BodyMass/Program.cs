//Michael McAlexander
// TInfo 200 - CS1        Due 2022-01-22
/////////////////////////////////////////////////////////////////////
//Change History
//Date          Developer       Description
//2022-01-21    Michael         Begin work on problems 3-4, then touch ups and finalizations for all 4.
//2022-01-21    Michael         Completed BMI Calculator on 2022-01-21 (COMPLETE)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyMass
{//writes basic program that takes the users weight in pounds (lbs) and height in inches (in)and calculates the users BMI (Body Mass Index).
    internal class Program
    {//main app entry execution point
        static void Main(string[] args)
        {//user interface explains the app and what it does to the user.
         //1-explain why user would use this app.
         //2-give user instructions on how the software works.
            Console.WriteLine(@"
****************************************************************
Welcome user(s) to the Body Mass Index (BMI) Calculation program
****************************************************************
This app is designed to take your self measurements of weight in
Pounds (lbs) and your height in Inches (in.) and calaculate your 
BMI.");
            //should probably include a way to convert FT to IN, will only convert the foot part into inches.(complete)
            //input area of the program
            //get measurements from the user
            Console.WriteLine(@"to get you started we have a built in Foot to Inches Converter
program. Please Only put the Ft part of your measurements
below. (ex: 4ft, 5ft, 6ft).");
            Console.Write("Please enter ONLY the foot (Ft) part of your height here:");
            int feet = int.Parse(Console.ReadLine());
            //heres where  we convert the first portion of the heigh for the users ease
            int convert = feet * 12;
            Console.Write($"this is your Ft converted to Inches: ({convert}), \n" +
                $"use this measurement then add the remaining inches in your \n" +
                $"height to get your total height in inches. \n" +
                $"");
            
            Console.Write("Enter your weight in Pounds (lbs) here:");
            //tells the program it should be accepting integers/digits
            //we assiogn the varibales under each call to avoid confusion
            float weight = float.Parse(Console.ReadLine());
            Console.Write("Enter your height in Inches (in.) here:");
            float height = float.Parse(Console.ReadLine());
            //we need to then calculate the BMI from the given information
            float BMI = (weight * 703)/(height * height);
            //Console.Write(BMI);
            //put from least to greatest so the code reads right.
            if (BMI < 18.5)
            {
                Console.Write($"You are Under Weight as your BMI of {BMI} is below the healthy standard. \n" +
                    $"This may potentially affect your health, consult your doctor.");
            }
            else if (BMI >= 30)
            {
                Console.Write($"Your BMI of {BMI} currently sets you at Obese. \n" +
                    $"This could potentially be a probelm for your health, consult your doctor.");
            }
            else if (BMI > 25) 
            {
                Console.Write($"Your BMI of {BMI} currently sets you as Overwieght.");
            }
            else 
            {
                Console.Write($"Your BMI of {BMI} sets you as a health standard normal Body Mass Index. Great job!");
            }
            //a nice little message at the end.
            Console.Write($" \n" +
                $"Thank you for useing T-Info 200's BMI Calculator hope you found this useful! :-)");
        }
    }
}
