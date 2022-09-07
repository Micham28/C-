//Cs3 we have to choose two programs to make in this solution, I assume it is acceptable to model it after the student DB structure.
//Michael McAlexander
//Info 200 - Cs3            Due 2022-03-12
////////////////////////////////////////////////////////////////
//these applications have the purpose of:
//Change History
//Date          Developer           Description
//2022-03-09    Michael             start of choosing programs and creating base.

//originally had planned to make this a bigger project with separated files but felt it wasnt nessacary but kept this to run things.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs3Apps
{
    internal class Program
    {
        static void Main(string[] args)
        {//tells system where to look and what to run.
            Choice_sys database = new Choice_sys();
            database.Run();
        }

        
    }
}
