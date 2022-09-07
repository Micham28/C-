using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    internal class GradStudent : Student
    {
        public decimal TuitionCredit { get; set; }
        public string FacultyAdvisor { get; set; }
        public GradStudent(string first, string last, double gpa, string email, DateTime enrolled, decimal credit, string advisor)
            : base(new ContactInfo(first, last, email), gpa, enrolled)
        {
            //2 new specific props for a grad, will be stored here in derived class
            TuitionCredit = credit;
            FacultyAdvisor = advisor;

        }
        //override w/an expression-bodied method - lambda
        public override string ToString() => base.ToString() + $"    Credit: {TuitionCredit:C}\n   Advisor: {FacultyAdvisor}\n";
        public override string ToStringForOutputFile()
        {
            //1 - create a buffer to hold built up info for the printing
            string str = this.GetType() + "\n";
            str += base.ToStringForOutputFile();

            //2 - build up the buffer with the obj(s) data
            str += $"{TuitionCredit}\n";
            str += $"{FacultyAdvisor}";

            //3 - return the buffer as a string
            return str;
        }
    }
}
