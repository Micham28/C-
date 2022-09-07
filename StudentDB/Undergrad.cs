using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    public enum YearRank
    {
        Freshman = 1,
        Sophomore = 2,
        Junior = 3,
        Senior = 4
    }
    internal class Undergrad : Student // : obj
    {
        public YearRank Rank { get; set; }
        public string DegreeMajor { get; set; }

        public Undergrad(string first, string last, double gpa, string email, DateTime enrolled, YearRank year, string major)
            : base(new ContactInfo(first, last, email), gpa, enrolled)
        {
            Rank = year;
            DegreeMajor = major;
        }
        public override string ToString() => base.ToString() + $"      Year: {Rank}\n     Major: {DegreeMajor}";

        //print out RTTI info - grab all data from the built up info for printing
        //finally, print the 2 new props
        public override string ToStringForOutputFile()
        {
            //1 - create a buffer to hold built up info for the printing
            string str = this.GetType() + "\n";
            str += base.ToStringForOutputFile();

            //2 - build up the buffer with the obj(s) data
            str += $"{Rank}\n";
            str += $"{DegreeMajor}";

            //3 - return the buffer as a string
            return str;
        }

    }
}
