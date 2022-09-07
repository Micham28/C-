using System;

namespace StudentDB
{
    internal class Student
    {// auto-implimented props ro define a student in the database
        
        public ContactInfo Info { get; set; }
        public double gradePtAve;
        
        public DateTime EnrollmentDate { get; set; }
        //fully specified ctor for making student database.
        public Student(ContactInfo info, double grades, DateTime enrolled)
        {
            Info = info;
            GradePtAve = grades;
            EnrollmentDate = enrolled;
        }
        //derfault ctor no args does nothing
        public Student()
        {

        }
        public double GradePtAve
        {
            get
            {
                return gradePtAve;
            }

            set
            {
                //set the possible range of gpa values here
                if (0 <= value && value <= 4)
                {
                    gradePtAve = value;
                }
                else
                {
                    //default the value to what is reportable to registrar's office
                    gradePtAve = 0.7;
                }
            }
        }
       
        // to string method for formatting only data to the output file
        public virtual string ToStringForOutputFile()
        {
            // 1 - create some sort of buffer - to hold the string we are going to build up from the data in the obj
            
            string str = string.Empty;
            

            //2 - the hard part - determine which properties/data from the class that you want to include and how you want to format the output
            str += $"{Info.FirstName}\n";
            str += $"{Info.LastName}\n";
            str += $"{GradePtAve:F1}\n";
            str += $"{Info.EmailAddress}\n";
            str += $"{EnrollmentDate}\n";

            //3 - return the string/buffer
            return str;

        }
        // override of to string for formatting in the user interface includes data from the obj and the labels describing the attributes.
        public override string ToString()
        {
            // 1 - create some sort of buffer - to hold the string we are going to build up from the data in the obj
            string str = string.Empty;

            str += "*********************Student Record*************************";
            //2 - the hard part - determine which properties/data from the class that you want to include and how you want to format the output
            str += $"First name: {Info.FirstName}\n";
            str += $" Last name: {Info.LastName}\n";
            str += $"       GPA: {GradePtAve:F1}\n";
            str += $"     Email: {Info.EmailAddress}\n";
            str += $"  Enrolled: {EnrollmentDate}\n";
            //3 - return the string/buffer
            return str;

        }
    }
}